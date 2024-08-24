using AutoMapper;
using Dapper;
using Microsoft.Data.SqlClient;
using mitesh_gandhi_pratical_test.Interface;
using mitesh_gandhi_pratical_test.Models;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using System.Security;

namespace mitesh_gandhi_pratical_test.Service
{
    public class PersonManagementService : IPerson
    {
        private readonly string _connectionString;
        private readonly IMapper _mapper;
        public PersonManagementService(IConfiguration configuration, IMapper mapper)
        {
            _connectionString = configuration.GetConnectionString("mitesh_gandhi_pratical_test");
            _mapper = mapper;

        }
        public void AddPerson(PersonModel personModel)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("sp_AddPerson",new { personModel.Name, personModel.Email, personModel.PhoneNo, personModel.Address, personModel.State, personModel.City}, commandType: CommandType.StoredProcedure);
            }
          
        }

        public void DeletePerson(int Id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("sp_DeletePerson", new {id=Id }, commandType: CommandType.StoredProcedure);
            }
        }

        public PersonModel GetPeopleById(int Id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var data= connection.QueryFirstOrDefault<PersonModel>("sp_GetPersonById", new { id = Id }, commandType: CommandType.StoredProcedure);
                var mappingData = _mapper.Map<PersonModel>(data);
                return mappingData;
            }

            
        }

        public IEnumerable<PersonModel> GetPeoples()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
               var data= connection.Query<PersonModel>("sp_GetPersons", commandType: CommandType.StoredProcedure).ToList();
                return data;
            }
           
        }

        public void UpdatePerson(PersonModel personModel)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute("sp_UpdatePerson", new {personModel.Id, personModel.Name, personModel.Email, personModel.PhoneNo, personModel.Address, personModel.State, personModel.City }, commandType: CommandType.StoredProcedure);
            }
           
        }
    }
}
