namespace PeopleApp.Models.Repos
{
    public interface ICityRepo
    {
        //CRUD
        //Create
        City Create(City city);

        //Read
        List<City> Read();
        City Read(int id);
        City GetById(int id);

        //Update
        bool Update(City city);

        //Delete
        bool Delete(City city);
    }
}
