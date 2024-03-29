﻿using BARAZAIS.Data.Database;
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
                .ThenInclude(ab => ab.ProductBill)
            .Include(b => b.Grn)
                .ThenInclude(ba => ba.ProductGrn)
            .Include(c => c.Supplier)
            .Include(d => d.Category)
            .Include(e => e.Brand)
            .Include(f => f.Price)
            .Include(g => g.Adjustment)
                .ThenInclude(ga => ga.ProductAdjustment)
            .Include(i => i.Tax)
            .Include(j => j.Bill)
                .ThenInclude(bp => bp.ProductBill)
            .Include(k => k.Open)
                .ThenInclude(ka => ka.ProductOpen)
            .Include(l => l.Hold)
                .ThenInclude(la => la.ProductHold)
            .Include(m => m.Company)
            .ToListAsync();
        }
        else
        {
            return Nothing;
        }
    }

    public async Task<UserModel> GetUserPartialAsync(string UserName)
    {
        UserModel Nothing = new();

        if (UserName != null && MyDbSet.Any())
        {
            Nothing = await MyDbSet
                .Where(x => x.UserName == UserName)
                .FirstOrDefaultAsync();
        }
        else
        {
            Nothing = new();
        }

        return Nothing;
    }
    
    public async Task<UserModel> GetDetailedUserAsync(int sn){
        UserModel Nothing = new();
        
        if(sn > 0 && (await GetAllUsersDetailedAsync()).Any()){
            return (await GetAllUsersDetailedAsync())
            .OrderBy(o => o.Id)
            .Where(x => x.Id == sn)
            .FirstOrDefault();
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
			return (await GetAllUsersDetailedAsync())
			.OrderBy(o => o.Id)
			.Where(x => x.UserName == UserName)
            .FirstOrDefault();
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