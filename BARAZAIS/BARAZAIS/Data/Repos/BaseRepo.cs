
using BARAZAIS.Data.Database;
using BARAZAIS.Data.Models;
using BARAZAIS.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BARAZAIS.Data.Repos;

public class BaseRepo<T> : IBaseService<T> where T : class
{
#nullable enable
    protected readonly BarazaContext _Context;
    internal DbSet<T>? MyDbSet { get; set; }

    public BaseRepo(BarazaContext ctx)
    {
        this._Context = ctx;
        this.MyDbSet = _Context.Set<T>();
    }

    public async Task<bool> AddAsync(T entity)
    {
        await MyDbSet.AddAsync(entity);
        var EntityType = MyDbSet?.GetType();

        return true;
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await MyDbSet
        .AddRangeAsync(entities);
    }

    public void Remove(T entity)
    {
        if (MyDbSet.Any())
        {
            MyDbSet
            .Remove(entity);
        }
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        if (MyDbSet.Any())
        {
            MyDbSet
            .RemoveRange(entities);
        }
    }

    public virtual void Update(T entity)
    {
        if (MyDbSet.Any())
        {
            MyDbSet
            .Update(entity);
        }
    }

    public void UpdateRange(List<T> entities)
    {
        if (MyDbSet.Any())
        {
            MyDbSet
            .UpdateRange(entities);
        }
    }

    public int GetNoRecords()
    {
        int Nothing = 0;
        if (MyDbSet.Any())
        {
            return MyDbSet
             .ToList()
             .Count();
        }
        else
        {
            return Nothing;
        }
    }

    public int GetIndexOf(T entity)
    {
        int Nothing = 0;
        if (MyDbSet.Any())
        {
            return MyDbSet
            .ToList()
            .IndexOf(entity);
        }
        else
        {
            return Nothing;
        }
    }

    public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        List<T> Nothing = new();

        if (MyDbSet.Any())
        {
            return await MyDbSet
             .Where(predicate)
             .ToListAsync();
        }
        else
        {
            return Nothing;
        }
    }

    public async Task<List<T>> GetAllRecords(int PageSize, int CurrentPage)
    {
        if (MyDbSet.Any())
        {
            return await MyDbSet
            .Skip((CurrentPage - 1) * PageSize)
            .Take(PageSize)
            .ToListAsync();
        }
        else
        {
            return null;
        }
    }
    /*
    public async Task<T> GetThisRecord(int Id)
    {
        if(Id > 0 && MyDbSet.Any()){
            return await MyDbSet
                .Where(x => x.Id == Id)
                .FirstOrDefault();
        }
        else
        {
            return null;
        }
    }
    */
}
