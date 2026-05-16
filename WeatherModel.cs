namespace WEATHER_APP
{
    public class Location
    {
        public string name { get; set; }

    }
    public class Current
    {
        public float temp_c { get; set; }
        public int humidity { get; set; }
    }

    public class WeatherRoot
    {
        public Location location { get; set; }
        public Current current { get; set; }
    }

}
