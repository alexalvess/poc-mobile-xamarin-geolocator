using System;
using System.Collections.Generic;
using System.Text;
using Treinus.App.Model;

namespace Treinus.App.ViewModel
{
    public class MapViewModel : _BaseViewModel
    {
        private Result place;

        public MapViewModel(Result place) => Place = place;

        public Result Place
        {
            get => place;
            set
            {
                place = value;

                if (place == null)
                    return;

                OnPropertyChanged("Place");
            }
        }
    }
}
