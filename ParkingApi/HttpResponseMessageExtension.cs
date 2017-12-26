using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ParkingApi
{
    public static class HttpResponseMessageExtension
    {
        public static async Task<T> ConvertTo<T>(this HttpResponseMessage response) where T : class
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
