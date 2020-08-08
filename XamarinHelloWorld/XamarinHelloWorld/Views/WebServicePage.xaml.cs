using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinHelloWorld.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinHelloWorld.Services;

namespace XamarinHelloWorld.Views
{
    public partial class WebServicePage : ContentPage
    {
        RestService _restService;
        public WebServicePage()
        {
            InitializeComponent();
            _restService = new RestService();
        }
        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cityEntry.Text))
            {
                WeatherData weatherData = await _restService.GetWeatherDataAsync(GenerateRequestUri(Constants.OpenWeatherMapEndpoint));
                BindingContext = weatherData;
            }
            else
            {
                await DisplayAlert("City Selector", "Please enter a city", "OK");
            }
        }
        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q={cityEntry.Text}";
            requestUri += "&units=imperial"; // or units=metric
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            Console.WriteLine(requestUri);
            return requestUri;
        }
    }
}