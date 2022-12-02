using PeopleApp.Data;

namespace PeopleApp.Models.Repos
{
    public class InMemoryPeopleRepo : IPeopleRepo
    {
        static int idCounter = 0;
        static List<Person> peopleList = new List<Person>();
        readonly PeopleAppDbContext? _peopleAppDbContext;

        public InMemoryPeopleRepo(PeopleAppDbContext peopleAppDbContext)
        {
            _peopleAppDbContext = peopleAppDbContext;
        }

        public InMemoryPeopleRepo() { }

        public Person Create(Person person)
        {
            person.Id = ++idCounter;
            peopleList.Add(person);
            return person;
        }

        public List<Person> Read()
        {
            return peopleList;
        }

        public Person Read(int id)
        {
            Person? person = null;
            foreach (Person p in peopleList)
            {
                if(p.Id == id)
                {
                    person = p;
                    break;
                }
            }
            return person;
        }

        public Person GetById(int id)
        {
            Person? person = null;
            foreach(Person p in peopleList)
            {
                if(id == p.Id)
                {
                    person = p;
                    break;
                }
            }
            return person;
        }

        public bool Update(Person person)
        {
            Person orgPerson = Read(person.Id);
            if(orgPerson != null)
            {
                orgPerson.FullName = person.FullName;
                orgPerson.PhoneNumber = person.PhoneNumber;
                orgPerson.City.Name = person.City.Name;
                return true;
            }
            return false;
        }

        public bool Delete(Person person)
        {
            if(person != null)
            {
                peopleList.Remove(person);
                return true;
            }
            return false;
        }
    }
}
