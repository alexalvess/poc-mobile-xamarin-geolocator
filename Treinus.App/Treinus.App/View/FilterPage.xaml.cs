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
	public partial class FilterPage : ContentPage
	{
		public FilterPage ()
		{
			InitializeComponent ();

            BindingContext = new FilterViewModel();
		}
    }
}