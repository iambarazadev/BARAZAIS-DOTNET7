using BARAZAIS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BARAZAIS.Data.Services;

public interface IUserService : IBaseService<UserModel>
{
    Task<UserModel> CheckUserAsync(string mail, string pwd);
    Task<UserModel> GetDetailedUserAsync(int sn);
	Task<UserModel> GetDetailedUserAsync(string UserName);
	Task<List<UserModel>> GetAllUsersAsync();
    Task<List<UserModel>> GetAllUsersDetailedAsync(int CurrentPage, int PageSize);
    Task<List<UserModel>> GetAllUsersAsync(int CurrentPage, int PageSize);
}
