using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Treinus.App.Helpers;
using Treinus.App.View;
using Xamarin.Forms;

namespace Treinus.App
{
	public partial class App : Application
	{
        public static INavigation Navigation;

		public App ()
		{
			InitializeComponent();

            if (string.IsNullOrEmpty(UserSettings.Name))
                MainPage = new NavigationPage(new UserPage());
            else
                MainPage = new NavigationPage(new FilterPage());

            Navigation = MainPage.Navigation;
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
