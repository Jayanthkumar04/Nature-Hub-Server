using Microsoft.EntityFrameworkCore;
using Nature_Hub_Server.Data;
using Nature_Hub_Server.Models;

namespace Nature_Hub_Server.Repo
{
    public class RemedyRepo : IRemedyRepo
    {
        NatureProductsDbContext _repo;
        public RemedyRepo(NatureProductsDbContext repo)
        {
            this._repo = repo;
            
        }
        public async Task<Remedy> AddRemedy(Remedy Tip)
        {
            await _repo.Remedies.AddAsync(Tip);

            await _repo.SaveChangesAsync();

            return Tip;
        }

        public async Task<bool> DeleteRemedy(int id)
        {
            var tip = await _repo.Remedies.FindAsync(id);

            if (tip != null)
            {
                _repo.Remedies.Remove(tip);
                await _repo.SaveChangesAsync();
                return true;
            }

            else
            {
                return false;

            }
        }

        public async Task<IEnumerable<string>> GetAllCategories()
        {
            var cat = await _repo.Remedies.ToListAsync();

            var all = cat.Select(x => x.Category).Distinct();

            return all;

        }

        public async Task<ICollection<Remedy>> GetAllRemedy()
        {
            var tips = await _repo.Remedies.ToListAsync();

            if (tips != null)
            {
                return tips;
            }
            else
            {
                return new List<Remedy>();
            }
        }

        public async Task<ICollection<Remedy>> GetRemedyByCategory(string category)
        {
            var catProducts = await _repo.Remedies.Where(x => x.Category == category.ToLower()).ToListAsync();

            if (catProducts != null)
            {
                return catProducts;
            }
            else
            {
                return new List<Remedy>();
            }
        }

        public async Task<Remedy> GetRemedyById(int id)
        {
            var tip = await _repo.Remedies.FindAsync(id);
            if (tip != null)
            {
                return tip;
            }
            else
            {
                return null;
            }
        }

        public async Task<Remedy> UpdateRemedy(Remedy Tip, int id)
        {
            if (Tip.RemedyId == id)
            {
                _repo.Remedies.Update(Tip);
                await _repo.SaveChangesAsync();
                return Tip;
            }
            return null;
        }
    }
}
