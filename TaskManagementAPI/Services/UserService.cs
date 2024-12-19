using System;
using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Services
{
	public class UserService : IUserService
	{
        private readonly TaskManagementDataContext _context;

        public UserService(TaskManagementDataContext context)
        {
            _context = context;
        }

        public async Task<IList<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }
    }
}

