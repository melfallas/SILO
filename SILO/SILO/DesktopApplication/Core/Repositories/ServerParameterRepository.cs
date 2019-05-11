using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Repositories
{
    public class ServerParameterRepository
    {
        public List<SPR_ServerParameter> getAll()
        {
            List<SPR_ServerParameter> paramList = null;
            using (var context = new SILOEntities())
            {
                paramList = context.SPR_ServerParameter.ToList();
            }
            return paramList;
        }

        public string getParamValue(string pName)
        {
            SPR_ServerParameter findedParam = this.getByName(pName);
            return findedParam == null ? "" : findedParam.SPR_Value.Trim();
        }

        public SPR_ServerParameter getByName(string pName)
        {
            SPR_ServerParameter paramValue = null;
            try
            {
                using (var context = new SILOEntities())
                {
                    List<SPR_ServerParameter> paramList = context.SPR_ServerParameter
                        .Where(param => param.SPR_Name == pName).ToList();
                    if (paramList.Count > 0)
                    {
                        paramValue = paramList[0];
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return paramValue;
        }

        public void save(SPR_ServerParameter pParam)
        {
            SPR_ServerParameter parameter = null;
            using (var context = new SILOEntities())
            {
                List<SPR_ServerParameter> paramList = context.SPR_ServerParameter
                        .Where(param => param.SPR_Name == pParam.SPR_Name).ToList();
                if (paramList.Count > 0)
                {
                    parameter = paramList[0];
                }
                if (parameter == null)
                {
                    parameter = new SPR_ServerParameter();
                    parameter.SPR_Name = pParam.SPR_Name;
                    parameter.SPR_Value = pParam.SPR_Value;
                }
                else
                {
                    parameter.SPR_Value = pParam.SPR_Value;
                }
                context.SaveChanges();
            }
        }

    }
}
