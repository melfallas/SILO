using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Util
{
    public class JsonObjectParser
    {
        private Dictionary<string, string> fieldCollection = new Dictionary<string, string>();

        public const int COMPANY = 1;
        public const int OTHER = 999;

        public JsonObjectParser(int pEntityType)
        {
            switch (pEntityType)
            {
                case (int)EntityType.ServerParam:
                    // Agregar campos a parsear para la entidad Company
                    this.fieldCollection.Add("id", "SPR_Id");
                    this.fieldCollection.Add("name", "SPR_Name");
                    this.fieldCollection.Add("value", "SPR_Value");
                    break;
                case (int)EntityType.Company:
                    // Agregar campos a parsear para la entidad Company
                    this.fieldCollection.Add("id", "CPN_Id");
                    this.fieldCollection.Add("code", "CPN_Code");
                    this.fieldCollection.Add("displayName", "CPN_DisplayName");
                    this.fieldCollection.Add("description", "CPN_Description");
                    this.fieldCollection.Add("createDate", "CPN_CreateDate");
                    break;
                case (int)EntityType.PointSale:
                    this.fieldCollection.Add("id", "LPS_Id");
                    this.fieldCollection.Add("code", "LPS_Code");
                    this.fieldCollection.Add("displayName", "LPS_DisplayName");
                    this.fieldCollection.Add("description", "LPS_Description");
                    this.fieldCollection.Add("company", "CPN_Company");
                    this.fieldCollection.Add("counter", "LPS_Counter");
                    this.fieldCollection.Add("isActive", "LPS_IsActive");
                    this.fieldCollection.Add("synchronyStatus", "SYS_SynchronyStatus");
                    this.fieldCollection.Add("createDate", "LPS_CreateDate");
                    break;
                case (int)EntityType.UserRole:
                    this.fieldCollection.Add("id", "USR_Id");
                    this.fieldCollection.Add("code", "USR_Code");
                    this.fieldCollection.Add("displayName", "USR_DisplayName");
                    this.fieldCollection.Add("description", "USR_Description");
                    this.fieldCollection.Add("createDate", "USR_CreateDate");
                    break;
                case (int)EntityType.ApplicationUser:
                    this.fieldCollection.Add("id", "AUS_Id");
                    this.fieldCollection.Add("username", "AUS_Username");
                    this.fieldCollection.Add("password", "AUS_Password");
                    this.fieldCollection.Add("userRole", "USR_UserRole");
                    this.fieldCollection.Add("lotteryPointSale", "LPS_LotteryPointSale");
                    this.fieldCollection.Add("isActive", "AUS_IsActive");
                    this.fieldCollection.Add("createDate", "AUS_CreateDate");
                    break;
                case (int)EntityType.PrizeFactor:
                    this.fieldCollection.Add("id", "LPF_Id");
                    this.fieldCollection.Add("lotteryDrawType", "LDT_LotteryDrawType");
                    this.fieldCollection.Add("lotteryPointSale", "LPS_LotteryPointSale");
                    this.fieldCollection.Add("firtsPrizeFactor", "LPF_FirtsPrizeFactor");
                    this.fieldCollection.Add("secondPrizeFactor", "LPF_SecondPrizeFactor");
                    this.fieldCollection.Add("thirdPrizeFactor", "LPF_ThirdPrizeFactor");
                    this.fieldCollection.Add("synchronyStatus", "SYS_SynchronyStatus");
                    break;
                case (int)EntityType.LotteryNumber:
                    this.fieldCollection.Add("id", "LNR_Id");
                    this.fieldCollection.Add("number", "LNR_Number");
                    this.fieldCollection.Add("isProhibited", "LNR_IsProhibited");
                    //this.fieldCollection.Add("synchronyStatus", "SYS_SynchronyStatus");
                    break;
                case (int)EntityType.DrawType:
                    this.fieldCollection.Add("id", "LDT_Id");
                    this.fieldCollection.Add("code", "LDT_Code");
                    this.fieldCollection.Add("displayName", "LDT_DisplayName");
                    this.fieldCollection.Add("description", "LDT_Description");
                    //this.fieldCollection.Add("synchronyStatus", "SYS_SynchronyStatus");
                    break;
                case (int)EntityType.Other:

                    break;
                default:
                    break;
            }
        }

        public string parse(string pJsonString)
        {
            string jsonStringParsed = pJsonString;
            foreach (var item in this.fieldCollection)
            {
                jsonStringParsed = jsonStringParsed.Replace(item.Key, item.Value);
            }
            return jsonStringParsed;
        }

        public void changeJsonProp(JToken pToken, string pPropName)
        {
            long companyId = long.Parse(getJsonProp(getJsonProp(pToken, pPropName), "id").ToString());
            this.setJsonProp(pToken, pPropName, companyId);
        }

        public JToken getJsonProp(JToken pToken, string pPropName)
        {
            var itemProperties = pToken.Children<JProperty>();
            var myElement = itemProperties.FirstOrDefault(x => x.Name == pPropName);
            var myElementValue = myElement.Value;
            return myElementValue;
        }

        public void setJsonProp(JToken pToken, string pPropName, long pNewValue)
        {
            var itemProperties = pToken.Children<JProperty>();
            var myElement = itemProperties.FirstOrDefault(x => x.Name == pPropName);
            myElement.Value = pNewValue;
        }

    }
}
