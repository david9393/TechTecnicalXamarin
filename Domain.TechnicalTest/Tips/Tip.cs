using Infrastructure.TechnicalTest.Models;
using Infrastructure.TechnicalTest.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.TechnicalTest.Tips
{
    public class Tip : ITip
    {
        private readonly ITipRepository _tipRepository;

        public Tip(ITipRepository tipRepository)
        {
            _tipRepository = tipRepository;
        }

        public BaseOut AddNewTip(TipModel tip)
        {
            BaseOut baseOut = new BaseOut();
            if (tip.Titulo==null || tip.Titulo.Length == 0)
            {
                baseOut.Status = false;
                baseOut.Error = "Ingrese un titulo valido";
                return baseOut;
            }
            if (tip.Id > 0)
            {
                _tipRepository.UpdateTipAsync(tip);
            }
            else
            {
                _tipRepository.AddTipAsync(tip);
            }
            
            baseOut.Status = true;
            return baseOut;
        }
        public Task<int> UpdateTip(TipModel tip)
        {
            return _tipRepository.UpdateTipAsync(tip);
        }
        public Task<int> DeleteTip(TipModel tip)
        {
            return _tipRepository.DeleteTipAsync(tip);
        }
        public Task<List<TipModel>> GetAllTip()
        {
            return _tipRepository.GetTipsAync();
        }
    }
}
