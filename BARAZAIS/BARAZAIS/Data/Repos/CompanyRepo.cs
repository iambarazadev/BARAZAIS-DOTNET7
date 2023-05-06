using BARAZAIS.Data.Database;
using BARAZAIS.Data.Models;
using BARAZAIS.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BARAZAIS.Data.Repos;

public class CompanyRepo : BaseRepo<CompanyModel> , ICompanyService
{
    public CompanyRepo(BarazaContext ctx) : base(ctx) { }

    public async Task<List<CompanyModel>> GetAllCompanyDetail()
    {
        List<CompanyModel> Companies = new List<CompanyModel>();

        if (MyDbSet.Any())
        {
            Companies = await MyDbSet
                .ToListAsync();
        }

        return Companies;
    }

    public async Task<CompanyModel> GetCompanyDetailed(string Email)
    {
        CompanyModel Nothing = new();

        if((await GetAllCompanyDetail()).Count > 0)
        {
            Nothing = (await GetAllCompanyDetail())
                .Where(a => a.Email == Email)
                .FirstOrDefault();
        }

        return Nothing;
    }
}