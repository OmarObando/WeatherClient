using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherClient.Model.Objects;

namespace WeatherClient.Model.API
{
    public class ResponseServices
    {
        public class CurrentForecastResponse
        {
            public bool Error { get; set; }
            public String Message { get; set; }
            public Forecast Forecast { get; set; }
        }

        public class ForecastResponse
        {
            public bool Error { get; set; }
            public String Message { get; set; }
            public Forecast[] List { get; set; }
        }

    }
}
