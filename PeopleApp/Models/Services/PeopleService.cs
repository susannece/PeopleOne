using PeopleApp.Models.ViewModels;
using PeopleApp.Models.Repos;

namespace PeopleApp.Models.Services
{
    public class PeopleService : IPeopleService
    {
        IPeopleRepo _peopleRepo;
        public PeopleService(IPeopleRepo peopleRepo)
        {
            _peopleRepo = peopleRepo;
        }
        public Person Create(CreatePersonViewModel createPerson)
        {
            if(string.IsNullOrWhiteSpace(createPerson.FullName) || string.IsNullOrWhiteSpace(createPerson.PhoneNumber)) 
            {
                throw new ArgumentException("Name, and Phonenumber not allowed with white space or empty.");
            }
            Person person = new Person()
            {
                FullName = createPerson.FullName,
                PhoneNumber = createPerson.PhoneNumber,
                City = createPerson.City
            };
            person = _peopleRepo.Create(person);
            return person;
        }

        public bool Edit(int id, CreatePersonViewModel editPerson)
        {
            throw new NotImplementedException();
        }

        public Person FindById(int id)
        {
            return _peopleRepo.GetById(id);
        }

        public List<Person> All()
        {
            return _peopleRepo.Read();
        }

        public bool Remove(int id)
        {
            Person person = _peopleRepo.GetById(id);   
            bool success = _peopleRepo.Delete(person);
            return success;
        }

        public List<Person> Search(string search)
        {
            throw new NotImplementedException();
        }

        public Person? LastAdded()
        {
            List<Person> persons = _peopleRepo.Read();  
            if(persons.Count < 1)
            {
                return null;
            }
            else
            {
               // return persons[persons.Count-1];
                return persons.Last();
            }
        }


    }
}
