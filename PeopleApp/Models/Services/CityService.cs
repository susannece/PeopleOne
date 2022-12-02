using PeopleApp.Models.Repos;
using PeopleApp.Models.ViewModels;

namespace PeopleApp.Models.Services
{
    public class CityService : ICityService
    {
        ICityRepo _cityRepo;
        public CityService(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }

        public List<City> All()
        {
            return _cityRepo.Read(); 
        }

        public City Create(CreateCityViewModel createCity)
        {
            if (string.IsNullOrEmpty(createCity.Name))
            {
                throw new ArgumentException("City name not allowed with white space or empty.");
            }

            City city = new City()
            {
                Name = createCity.Name,
                Persons = createCity.Persons
            };
            city = _cityRepo.Create(city);
            return city;
        }

        public bool Edit(int id, CreateCityViewModel cityViewModel)
        {
            throw new NotImplementedException();
        }

        public City FindById(int id)
        {
            return _cityRepo.GetById(id);
        }

        public bool Remove(int id)
        {
            City city = _cityRepo.GetById(id);
            bool success = _cityRepo.Delete(city);
            return success;
        }

        public List<City> Search(string search)
        {
            throw new NotImplementedException();
        }
    }
}
