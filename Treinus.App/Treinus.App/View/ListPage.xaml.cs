using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinus.App.Model;
using Treinus.App.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Treinus.App.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListPage : ContentPage
	{
		public ListPage (List<Result> results, Address address)
		{
			InitializeComponent ();

            BindingContext = new ListViewModel(results, address);
		}
	}
}