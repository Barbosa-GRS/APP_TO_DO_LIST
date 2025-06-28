using APP_TO_DO_LIST.Context;
using APP_TO_DO_LIST.Model;
using APP_TO_DO_LIST.Repository.Interface;

namespace APP_TO_DO_LIST.Repository;

public class AdressRepository : BaseRepository<Adress>, IAdressRepository

{
    public AdressRepository(MySQLContext context) : base(context)
    {
    }
}
