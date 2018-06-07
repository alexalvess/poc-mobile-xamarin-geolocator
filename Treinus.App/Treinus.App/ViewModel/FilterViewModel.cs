using Newtonsoft.Json;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Treinus.App.Controls;
using Treinus.App.Model;
using Treinus.App.View;
using Xamarin.Forms;

namespace Treinus.App.ViewModel
{
    public class FilterViewModel : _BaseViewModel
    {
        private FilterModel filter;

        private ICommand increaseCommand;

        private ICommand decreaseCommand;

        private ICommand filterCommand;

        private ICommand locationCommand;

        private static Address address = new Address();

        private Position position = null;

        private string displayAddress;

        public FilterViewModel() => Filter = new FilterModel();

        public FilterModel Filter
        {
            get => filter;
            set
            {
                filter = value;

                if (filter == null)
                    return;

                OnPropertyChanged("Filter");
            }
        }

        public string DisplayAddress
        {
            get => displayAddress;
            set
            {
                displayAddress = value; ;

                if (string.IsNullOrEmpty(displayAddress))
                    return;

                OnPropertyChanged("DisplayAddress");
            }
        }

        public ICommand IncreaseCommand => increaseCommand ?? (increaseCommand = new Command(Increase));

        public ICommand DecreaseCommand => decreaseCommand ?? (decreaseCommand = new Command(Decrease));

        public ICommand LocationCommand => locationCommand ?? (locationCommand = new Command(Location));

        public ICommand FilterCommand => filterCommand ?? (filterCommand = new Command(Filtering));

        private void Increase()
        {
            if (filter.Distance == 50)
                return;

            Filter.Distance = Filter.Distance + 1;
            OnPropertyChanged("Filter");
        }

        private void Decrease()
        {
            if (Filter.Distance == 1)
                return;

            Filter.Distance = Filter.Distance - 1;
            OnPropertyChanged("Filter");
        }

        private async void Location()
        {
            try
            {
                Dialog.ShowLoading("Buscando localização...");

                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 100;

                position = await locator.GetLastKnownLocationAsync();

                if (position != null)
                {
                    ConvertCoordinateToAddress(locator);
                    Dialog.HideLoading();
                    return;
                }

                if (!IsLocationAvailable())
                    throw new Exception("Recurso de geolocalização não suportado!");

                if (!locator.IsGeolocationEnabled)
                    throw new Exception("Favor habilitar a localização de seu smartphone!");

                position = await locator.GetPositionAsync(TimeSpan.FromSeconds(20), null, true);

                ConvertCoordinateToAddress(locator);
            }
            catch (Exception ex)
            {
                await Dialog.AlertAsync(ex.Message, "Ocorreu um erro", "Ok!");
            }
            finally
            {
                Dialog.HideLoading();
            }
        }

        private async void Filtering()
        {
            try
            {
                Dialog.ShowLoading("Pesquisando...");

                if (await Validate())
                {
                    var data = await RestApi.Get(ProjectConfig.GoogleApiPlaces(Filter.Distance, "gym", Filter.Location));
                    Places places = JsonConvert.DeserializeObject<Places>(data.ToString());

                    if (places.Status.Equals("OK"))
                    {
                        for (int i = 0; i < places.Results.Count; i++)
                        {
                            places.Results[i].Longitude = address.Longitude;
                            places.Results[i].Latitude = address.Latitude;
                        }

                        Dialog.HideLoading();

                        ListPage page = new ListPage(places.Results, address);
                        await PushAsync(page);
                    }
                    else
                    {
                        Dialog.HideLoading();

                        switch (places.Status)
                        {
                            case "ZERO_RESULTS":
                                await Dialog.AlertAsync("Nenhuma academia encontrada.", "Atenção!", "Ok!");

                                break;
                            case "OVER_QUERY_LIMIT":
                                await Dialog.AlertAsync("O número de academias foi muito grande.", "Atenção!", "Ok!");

                                break;
                            case "REQUEST_DENIED":
                                await Dialog.AlertAsync("Houve um erro na busca.", "Atenção!", "Ok!");

                                break;
                            case "INVALID_REQUEST":
                                await Dialog.AlertAsync("Busca inválida.", "Atenção!", "Ok!");

                                break;
                            case "UNKNOWN_ERROR":
                                await Dialog.AlertAsync("Houve um erro, tente novamente.", "Atenção!", "Ok!");

                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await Dialog.AlertAsync(ex.Message, "Ocorreu um erro", "Ok!");
            }
            finally
            {
                Dialog.HideLoading();
            }
        }

        private async Task<bool> Validate()
        {
            if(string.IsNullOrEmpty(Filter.Location))
            {
                await Dialog.AlertAsync("Por favor, informe sua localização", "Atenção", "Ok!");
                return false;
            }

            return true;
        }

        private async void ConvertCoordinateToAddress(IGeolocator locator)
        {
            var addresses = await locator.GetAddressesForPositionAsync(position);
            address = addresses.FirstOrDefault();

            Filter.Address = $"{address.Locality} - {address.AdminArea}";
            Filter.Location = $"{address.Latitude},{address.Longitude}";

            OnPropertyChanged("Filter");
        }

        private bool IsLocationAvailable()
        {
            if (!CrossGeolocator.IsSupported)
                return false;

            return CrossGeolocator.Current.IsGeolocationAvailable;
        }
    }
}
