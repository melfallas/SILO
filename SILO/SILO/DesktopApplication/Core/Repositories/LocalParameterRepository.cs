﻿using SILO.DesktopApplication.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Repositories
{
    public class LocalParameterRepository
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
                    List<LPR_LocalParameter> paramList = context.LPR_LocalParameter
                        .Where(param => param.LPR_Name == pName).ToList();
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

        public void save(LPR_LocalParameter pParam)
        {
            LPR_LocalParameter parameter = null;
            using (var context = new SILOEntities())
            {
                List<LPR_LocalParameter> paramList = context.LPR_LocalParameter
                        .Where(param => param.LPR_Name == pParam.LPR_Name).ToList();
                if (paramList.Count > 0)
                {
                    parameter = paramList[0];
                }
                if(parameter == null)
                {
                    parameter = new LPR_LocalParameter();
                    parameter.LPR_Name = pParam.LPR_Name;
                    parameter.LPR_Value = pParam.LPR_Value;
                    parameter.LPT_LocalParameterType = pParam.LPT_LocalParameterType;
                    context.LPR_LocalParameter.Add(parameter);
                }
                else
                {
                    parameter.LPT_LocalParameterType = pParam.LPT_LocalParameterType;
                    parameter.LPR_Value = pParam.LPR_Value;
                }
                context.SaveChanges();
            }
        }


    }
}
