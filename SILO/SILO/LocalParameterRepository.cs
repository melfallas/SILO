using SILO.DesktopApplication.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO
{
    class LocalParameterRepository
    {
        public List<LPR_LocalParameter> getAll()
        {
            List<LPR_LocalParameter> paramList = null;
            using (var context = new SILOEntities())
            {
                paramList = context.LPR_LocalParameter.ToList();
            }
            return paramList;
        }

        public string getParamValue(string pName)
        {
            LPR_LocalParameter findedParam = this.getByName(pName);
            return findedParam == null ? "" : findedParam.LPR_Value;
        }

        public LPR_LocalParameter getByName(string pName)
        {
            LPR_LocalParameter paramValue = null;
            try
            {
                using (var context = new SILOEntities())
                {
                    List<LPR_LocalParameter> paramList = context.LPR_LocalParameter.Where(param => param.LPR_Name == pName).ToList();
                    if (paramList.Count > 0)
                    {
                        paramValue = paramList[0];
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
            
            return paramValue;
        }        

        public void save(LPR_LocalParameter pPosParam)
        {
            LPR_LocalParameter parameter = null;
            using (var context = new SILOEntities())
            {
                parameter = context.LPR_LocalParameter.Find(pPosParam.LPR_Name);
                if(parameter == null)
                {
                    //parameter = new LPR_LocalParameter(pPosParam.LPR_Name, pPosParam.LPR_Value);
                    parameter = new LPR_LocalParameter();
                    parameter.LPR_Name = pPosParam.LPR_Name;
                    parameter.LPR_Value = pPosParam.LPR_Value;
                    //parameter.LPR_Name = ParameterConstants.POS_NAME_PARAM;
                    // parameter.LPR_Value = posId.ToString();
                }
                else
                {
                    parameter.LPR_Value = pPosParam.LPR_Value;
                }
                context.SaveChanges();
            }
        }


    }
}
