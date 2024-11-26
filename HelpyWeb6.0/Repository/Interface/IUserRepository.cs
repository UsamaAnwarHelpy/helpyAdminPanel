using HelpyAdmin.Models;
using HelpyAdmin.ViewModel;

namespace HelpyWebApi.Repository.Interface
{
    public interface IUserRepository
    {
        Task<List<GetAllUserDetails>> GetAllUserDetailsAsync(FilterUserModel model, string csvSelectedItems);
        Task<List<UserDetails>> GetAllUsersAsync(string gender, string sexuality);
        Task<UserDetails> GetUserDetailByGuid(string uGuid);
        Task<List<UserChatDetail>> GetChatsByUserIdAsync(int userId);
    }
}
