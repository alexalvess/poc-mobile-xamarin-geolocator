using System;
using System.Collections.Generic;
using System.Text;

namespace Treinus.App.Model
{
    public class FilterModel
    {
        public string Location { get; set; }

        public string Address { get; set; }

        public int Distance { get; set; } = 1;
    }
}
