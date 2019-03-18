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
            setJsonProp(pToken, pPropName, companyId);
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
