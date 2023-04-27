using BARAZAIS.Data.Models;

namespace BARAZAIS.Data.Services;

public interface IAccessLevelService : IBaseService<AccessLevelModel>
{
    Task<List<AccessLevelModel>> GetAllDetailedAccessLevelAsync();
    Task<AccessLevelModel> GetDetailedAccessLevelAsync(int sn);
    Task<AccessLevelModel> GetDetailedAccessLevelAsync(string AccessLevelName);
    Task<int> GetDetailedAccessLevelIdAsync(AccessLevelModel AccessLevel);
}
