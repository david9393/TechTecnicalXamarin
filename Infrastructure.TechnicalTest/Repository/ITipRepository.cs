using Infrastructure.TechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.TechnicalTest.Repository
{
    public interface ITipRepository
    {
        Task<List<TipModel>> GetTipsAync();
        Task<int> AddTipAsync(TipModel tip);
        Task<int> UpdateTipAsync(TipModel tip);
        Task<int> DeleteTipAsync(TipModel tip);
    }
}
