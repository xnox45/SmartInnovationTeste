using Infra.DTOs;
using Infra.Entities;
using Infra.Interface;
using Microsoft.Extensions.Configuration;

namespace Infra.Service
{
    public class PersonService : BaseService<Person>, IPersonService
    {
    
        public PersonService(IPersonRepository repository) : base(repository)
        {
        
        }

        public Person CreatePerson(PersonDTO person)
        {
            try
            {
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
