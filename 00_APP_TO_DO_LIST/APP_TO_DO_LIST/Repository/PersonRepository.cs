using APP_TO_DO_LIST.Context;
using APP_TO_DO_LIST.Model;
using APP_TO_DO_LIST.Repository.Interface;

namespace APP_TO_DO_LIST.Repository;

public class PersonRepository : BaseRepository<Person>, IPersonRepository
{
    public PersonRepository(MySQLContext context) : base(context)
    {
    }
}
