using Microsoft.EntityFrameworkCore;
using Nature_Hub_Server.Data;
using Nature_Hub_Server.Models;

namespace Nature_Hub_Server.Repo
{
    public class Tips : ITips
    {
        NatureProductsDbContext _repo;
        public Tips(NatureProductsDbContext repo)
        {
            _repo = repo;

        }

        public async Task<HealthTip> AddTip(HealthTip tip)
        {
            await _repo.HealthTips.AddAsync(tip);

            await _repo.SaveChangesAsync();

            return tip;
        }

        public async Task<bool> DeleteTip(int id)
        {
            var tip = await _repo.HealthTips.FindAsync(id);

            if (tip != null)
            {
                _repo.HealthTips.Remove(tip);
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
            var cat = await _repo.HealthTips.ToListAsync();

            var all = cat.Select(x => x.Category).Distinct();

            return all;
        }

        public async Task<ICollection<HealthTip>> GetAllTips()
        {
            var tips = await _repo.HealthTips.ToListAsync();

            if (tips != null)
            {
                return tips;
            }
            else
            {
                return new List<HealthTip>();
            }
        }

        public async Task<HealthTip> GetTipById(int id)
        {
            var tip = await _repo.HealthTips.FindAsync(id);
            if (tip != null)
            {
                return tip;
            }
            else
            {
                return null;
            }
        }

        public async Task<ICollection<HealthTip>> GetTipsByCategory(string category)
        {
            var catProducts = await _repo.HealthTips.Where(x => x.Category == category.ToLower()).ToListAsync();

            if (catProducts != null)
            {
                return catProducts;
            }
            else
            {
                return new List<HealthTip>();
            }
        }

      
        public async Task<HealthTip> UpdateTip(HealthTip Tip, int id)
        {
            if (Tip.TipId == id)
            {
                _repo.HealthTips.Update(Tip);
                await _repo.SaveChangesAsync();
                return Tip;
            }
            return null;

        }
    }
}
