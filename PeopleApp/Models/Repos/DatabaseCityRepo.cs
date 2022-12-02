using PeopleApp.Data;
using System;

namespace PeopleApp.Models.Repos
{
    public class DatabaseCityRepo : ICityRepo
    {
        readonly PeopleAppDbContext _peopleAppDbContext;
        public DatabaseCityRepo(PeopleAppDbContext peopleAppDbContext)
        {
            _peopleAppDbContext = peopleAppDbContext;
        }

        public City Create(City city)
        {
            _peopleAppDbContext.Add(city);
            _peopleAppDbContext.SaveChanges();
            return city;    
        }

        public City GetById(int id)
        {
            return _peopleAppDbContext.City.SingleOrDefault(city => city.Id == id);
        }

        public List<City> Read()
        {
            return _peopleAppDbContext.City.ToList();
        }

        public City Read(int id)
        {
            return _peopleAppDbContext.City.SingleOrDefault(city => city.Id == id);
        }

        public bool Update(City city)
        {
            _peopleAppDbContext.Update(city);
            _peopleAppDbContext.SaveChanges();
            return true;
        }

        public bool Delete(City city)
        {
            _peopleAppDbContext.Remove(city);
            _peopleAppDbContext.SaveChanges();
            return true;
        }
    }
}
