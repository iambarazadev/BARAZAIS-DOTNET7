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

public class UserRepo : BaseRepo<UserModel> , IUserService
{
    public UserRepo(BarazaContext ctx) : base(ctx) { }

    public async Task<List<UserModel>> GetAllUsersDetailedAsync()
    {
        List<UserModel> Nothing = new();

        if (MyDbSet.Any())
        {
            return await MyDbSet
            .OrderBy(o => o.Id)
            .Include(a => a.Product)
            .Include(b => b.Grn)
            .Include(c => c.Supplier)
            .Include(d => d.Category)
            .Include(e => e.Brand)
            .Include(f => f.Price)
            .Include(g => g.Adjustment)
            .Include(i => i.Tax)
            .Include(j => j.Bill)
            .Include(k => k.Open)
            .Include(l => l.Hold)
            .Include(m => m.AccessLevel)
            .ToListAsync();
        }
        else
        {
            return Nothing;
        }
    }

    public async Task<UserModel> CheckUserAsync(string mail, string pwd)
    {
        UserModel Nothing = new();

        if (mail != null && pwd != null && (await GetAllUsersDetailedAsync()).Any())
        {
            return (await GetAllUsersDetailedAsync())
            .Where(x => x.Email == mail && x.Password == pwd)
            .SingleOrDefault();
        }
        else
        {
            return Nothing;
        }
    }
    
    public async Task<UserModel> GetDetailedUserAsync(int sn){
        UserModel Nothing = new();
        
        if(sn > 0 && MyDbSet.Any()){
            return (UserModel)(await GetAllUsersDetailedAsync())
            .OrderBy(o => o.Id)
            .Where(x => x.Id == sn)
            .SingleOrDefault();
        }
        else{
            return Nothing;
        }
    }

	public async Task<UserModel> GetDetailedUserAsync(string UserName)
	{
		UserModel Nothing = new();

		if ( (UserName != "" || UserName != null) && MyDbSet.Any())
		{
			return (UserModel)(await GetAllUsersDetailedAsync())
			.OrderBy(o => o.Id)
			.Where(x => x.UserName == UserName)
            .SingleOrDefault();
		}
		else
		{
			return Nothing;
		}
	}

	public async Task<List<UserModel>> GetAllUsersDetailedAsync(int CurrentPage, int PageSize){
        List<UserModel> Nothing = new();
        
        if((await GetAllUsersDetailedAsync()).Any()){
            return (await GetAllUsersDetailedAsync())
            .OrderBy(o => o.Id)
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .ToList();
        }
        else{
            return Nothing;
        }
    }
    
    public async Task<List<UserModel>> GetAllUsersAsync(int CurrentPage, int PageSize){
        List<UserModel> Nothing = new();
        
        if((await GetAllUsersDetailedAsync()).Any()){
            return (await GetAllUsersDetailedAsync())
            .OrderBy(o => o.Id)
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .ToList();
        }
        else{
            return Nothing;
        }
    }
    
    public async Task<List<UserModel>> GetAllUsersAsync(){
        List<UserModel> Nothing = new();
        
        if((await GetAllUsersDetailedAsync()).Any()){
            return (await GetAllUsersDetailedAsync())
            .OrderBy(o => o.Id)
            .ToList();
        }
        else{
            return Nothing;
        }
    }
}