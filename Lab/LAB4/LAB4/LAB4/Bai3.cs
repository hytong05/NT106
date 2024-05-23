using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Drawing.Printing;
using System.Net.Http;
using System;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace LAB4
{
    public partial class Bai3 : Form
    {
        private const string ApiKey = "2e4d22bb25426e84eca3b06fc77133bb";
        private const string ApiUrl = "https://api.openweathermap.org/data/2.5/weather";

        public Bai3()
        {
            InitializeComponent();
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            string apiKey = "2e4d22bb25426e84eca3b06fc77133bb"; // Add KPI key
            string city = cityNameText.Text.Trim();
            string countryCode = countryCodeText.Text.Trim();
            cityNameText.Clear();
            countryCodeText.Clear();

            if (string.IsNullOrEmpty(city) || string.IsNullOrEmpty(countryCode))
            {
                MessageBox.Show("Please enter both city and country code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q=" +
                            $"{city},{countryCode}&appid={apiKey}&units=metric"; // Add API URL

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (!response.IsSuccessStatusCode)
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                        {
                            MessageBox.Show("City not found. Please enter a valid city name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show($"Error getting weather data: {response.ReasonPhrase}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        return;
                    }

                    string responseBody = await response.Content.ReadAsStringAsync();

                    dynamic weatherData = Newtonsoft.Json.JsonConvert.DeserializeObject(responseBody);

                    string cityName = weatherData.name;
                    string temperature = weatherData.main.temp;
                    string weatherDescription = weatherData.weather[0].description;

                    cityNameInfor.Text = "City name: " + cityName;
                    temperatureInfor.Text = "Temperature: " + temperature + "°C";
                    weatherDescriptionInfor.Text = "Weather Description: " + weatherDescription;
                    // Get the current UTC time
                    DateTime dataTimeUtc = DateTime.UtcNow;

                    // Convert UTC time to local time using system's default time zone
                    DateTime dataTimeLocal = dataTimeUtc.ToLocalTime();

                    // Display the local time
                    timeInfor.Text = "Time: " + dataTimeLocal.ToString("dd/MM/yyyy HH:mm:ss");

                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Error getting weather data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
