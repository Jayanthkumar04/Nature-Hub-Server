using Nature_Hub_Server.Models;

namespace Nature_Hub_Server.Repo
{
    public interface ITips
    {
        Task<ICollection<HealthTip>> GetAllTips();

        Task<HealthTip> AddTip(HealthTip Tip);

        Task<HealthTip> UpdateTip(HealthTip Tip, int id);

        Task<ICollection<HealthTip>> GetTipsByCategory(string category);

        Task<HealthTip> GetTipById(int id);

        Task<bool> DeleteTip(int id);


        Task<IEnumerable<string>> GetAllCategories();
    }
}
