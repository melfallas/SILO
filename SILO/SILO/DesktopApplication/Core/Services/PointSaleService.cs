using SILO.Core.Constants;
using SILO.DesktopApplication.Core.Constants;
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
            posInstance = UtilityService.getPointSaleParameterValue(ParameterConstants.POS_NAME_PARAM);
            posInstance = posInstance.Trim() == "" ? null : posInstance;
            return posInstance;
        }

        public LPS_LotteryPointSale getPointSale()
        {
            LotteryPointSaleRepository posRepository = new LotteryPointSaleRepository();
            // TODO: Validar si es número
            long posId = Convert.ToInt64(UtilityService.getPointSaleParameter(ParameterConstants.POS_NAME_PARAM).PSP_Value);
            return posRepository.getById(posId);
        }

        public void initialize(long posId)
        {
            //PSP_PointSaleParameter parameter = new PSP_PointSaleParameter(ParameterConstants.POS_NAME_PARAM, posId.ToString());
            PSP_PointSaleParameter parameter = new PSP_PointSaleParameter();
            parameter.PSP_Name = ParameterConstants.POS_NAME_PARAM;
            parameter.PSP_Value = posId.ToString();
            PointSaleParameterRepository pointSaleParameterRepository = new PointSaleParameterRepository();
            pointSaleParameterRepository.save(parameter);
        }
    }
}
