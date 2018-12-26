﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO
{
    class LotteryListRepository
    {
        public LTL_LotteryList getById(long pId) {
            LTL_LotteryList list = null;
            using (var context = new SILOEntities())
            {
                list = context.LTL_LotteryList.Find(pId);
            }
            return list;
        }


        public List<LotteryTuple> getListDetail(long pId) {
            List<LotteryTuple> tupleList = new List<LotteryTuple>();
            using (var context = new SILOEntities())
            {
                if (pId != 0)
                {
                    // Obtener detalle de números pertenecientes a la lista
                    List<LND_ListNumberDetail> numberList = context.LND_ListNumberDetail
                        .Where(item => item.LTL_LotteryList == pId).ToList();
                    // Transformar datos a lista de tuplas
                    tupleList = numberList.Select(x => new LotteryTuple(x.LNR_LotteryNumber, x.LND_Import)).ToList();
                }
            }
            return tupleList;
        }


        public List<ListData> getListCollection(DateTime pDate, long pGroup)
        {
            string drawDate = pDate.ToString("yyyy-MM-dd") + " 00:00:00";
            List<ListData> listDataCollection = new List<ListData>();
            using (var context = new SILOEntities())
            {
                var query = "SELECT '0' || L.LPS_LotteryPointSale || '000' || L.LTL_Id AS global, '0' || L.LTL_Id AS id, L.LTL_CreateDate AS date, L.LTL_CustomerName AS name FROM LTL_LotteryList AS L INNER JOIN LTD_LotteryDraw AS D ON D.LTD_Id = L.LTD_LotteryDraw " 
                    + "WHERE D.LTD_CreateDate = '"+ drawDate + "' " 
                    + "AND D.LDT_LotteryDrawType = " + pGroup + " ;";
                listDataCollection = context.Database.
                    SqlQuery<ListData>(query)
                    .ToList()
                    ;
                foreach (var item in listDataCollection)
                {
                    Console.WriteLine(item.global.ToString());
                    //Console.WriteLine(item.number + " " + item.import + " ");
                }
            }
            return listDataCollection;
        }



        /*
        public void getListDetail()
        {
            //var listDetail = null;
            using (var context = new SILOEntities())
            {
                var listDetail = context.Database.
                    SqlQuery<LotteryTuple>("SELECT LNR_LotteryNumber AS number, CAST(LND_Import AS INTEGER) AS import FROM LND_ListNumberDetail  WHERE LTL_LotteryList = 1; ")
                    .ToList()
                    ;
                foreach (var item in listDetail)
                {
                    Console.WriteLine(item.ToString());
                    Console.WriteLine(item.number + " " + item.import + " ");
                }
            }
        }
        */


        public int[] getDrawListTotals()
        {
            int[] importArray = new int[100];
            Dictionary<int, int> importCollection = new Dictionary<int, int>();
            using (var context = new SILOEntities())
            {
                var listDetail = context.Database.
                    SqlQuery<ListTotalRecord>
                    ("SELECT N.LNR_LotteryNumber AS numberId, SUM(N.LND_Import) AS totalImport "
                    + "FROM LTL_LotteryList AS L "
                    + "INNER JOIN LND_ListNumberDetail AS N ON N.LTL_LotteryList = L.LTL_Id " 
                    + "INNER JOIN LTD_LotteryDraw AS D ON D.LTD_Id = L.LTD_LotteryDraw " 
                    + "INNER JOIN LDT_LotteryDrawType AS T ON T.LDT_Id = D.LDT_LotteryDrawType " 
                    + "WHERE L.LPS_LotteryPointSale = 1 AND D.LTD_CreateDate = '2018-12-24 00:00:00' " 
                    + "AND D.LDT_LotteryDrawType = 2 GROUP BY N.LNR_LotteryNumber ;"
                    )
                    .ToList()
                    ;
                // Crear diccionario para realizar la conversión
                foreach (var item in listDetail)
                {
                    importCollection.Add(item.numberId, item.totalImport);
                    Console.WriteLine(item.numberId.ToString() + " - " + item.totalImport);
                    //Console.WriteLine(item.number + " " + item.import + " ");
                }
            }
            // Llenar el array
            for (int i = 0; i < importArray.Length; i++)
            {
                int importValue = 0;
                int numberId = (i == 0 ? 100 : i);
                if (importCollection.TryGetValue(numberId, out importValue))
                {
                    importArray[i] = importValue;
                }
                else
                {
                    importArray[i] = 0;
                }
            }
            return importArray;
        }

    }
}
