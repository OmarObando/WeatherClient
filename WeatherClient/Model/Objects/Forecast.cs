using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherClient.Model.Objects
{
    public class Forecast
    {
        public Weather[] Weather { get; set; }
        public Main Main { get; set; }
        public String dt_txt { get; set; } 
    }
}
