namespace PeopleApp.Models.Repos
{
    public interface IPeopleRepo
    {
        //CRUD
        //Create
        Person Create(Person person);

        //Read
        List<Person> Read();
        Person Read(int id);
        Person GetById(int id);

        //Update
        bool Update(Person person);

        //Delete
        bool Delete(Person person);
    }
}
