using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherClient.Model.Objects
{
    public class Weather
    {
        public String Id { get; set; }
        public String Main { get; set; }
        public String Description { get; set; }
        public String Icon { get; set; }
    }
}
