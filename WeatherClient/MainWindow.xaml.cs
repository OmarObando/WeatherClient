using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeatherClient.Model.API;
using WeatherClient.UserControls;
using static WeatherClient.Model.API.ResponseServices;

namespace WeatherClient
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void button_queryWheater_Click(object sender, RoutedEventArgs e)
        {
            this.wp_Wheater.Children.Clear();
            String city_name = this.tb_cityName.Text;
            if (!String.IsNullOrEmpty(city_name))
            {
                CurrentForecastResponse response = await WeatherServices.GetCurrentForecast(city_name);
                if (!response.Error)
                {
                    if (response.Forecast != null)
                    {
                        CardDay forecast = new CardDay();
                        forecast.TempIni = response.Forecast.Main.Temp_Max.ToString();
                        forecast.TempFin = response.Forecast.Main.Temp_Min.ToString();
                        forecast.Day = "Today";
                        string img = response.Forecast.Weather[0].Icon;
                        forecast.Source = "/Images/" + img + "@2x.png";
                        
                        this.wp_Wheater.Children.Add(forecast);
                    }
                    else
                    {
                        MessageBox.Show(response.Message, "Error", MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show(response.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Esta vacio el campo");
            }
        }

        private async void button_queryForecast_Click(object sender, RoutedEventArgs e)
        {
            String city_name = this.tb_cityName.Text;
            if (!String.IsNullOrEmpty(city_name))
            {
                this.wp_Wheater.Children.Clear();
                ForecastResponse response = await WeatherServices.GetForecast(city_name);
                if (!response.Error)
                {
                    if (response.List != null)
                    {
                        int iteratorDay = 0;
                        do
                        {
                            CardDay forecast = new CardDay();
                            forecast.TempIni = response.List[iteratorDay].Main.Temp_Max.ToString();
                            forecast.TempFin = response.List[iteratorDay].Main.Temp_Min.ToString();
                            forecast.Day = response.List[iteratorDay].dt_txt;
                            string img = response.List[iteratorDay].Weather[0].Icon;
                            forecast.Source = "/Images/" + img + "@2x.png";

                            this.wp_Wheater.Children.Add(forecast);
                            iteratorDay += 8;
                        } while (iteratorDay < 40);
                    }
                    else
                    {
                        MessageBox.Show(response.Message, "Error", MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show(response.Message, "Error", MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Esta vacio el campo");
            }
        }
    }
    
}
