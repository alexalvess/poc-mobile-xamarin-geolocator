using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treinus.App.Model;
using Treinus.App.Model.DTO;
using Treinus.App.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Treinus.App.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
		public MapPage (Result place, List<StartLocationDTO> points)
		{
			InitializeComponent ();

            BindingContext = new MapViewModel(place);

            //customMap.RouteCoordinates.Add(new Position(place.Latitude, place.Longitude));
            //customMap.RouteCoordinates.Add(new Position(place.Geometry.Location.Lat, place.Geometry.Location.Lng));

            for (int i = 0; i < points.Count; i++)
                customMap.RouteCoordinates.Add(new Position(points[i].Latitude, points[i].Longitude));

            //customMap.RouteCoordinates.Add(new Position(37.785559, -122.396728));
            //customMap.RouteCoordinates.Add(new Position(37.780624, -122.390541));
            //customMap.RouteCoordinates.Add(new Position(37.777113, -122.394983));
            //customMap.RouteCoordinates.Add(new Position(37.776831, -122.394627));

            //customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(37.79752, -122.40183), Distance.FromKilometers(1.0)));

            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(points[0].Latitude, points[0].Longitude), Distance.FromKilometers(1.0)));
        }
	}
}