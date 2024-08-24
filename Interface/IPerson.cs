using mitesh_gandhi_pratical_test.Models;

namespace mitesh_gandhi_pratical_test.Interface
{
    public interface IPerson
    {
        IEnumerable<PersonModel> GetPeoples();
        PersonModel GetPeopleById(int Id);
        void AddPerson(PersonModel personModel);
        void UpdatePerson(PersonModel personModel);
        void DeletePerson(int Id);

    }
}
