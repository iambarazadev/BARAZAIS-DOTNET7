using BARAZAIS.Data.Database;
using BARAZAIS.Data.Models;
using BARAZAIS.Data.Services;
using Microsoft.EntityFrameworkCore;

namespace BARAZAIS.Data.Repos;

public class AccessLevelRepo : BaseRepo<AccessLevelModel>, IAccessLevelService
{
	public AccessLevelRepo(BarazaContext ctx) : base(ctx) 
	{ }

    public async Task<List<AccessLevelModel>> GetAllDetailedAccessLevelAsync()
    {
        List<AccessLevelModel> AllAccessLevel = new();
        if (MyDbSet.Any())
        {
            AllAccessLevel = await MyDbSet
                .ToListAsync();
        }
        else
        {
            AllAccessLevel = new();
        }

        return AllAccessLevel;
    }

    public async Task<AccessLevelModel> GetDetailedAccessLevelAsync(int sn)
    {
        AccessLevelModel Nothing = new();
        if(sn > 0 && (await GetAllDetailedAccessLevelAsync()) != null)
        {
            Nothing = (await GetAllDetailedAccessLevelAsync())
                .Where(x => x.Id == sn)
                .OrderBy(a => a.Id)
                .FirstOrDefault();
        }
        else
        {
            Nothing = new();
        }

        return Nothing;
    }

    public async Task<AccessLevelModel> GetDetailedAccessLevelAsync(string AccessLevelName)
    {
        AccessLevelModel Nothing = new();
        if ((AccessLevelName != null && AccessLevelName != "")  && (await GetAllDetailedAccessLevelAsync()) != null)
        {
            Nothing = (await GetAllDetailedAccessLevelAsync())
                .Where(x => x.Name == AccessLevelName)
                .OrderBy(a => a.Id)
                .FirstOrDefault();
        }
        else
        {
            Nothing = new();
        }

        return Nothing;
    }

    public async Task<int> GetDetailedAccessLevelIdAsync(AccessLevelModel AccessLevel)
    {
        int Nothing = 0;
        if ((AccessLevel != null) && (await GetAllDetailedAccessLevelAsync()) != null)
        {
            foreach(var record in await GetAllDetailedAccessLevelAsync())
            {
                if(record == AccessLevel)
                {
                    return record.Id;
                }
            }
        }
        else
        {
            Nothing = 0;
        }

        return Nothing;
    }
}
