using Newtonsoft.Json;
using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Treinus.App.Controls;
using Treinus.App.Model;
using Treinus.App.Model.DTO;
using Treinus.App.View;
using Xamarin.Forms;

namespace Treinus.App.ViewModel
{
    public class ListViewModel : _BaseViewModel
    {
        private List<Result> placeList;

        private Result place;

        private Address address;

        private ICommand detailCommand;

        public ListViewModel(List<Result> results, Address address)
        {
            this.address = address;

            PlaceList = results.OrderBy(c => c.DistanceCalculate()).ToList();
        }

        public List<Result> PlaceList
        {
            get => placeList;
            set
            {
                placeList = value;

                if (placeList == null)
                    return;

                OnPropertyChanged("PlaceList");
            }
        }

        public Result Place
        {
            get => place;
            set
            {
                place = value;

                if (place == null)
                    return;

                DetailCommand.Execute(place);

                OnPropertyChanged("Place");

                Place = null;
            }
        }

        public ICommand DetailCommand => detailCommand ?? (detailCommand = new Command<Result>(Detail));

        private async void Detail(Result place)
        {
            try
            {
                Dialog.ShowLoading("Carregando rotas...");

                var pInicial = $"{place.Latitude},{place.Longitude}";
                var pFinal = $"{place.Geometry.Location.Lat},{place.Geometry.Location.Lng}";

                var data = await RestApi.Get(ProjectConfig.GoogleApiRoutes(pInicial, pFinal));
                RoutesDTO routes = JsonConvert.DeserializeObject<RoutesDTO>(data.ToString());

                List<StartLocationDTO> points = new List<StartLocationDTO>();

                if (!routes.Status.Equals("OK"))
                {
                    points.Add(new StartLocationDTO { Latitude = place.Latitude, Longitude = place.Longitude });
                    points.Add(new StartLocationDTO { Latitude = place.Geometry.Location.Lat, Longitude = place.Geometry.Location.Lng });
                }
                else
                {
                    for (int i = 0; i < routes.Routes.Count; i++)
                    {
                        for (int j = 0; j < routes.Routes[i].Legs.Count; j++)
                        {
                            for (int k = 0; k < routes.Routes[i].Legs[j].Steps.Count; k++)
                            {
                                points.Add(new StartLocationDTO
                                {
                                    Latitude = routes.Routes[i].Legs[j].Steps[k].StartLocation.Latitude,
                                    Longitude = routes.Routes[i].Legs[j].Steps[k].StartLocation.Longitude,
                                });
                            }
                        }
                    }
                }

                MapPage page = new MapPage(place, points);
                await PushAsync(page);

                Dialog.HideLoading();
            }
            catch (Exception ex)
            {
                await Dialog.AlertAsync(ex.Message, "Ocorreu o seguinte erro:", "Ok!");

                Dialog.HideLoading();
            }
        }
    }
}
