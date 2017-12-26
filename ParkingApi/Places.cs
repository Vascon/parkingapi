using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApi
{
    public class Place
    {
        public string place_id { get; set; }
        public string place_external_id { get; set; }
        public string place_layer { get; set; }
        public string place_hascounter { get; set; }
        public string place_name { get; set; }
        public string place_price { get; set; }
        public List<string> place_coordinates { get; set; }
        public string address { get; set; }
        public string hours { get; set; }
        public string metro { get; set; }
        public string additional { get; set; }
        public string countspaces { get; set; }
        public int countspacesfordisabled { get; set; }
        public string place_contacts { get; set; }
        public string place_period { get; set; }
        public string linecolor { get; set; }
        public string place_period_en { get; set; }
        public int freespaces { get; set; }
        public int percents_usage { get; set; }
        public string color { get; set; }
        public string layer_display_type { get; set; }
        public string icon { get; set; }
    }

    public class RootObject
    {
        public List<Place> places { get; set; }
        public int count_parkings { get; set; }
        public int count_places { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public string cached { get; set; }
    }
}
