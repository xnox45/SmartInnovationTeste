using Infra.Entities;
using Infra.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interface
{
    public interface IPersonService : IBaseService<Person>
    {
        Person CreatePerson(PersonDTO person);
    }
}
