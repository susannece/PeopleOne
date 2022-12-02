using PeopleApp.Models.ViewModels;

namespace PeopleApp.Models.Services
{
    public interface IPeopleService
    {
        Person Create(CreatePersonViewModel createPerson);
        List<Person> All();
        List<Person> Search(string search);
        Person FindById(int id);
        bool Edit(int id, CreatePersonViewModel personViewModel);
        bool Remove(int id);

        public Person? LastAdded();
    }
}
