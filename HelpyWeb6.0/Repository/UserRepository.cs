using Dapper;
using HelpyAdmin.Controllers.Helper;
using HelpyAdmin.Data;
using HelpyAdmin.Models;
using HelpyWebApi.Repository.Interface;
using HelpyAdmin.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HelpyWebApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory<HelpyDbContext> _context;

        public UserRepository(IDbContextFactory<HelpyDbContext> context)
        {
            _context = context;
        }
        public async Task<List<GetAllUserDetails>> GetAllUserDetailsAsync(FilterUserModel model, string csvSelectedItems)
        {
            await using var context = await _context.CreateDbContextAsync();
            var query = $"CALL GetUserDetails({model.userId},{model.MinAge},{model.MaxAge},{model.Gender},{model.Occupation},{model.BodyType},{model.Children},{model.Drinking},{model.Education},{model.FullName},{model.MinHeightInInches},{model.MaxHeightInInches},{model.Language},{model.RelationshipStatus},{model.Sexuality},{model.Smoking},{csvSelectedItems},{model.City},{model.Country},{model.Longitude},{model.Latitude},{model.LookingFor})";
            var result = await context.Set<GetAllUserDetails>()
                .FromSqlRaw(query) // Replace with actual parameters
                .ToListAsync();
            return result;
        }

        public async Task<List<UserDetails>> GetAllUsersAsync(string gender, string sexuality)
        {
            var query = "CALL GetAllUser(@inputGender, @inputSexuality)";
            var parameters = new
            {
                inputGender = gender ?? (object)DBNull.Value,
                inputSexuality = sexuality ?? (object)DBNull.Value
            };

            await using var context = await _context.CreateDbContextAsync();
            await using var connection = context.Database.GetDbConnection();

            return (await connection.QueryAsync<UserDetails>(query, parameters)).ToList();
        }
        public async Task<UserDetails> GetUserDetailByGuid(string uGuid)
        {
            var query = "CALL GetUserDetailByGuid(@inputuGuid)";
            var parameters = new
            {
                inputuGuid = uGuid ?? (object)DBNull.Value,
            };

            await using var context = await _context.CreateDbContextAsync();
            await using var connection = context.Database.GetDbConnection();

            // Fetch the data and select the first or default result
            var result = await connection.QueryAsync<UserDetails>(query, parameters);
            return result.FirstOrDefault(); // Ensure the result is a single UserDetails or null if none exist
        }
        public async Task<List<UserChatDetail>> GetChatsByUserIdAsync(int userId)
        {
            var query = "CALL GetChatsByUserId(@inputUserId)";
            var parameters = new
            {
                inputUserId = userId,
            };
            await using var context = await _context.CreateDbContextAsync();
            await using var connection = context.Database.GetDbConnection();
            // Fetch the data and select the first or default result
            return (await connection.QueryAsync<UserChatDetail>(query, parameters)).ToList();
        }
    }
}
