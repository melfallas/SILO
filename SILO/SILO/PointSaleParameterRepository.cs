using SILO.DesktopApplication.Core.Constants;
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
            try
            {
                using (var context = new SILOEntities())
                {
                    paramValue = context.PSP_PointSaleParameter.Find(pName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return paramValue;
        }

        public void save(PSP_PointSaleParameter pPosParam)
        {
            PSP_PointSaleParameter parameter = null;
            using (var context = new SILOEntities())
            {
                parameter = context.PSP_PointSaleParameter.Find(pPosParam.PSP_Name);
                if(parameter == null)
                {
                    //parameter = new PSP_PointSaleParameter(pPosParam.PSP_Name, pPosParam.PSP_Value);
                    parameter = new PSP_PointSaleParameter();
                    parameter.PSP_Name = pPosParam.PSP_Name;
                    parameter.PSP_Value = pPosParam.PSP_Value;
                    //parameter.PSP_Name = ParameterConstants.POS_NAME_PARAM;
                    // parameter.PSP_Value = posId.ToString();
                }
                else
                {
                    parameter.PSP_Value = pPosParam.PSP_Value;
                }
                context.SaveChanges();
            }
        }


    }
}
