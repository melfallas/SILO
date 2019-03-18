using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Repositories
{
    public class CompanyRepository
    {
        public CPN_Company getById(long pCompanyId)
        {
            CPN_Company findedCompany = null;
            using (var context = new SILOEntities())
            {
                if (pCompanyId != 0)
                {
                    findedCompany = context.CPN_Company.Find(pCompanyId);
                }
            }
            return findedCompany;
        }

        public CPN_Company save(CPN_Company pCompany)
        {
            CPN_Company findedCompany = null;
            using (var context = new SILOEntities())
            {
                if (pCompany.CPN_Id != 0)
                {
                    findedCompany = context.CPN_Company.Find(pCompany.CPN_Id);
                    if(findedCompany == null)
                    {
                        findedCompany = pCompany;
                        context.CPN_Company.Add(pCompany);
                    }
                    else
                    {
                        findedCompany.CPN_Code = pCompany.CPN_Code;
                        findedCompany.CPN_DisplayName = pCompany.CPN_DisplayName;
                        findedCompany.CPN_Description = pCompany.CPN_Description;
                    }
                    context.SaveChanges();
                }
            }
            return findedCompany;
        }

        public void saveList(List<CPN_Company> pCompanyList)
        {
            foreach (CPN_Company company in pCompanyList)
            {
                this.save(company);
            }
        }

        public void getCompanies()
        {
            using (var context = new SILOEntities())
            {
                var lista = context.CPN_Company.ToList();
                foreach (var item in lista)
                {
                    //Console.WriteLine(item.CPN_Code);
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
