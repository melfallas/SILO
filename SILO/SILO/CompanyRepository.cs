using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO
{
    class CompanyRepository
    {

        public void getCompanies() {
            using (var context = new SILOEntities())
            {
                var lista = context.CPN_Company.ToList();
                foreach (var item in lista)
                {
                    Console.WriteLine(item.CPN_Code);
                }
                /*
                //var nombres = context.CPN_Company.SqlQuery("SELECT *, getTicketId(1) FROM CPN_Company").ToList();
                var nombres = context.CPN_Company.SqlQuery("SELECT * FROM CPN_Company").ToList();

                foreach (var item in nombres)
                {
                    Console.WriteLine(item.ToString());
                }

                nombres = context.CPN_Company.SqlQuery("SELECT * FROM CPN_Company").ToList();

                foreach (var item in nombres)
                {
                    Console.WriteLine(item.ToString());
                }
                */
            }
        }

    }
}
