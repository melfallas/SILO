using SILO.Core.Constants;
using SILO.DesktopApplication.Core.Constants;
using SILO.DesktopApplication.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Services
{
    public class PointSaleService
    {
        public string getPointSaleInstance()
        {
            string posInstance = null;
            posInstance = UtilityService.getLocalParameterValue(ParameterConstants.POS_NAME_PARAM);
            posInstance = posInstance.Trim() == "" ? null : posInstance;
            return posInstance;
        }

        public LPS_LotteryPointSale getPointSale()
        {
            LotteryPointSaleRepository posRepository = new LotteryPointSaleRepository();
            // TODO: Validar si es número
            long posId = Convert.ToInt64(UtilityService.getLocalParameterValue(ParameterConstants.POS_NAME_PARAM));
            return posRepository.getById(posId);
        }

        public void initialize(long posId)
        {
            //PSP_PointSaleParameter parameter = new PSP_PointSaleParameter(ParameterConstants.POS_NAME_PARAM, posId.ToString());
            LPR_LocalParameter parameter = new LPR_LocalParameter();
            parameter.LPR_Name = ParameterConstants.POS_NAME_PARAM;
            parameter.LPR_Value = posId.ToString();
            LocalParameterRepository pointSaleParameterRepository = new LocalParameterRepository();
            pointSaleParameterRepository.save(parameter);
        }
    }
}
