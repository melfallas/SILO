using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO
{
    public static class UtilityService
    {
        public static DataTable buildDataTable() {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("id");
            tabla.Columns.Add("display");

            DataRow row = tabla.NewRow();
            row["id"] = "0";
            row["display"] = "Seleccione un grupo";
            tabla.Rows.Add(row);

            row = tabla.NewRow();
            row["id"] = "1";
            row["display"] = "Día";
            tabla.Rows.Add(row);
            row = tabla.NewRow();
            row["id"] = "2";
            row["display"] = "Noche";
            tabla.Rows.Add(row);
            return tabla;
        }

    }
}
