using System;
namespace TaskManagementAPI.Services
{
	public interface IUserService
	{
		public Task<IList<Models.User>> GetAllUsers();
	}
}

