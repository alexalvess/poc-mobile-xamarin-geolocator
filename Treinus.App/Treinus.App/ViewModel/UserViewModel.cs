using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Treinus.App.Helpers;
using Treinus.App.Model;
using Treinus.App.View;
using Xamarin.Forms;

namespace Treinus.App.ViewModel
{
    public class UserViewModel : _BaseViewModel
    {
        private ICommand accessCommand;

        private UserModel user;

        public UserViewModel() => User = new UserModel();

        public UserModel User
        {
            get => user;
            set
            {
                user = value;

                if (user == null)
                    return;

                OnPropertyChanged("User");
            }
        }

        public ICommand AccessCommand => accessCommand ?? (accessCommand = new Command(Access));

        private async void Access()
        {
            try
            {
                if (await Validate())
                {
                    Dialog.ShowLoading("Acessando...");

                    UserSettings.Name = User.Name;
                    UserSettings.Email = User.Email;

                    FilterPage page = new FilterPage();
                    await PushAsync(page);

                    RemoveStackPages(page);
                }
            }
            catch (Exception ex)
            {
                await Dialog.AlertAsync(ex.Message, "Ocorreu um erro!", "Ok!");
            }
            finally
            {
                Dialog.HideLoading();
            }
        }

        private async Task<bool> Validate()
        {
            if (string.IsNullOrEmpty(User.Name))
            {
                await Dialog.AlertAsync("Por favor, informe seu nome.", "Atenção!", "Ok!");
                return false;
            }
            else if (string.IsNullOrEmpty(User.Email))
            {
                await Dialog.AlertAsync("Por favor, informe seu email.", "Atenção!", "Ok!");
                return false;
            }

            return true;
        }
    }
}
