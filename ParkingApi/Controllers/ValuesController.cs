﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ParkingApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task<string> Get(double lat, double lng)
        {
            Place place = new Place();
            double min = 0;

            string html = string.Empty;
            string url = @"http://37.230.149.131/api/get/index.php?zones=001%2C098%2C099%2C005%2C015&price=&pub=false&project=false&disabled=false&lang=ru";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
                var resp = JsonConvert.DeserializeObject<RootObject>(html);
                Dictionary<string, double> distances = new Dictionary<string, double>();

                foreach (Place parking in resp.places)
                {
                    var plat = Convert.ToDouble(parking.place_coordinates[0].Split(',')[0].Replace('.', ','));
                    var plng = Convert.ToDouble(parking.place_coordinates[0].Split(',')[1].Replace('.', ','));
                    var currmin = Math.Sqrt(Math.Pow((lat - plat), 2) + Math.Pow((lng - plng), 2));
                    if (min == 0 || currmin < min)
                    {
                        min = currmin;
                        place = parking;
                    }
                }
            }

            if (min >= 0.002)
                return ("Парковки рядом с вашим автомобилем не найдены");
            return (JsonConvert.SerializeObject(place));
        }
    }
}