using HelpyAdmin.Data;
using HelpyAdmin.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HelpyAdmin.Repository
{
    public class Bills : IBills
    {
        private readonly IDbContextFactory<HelpyDbContext> _context;
        public Bills(IDbContextFactory<HelpyDbContext> context)
        {
            _context = context;
        }
        public async Task<List<Models.Bills>> GetAllBills()
        {
            try
            {
                await using var context = await _context.CreateDbContextAsync();
                var allbills = await context.Bills.ToListAsync();
                return allbills;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
