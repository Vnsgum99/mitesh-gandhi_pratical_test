using AutoMapper;
using mitesh_gandhi_pratical_test.DataStore;
using mitesh_gandhi_pratical_test.Models;

namespace mitesh_gandhi_pratical_test.Service
{
    public class MappingDataProfilecs:Profile
    {
        public MappingDataProfilecs() {
            CreateMap<PersonModel, Person>().ReverseMap();
        }
    }
}
