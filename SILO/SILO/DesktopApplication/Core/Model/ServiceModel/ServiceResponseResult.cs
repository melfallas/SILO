using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Model.ServiceModel
{
    public class ServiceResponseResult
    {
        public string type { get; set; }
        public string message { get; set; }
        public Object result { get; set; }
    }
}
