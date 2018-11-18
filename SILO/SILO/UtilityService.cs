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

        public static DataTable drawTypeDataTable(String idLabel, String valueLabel)
        {
            LotteryDrawTypeRepository lotteryDrawTypeReposytory = new LotteryDrawTypeRepository();
            List<LDT_LotteryDrawType> drawTypeList = lotteryDrawTypeReposytory.getAll();

            DataTable tabla = new DataTable();
            tabla.Columns.Add(idLabel);
            tabla.Columns.Add(valueLabel);
            // Opción por defecto
            DataRow row = tabla.NewRow();
            row[idLabel] = "0";
            row[valueLabel] = "SELECCIONE UN GRUPO";
            tabla.Rows.Add(row);
            // Llenado del ComboBox
            foreach (LDT_LotteryDrawType item in drawTypeList)
            {
                row = tabla.NewRow();
                row[idLabel] = item.LDT_Id;
                row[valueLabel] = item.LDT_Description;
                tabla.Rows.Add(row);
            }
            return tabla;
        }

    }
}
