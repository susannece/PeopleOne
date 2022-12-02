using PeopleApp.Data;

namespace PeopleApp.Models.Repos
{
    public class DatabasePeopleRepo : IPeopleRepo
    {
        readonly PeopleAppDbContext _peopleAppDbContext;
        public DatabasePeopleRepo(PeopleAppDbContext peopleAppDbContext)
        {
            _peopleAppDbContext = peopleAppDbContext;
        }
    
        public Person Create(Person person)
        {
            _peopleAppDbContext.Add(person);
            _peopleAppDbContext.SaveChanges();
            return person;
        }

        public Person GetById(int id)
        {
            return _peopleAppDbContext.Person.SingleOrDefault(person => person.Id == id);
        }

        public List<Person> Read()
        {
            return _peopleAppDbContext.Person.ToList();
        }

        public Person Read(int id)
        {
            return _peopleAppDbContext.Person.SingleOrDefault(person => person.Id == id);
        }

        public bool Update(Person person)
        {
            _peopleAppDbContext.Update(person);
            _peopleAppDbContext.SaveChanges();
            return true;
        }

        public bool Delete(Person person)
        {
            _peopleAppDbContext.Remove(person);
            _peopleAppDbContext.SaveChanges();
            return true;
        }


    }
}
