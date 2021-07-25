using Infrastructure.TechnicalTest.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.TechnicalTest.Tips
{
    public interface ITip
    {
        BaseOut AddNewTip(TipModel tip);
        Task<int> UpdateTip(TipModel tip);
        Task<int> DeleteTip(TipModel tip);
        Task<List<TipModel>> GetAllTip();
    }
}
