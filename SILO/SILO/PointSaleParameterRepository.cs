using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO
{
    class PointSaleParameterRepository
    {
        public List<PSP_PointSaleParameter> getAll()
        {
            List<PSP_PointSaleParameter> paramList = null;
            using (var context = new SILOEntities())
            {
                paramList = context.PSP_PointSaleParameter.ToList();
            }
            return paramList;
        }

        public PSP_PointSaleParameter getByName(string pName)
        {
            PSP_PointSaleParameter paramValue = null;
            using (var context = new SILOEntities())
            {
                paramValue = context.PSP_PointSaleParameter.Find(pName);
            }
            return paramValue;
        }


    }
}
