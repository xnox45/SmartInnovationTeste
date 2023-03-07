using Infra.DataContext;
using Infra.Entities;
using Infra.Interface;

namespace Infra.Repository
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(CadastroContext context) : base(context)
        {
        }
    }
}