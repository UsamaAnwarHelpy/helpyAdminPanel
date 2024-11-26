namespace HelpyAdmin.Repository.Interface
{
    public interface IBills
    {
        Task<List<Models.Bills>> GetAllBills();
    }
}
