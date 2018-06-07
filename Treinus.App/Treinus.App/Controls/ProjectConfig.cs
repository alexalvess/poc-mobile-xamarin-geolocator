using System;
using System.Collections.Generic;
using System.Text;

namespace Treinus.App.Controls
{
    public static class ProjectConfig
    {
        public static string GoogleApiPlaces(int radius, string type, string location) => 
            $"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=-33.8670,151.1957&radius={radius}&types={type}&key=AIzaSyAHNEGHcFEEsGofdfcoWFlhDBrHI1P5-08";

        public static string GoogleApiRoutes(string pInicial, string pFinal) =>
            $"https://maps.googleapis.com/maps/api/directions/json?origin={pInicial}&destination={pFinal}&key=AIzaSyC3cDQidx-_HIb_6es8qlpRMs76jfGgzQ0";
    }
}
