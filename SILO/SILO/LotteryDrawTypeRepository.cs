using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO
{
    class LotteryDrawTypeRepository
    {
        public List<LDT_LotteryDrawType> getAll()
        {
            List<LDT_LotteryDrawType> drawTypeList = null;
            using (var context = new SILOEntities())
            {
                drawTypeList = context.LDT_LotteryDrawType.ToList();
            }
            return drawTypeList;
        }

        public LDT_LotteryDrawType getById(long pId)
        {
            LDT_LotteryDrawType drawType = null;
            using (var context = new SILOEntities())
            {
                drawType = context.LDT_LotteryDrawType.Find(pId);
            }
            return drawType;
        }
    }
}
