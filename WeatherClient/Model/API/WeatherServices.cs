using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherClient.Model.Objects;
using static WeatherClient.Model.API.ResponseServices;

namespace WeatherClient.Model.API
{
    public class WeatherServices
    {
        private static readonly string 
            URL_BASE = "http://api.openweathermap.org/data/2.5/";
        private static readonly string 
            APP_ID = "8a784f4f3d122573c49c14efac294a2f";

        public static async Task<CurrentForecastResponse> GetCurrentForecast(string cityName)
        {
            CurrentForecastResponse currentForecastResponse = new CurrentForecastResponse();
            using (var httpClient = new HttpClient())
            {
                HttpRequestMessage request;
                HttpResponseMessage response;
                string url = string.Format("{0}weather?q={1}&appid={2}&lang=es&units=metric", URL_BASE,cityName, APP_ID);
                try
                {
                    request = new HttpRequestMessage(HttpMethod.Get, url);
                    response = await httpClient.SendAsync(request);
                    if(response != null)
                    {
                        if(response.IsSuccessStatusCode)
                        {
                            String unSerializeResponse = await response.Content.ReadAsStringAsync();
                            Forecast forecast = JsonConvert.DeserializeObject<Forecast>(unSerializeResponse);
                            if(forecast !=null)
                            {
                                currentForecastResponse.Forecast = forecast;
                                currentForecastResponse.Error = false;
                                currentForecastResponse.Message = "Ok";
                            }
                            else
                            {
                                currentForecastResponse.Error = true;
                                currentForecastResponse.Message = "No se deserializar la respuesta en JSON...";
                            }
                        }
                        else
                        {
                            currentForecastResponse.Error = true;
                            currentForecastResponse.Message = "Error  fatal send help ";
                        }

                    }
                    else
                    {
                    currentForecastResponse.Error = true;
                        currentForecastResponse.Message = "No se puede obtener respuesta del servicio web";
                    }
                }
                catch(Exception exception)
                {
                    currentForecastResponse.Error = true;
                    currentForecastResponse.Message = exception.Message;
                }
            }
            return currentForecastResponse;
        }

        public static async Task<ForecastResponse> GetForecast(string cityName)
        {
            ForecastResponse forecastResponse = new ForecastResponse();
            using (var httpClient = new HttpClient())
            {
                HttpRequestMessage request;
                HttpResponseMessage response;
                string url = string.Format("{0}forecast?q={1}&appid={2}&lang=es&units=metric", URL_BASE, cityName, APP_ID);
                try
                {
                    request = new HttpRequestMessage(HttpMethod.Get, url);
                    response = await httpClient.SendAsync(request);
                    if (response != null)
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            String unSerializeResponse = await response.Content.ReadAsStringAsync();
                            forecastResponse = JsonConvert.DeserializeObject<ForecastResponse>(unSerializeResponse);
                        }
                        else
                        {
                            forecastResponse.Error = true;
                            forecastResponse.Message = "Error  fatal send help ";
                        }
                    }
                    else
                    {
                        forecastResponse.Error = true;
                        forecastResponse.Message = "No se puede obtener respuesta del servicio web";
                    }
                }
                catch (Exception exception)
                {
                    forecastResponse.Error = true;
                    forecastResponse.Message = exception.Message;
                }
            }
            return forecastResponse;
        }







    }
}
