using SILO.DesktopApplication.Core.Abstract.Generic;
using SILO.DesktopApplication.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Repositories
{
    class LotteryPrizeFactorRepository : GenericRepository<LPF_LotteryPrizeFactor, Object>
    {
        public LPF_LotteryPrizeFactor getByPointSaleAndGroup(long pSalePoint, long pGroup)
        {
            LPF_LotteryPrizeFactor prizeFactorResult = null;
            List<LPF_LotteryPrizeFactor> prizeFactorList = this.getAll()
                .Where(item =>(item.LPS_LotteryPointSale == pSalePoint) && (item.LDT_LotteryDrawType == pGroup)).ToList();
            if (prizeFactorList.Count > 0)
            {
                prizeFactorResult = prizeFactorList[0];
            }
            return prizeFactorResult;
        }

        // Método que registra la persistencia de una lista de objetos
        public void saveList(List<LPF_LotteryPrizeFactor> pEntityList)
        {
            foreach (LPF_LotteryPrizeFactor entity in pEntityList)
            {
                entity.SYS_SynchronyStatus = SystemConstants.SYNC_STATUS_COMPLETED;
                this.saveByPointSaleAndDraw(entity);
            }
        }


        public LPF_LotteryPrizeFactor saveByPointSaleAndDraw(LPF_LotteryPrizeFactor pPrizeFactor)
        {
            LPF_LotteryPrizeFactor findedEntity = null;
            using (var context = new SILOEntities())
            {
                if (pPrizeFactor.LPF_Id != 0)
                {
                    findedEntity = this.getByPointSaleAndGroup(pPrizeFactor.LPS_LotteryPointSale, pPrizeFactor.LDT_LotteryDrawType);
                    if (findedEntity == null)
                    {
                        // Si no existe la entidad, añadirla y guardar cambios
                        context.LPF_LotteryPrizeFactor.Add(pPrizeFactor);
                        context.SaveChanges();
                        findedEntity = pPrizeFactor;
                    }
                    else
                    {
                        long actualStatus = findedEntity.copy(pPrizeFactor);
                        // Validar estado de la entidad para determinar si se actualiza
                        if (actualStatus == SystemConstants.SYNC_STATUS_COMPLETED)
                        {
                            // Update solamente si el estado es completamente sincronizado
                            context.SaveChanges();
                        }
                    }
                }
            }
            return findedEntity;
        }


    }

}
