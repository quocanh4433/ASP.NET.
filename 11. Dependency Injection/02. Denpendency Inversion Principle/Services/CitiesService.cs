using ServiceContracts;

namespace Services;
public class CitiesService : ICititesService
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

