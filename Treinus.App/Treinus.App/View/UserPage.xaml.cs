using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinus.App.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Treinus.App.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UserPage : ContentPage
	{
		public UserPage ()
		{
			InitializeComponent ();

            BindingContext = new UserViewModel();
		}
	}
}