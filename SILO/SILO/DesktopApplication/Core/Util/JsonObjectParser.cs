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

        public JsonObjectParser(int pEntityType=1)
        {
            switch (pEntityType)
            {
                case COMPANY:
                    // Agregar campos a parsear para la entidad Company
                    this.fieldCollection.Add("id", "CPN_Id");
                    this.fieldCollection.Add("code", "CPN_Code");
                    this.fieldCollection.Add("displayName", "CPN_DisplayName");
                    this.fieldCollection.Add("description", "CPN_Description");
                    this.fieldCollection.Add("createDate", "CPN_CreateDate");
                    break;
                case OTHER:

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

    }
}
