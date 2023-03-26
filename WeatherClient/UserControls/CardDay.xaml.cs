using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace WeatherClient.UserControls
{
    /// <summary>
    /// Lógica de interacción para CardDay.xaml
    /// </summary>
    public partial class CardDay : UserControl
    {
        public CardDay()
        {
            InitializeComponent();
        }

        public string Day
        {
            get { return (string)GetValue(DayProperty); }
            set { SetValue(DayProperty, value); }
        }

        public string TempFin
        {
            get { return (string)GetValue(TempFinProperty); }
            set { SetValue(TempFinProperty, value); }
        }

        public string TempIni
        {
            get { return (string)GetValue(TempIniProperty); }
            set { SetValue(TempIniProperty, value); }
        }

        public string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly DependencyProperty DayProperty = DependencyProperty.Register(
            "Day", typeof(string), typeof(CardDay));



        public static readonly DependencyProperty TempIniProperty = DependencyProperty.Register(
            "TempIni", typeof(string), typeof(CardDay));



        public static readonly DependencyProperty TempFinProperty = DependencyProperty.Register(
            "TempFin", typeof(string), typeof(CardDay));




        public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(
            "Source", typeof(string), typeof(CardDay));
    }
}
