using System.Text.Json;

namespace WEATHER_APP
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

        private async void SearchBtn(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(CityEntry.Text))
            {
                CityText.Text = "you must any city name show to weather !";
                return;
            }
            try
            {
                string text = CityEntry.Text;
                string ApiKey = "a0211cd416d046b381823430261505";
                string URL = $"https://api.weatherapi.com/v1/current.json?key={ApiKey}&q={text}&aqi=no";

                HttpClient client = new HttpClient();
                string json = await client.GetStringAsync(URL);



                using (JsonDocument doc = JsonDocument.Parse(json))
                {
                    if (doc.RootElement.TryGetProperty("error", out var err))
                    {
                        return;


                    }



                }
                WeatherRoot data = JsonSerializer.Deserialize<WeatherRoot>(json);


                CityText.Text = data.location.name;
                TempText.Text = $"{data.current.temp_c}°C";
                HumidityText.Text = $"{data.current.humidity}";
            }
            catch (HttpRequestException)
            {
                CityText.Text = "there is a connection problem OR it's not available city of name !";


            }

            catch (Exception)
            {
                CityText.Text = "Ooops! Unexepcted an error ! ";



            }





        }





    }


}


