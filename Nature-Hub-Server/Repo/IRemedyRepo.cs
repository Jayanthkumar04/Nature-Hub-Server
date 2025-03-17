using Nature_Hub_Server.Models;

namespace Nature_Hub_Server.Repo
{
    public interface IRemedyRepo
    {
        Task<ICollection<Remedy>> GetAllRemedy();

        Task<Remedy> AddRemedy(Remedy Tip);

        Task<Remedy> UpdateRemedy(Remedy Tip, int id);

        Task<ICollection<Remedy>> GetRemedyByCategory(string category);

        Task<Remedy> GetRemedyById(int id);

        Task<bool> DeleteRemedy(int id);


        Task<IEnumerable<string>> GetAllCategories();

    }
}
