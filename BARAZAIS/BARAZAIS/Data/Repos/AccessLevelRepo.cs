using BARAZAIS.Data.Database;
using BARAZAIS.Data.Models;
using BARAZAIS.Data.Services;

namespace BARAZAIS.Data.Repos;

public class AccessLevelRepo : BaseRepo<AccessLevelModel>, IAccessLevelService
{
	public AccessLevelRepo(BarazaContext ctx) : base(ctx) 
	{ }
}
