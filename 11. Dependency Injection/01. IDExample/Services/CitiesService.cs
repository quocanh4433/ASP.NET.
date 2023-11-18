namespace Services;
public class CitiesService
{
    public List<string> _cities;

    public CitiesService()
    {
        _cities = new List<string>() {
           "London",
           "Paris",
           "Seoul",
           "Tokyo"
        };
    }

    public List<string> GetCities()
    {
        return _cities;
    }
}

