using BARAZAIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Services;

public interface IBaseService<T> where T : class
{
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    void Update(T entity);
    void UpdateRange(List<T> entities);
    //Task<T> GetThisRecord(int Id);
    Task<List<T>> GetAllRecords(int PageSize, int CurrentPage);
    int GetNoRecords();
    int GetIndexOf(T entity);
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}
