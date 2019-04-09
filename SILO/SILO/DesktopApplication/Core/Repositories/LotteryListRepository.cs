using SILO.DesktopApplication.Core.Abstract.Generic;
using SILO.DesktopApplication.Core.Constants;
using SILO.DesktopApplication.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Repositories
{
    class LotteryListRepository : GenericRepository<LTL_LotteryList, Object>
    {
        /*
        public LTL_LotteryList getById(long pId) {
            LTL_LotteryList list = null;
            using (var context = new SILOEntities())
            {
                list = context.LTL_LotteryList.Find(pId);
            }
            return list;
        }
        */

        public List<LTL_LotteryList> getPosPendingTransactions() {
            return this.getAll().Where(
                item =>
                    item.LPS_LotteryPointSale == UtilityService.getPointSaleId()
                &&  item.SYS_SynchronyStatus == SystemConstants.SYNC_STATUS_PENDING_TO_SERVER
                ).ToList(); ;
        }

        public List<LND_ListNumberDetail> getListDetail(long pId)
        {
            List<LND_ListNumberDetail> numberList = null;
            using (var context = new SILOEntities())
            {
                if (pId != 0)
                {
                    // Obtener detalle de números pertenecientes a la lista
                    numberList = context.LND_ListNumberDetail.Where(item => item.LTL_LotteryList == pId).ToList();
                }
            }
            return numberList;
        }

        public List<LotteryTuple> getTupleListDetail(long pId) {
            List<LotteryTuple> tupleList = new List<LotteryTuple>();
            using (var context = new SILOEntities())
            {
                if (pId != 0)
                {
                    // Obtener detalle de números pertenecientes a la lista
                    List<LND_ListNumberDetail> numberList = context.LND_ListNumberDetail
                        .Where(item => item.LTL_LotteryList == pId).ToList();
                    // Transformar datos a lista de tuplas
                    tupleList = numberList.Select(
                        x => new LotteryTuple((x.LNR_LotteryNumber == 100 ? 0 : x.LNR_LotteryNumber), x.LND_SaleImport)
                        ).ToList();
                }
            }
            return tupleList;
        }


        public void updateList(LTL_LotteryList pList)
        {
            LTL_LotteryList list = null;
            using (var context = new SILOEntities())
            {
                list = context.LTL_LotteryList.Find(pList.LTL_Id);
                list.LTL_CreateDate = pList.LTL_CreateDate;
                list.LTL_CustomerName = pList.LTL_CustomerName;
                list.LLS_LotteryListStatus = pList.LLS_LotteryListStatus;
                list.SYS_SynchronyStatus = pList.SYS_SynchronyStatus;
                context.SaveChanges();
            }
        }


        public List<ListData> getListCollection(DateTime pDate, long pGroup)
        {
            string drawDate = pDate.ToString("yyyy-MM-dd") + " 00:00:00";
            List<ListData> listDataCollection = new List<ListData>();
            using (var context = new SILOEntities())
            {
                var query = "SELECT '0' || L.LPS_LotteryPointSale || '000' || L.LTL_Id AS global, '0' || L.LTL_Id AS id, L.LTL_CreateDate AS date, L.LTL_CustomerName AS name FROM LTL_LotteryList AS L INNER JOIN LTD_LotteryDraw AS D ON D.LTD_Id = L.LTD_LotteryDraw " 
                    + "WHERE D.LTD_CreateDate = '"+ drawDate + "' " 
                    + "AND D.LDT_LotteryDrawType = " + pGroup + " "
                    + "AND L.LLS_LotteryListStatus <> " + SystemConstants.LIST_STATUS_CANCELED + " "
                    + " ;";
                listDataCollection = context.Database.
                    SqlQuery<ListData>(query)
                    .ToList()
                    ;
            }
            return listDataCollection;
        }


        public List<WinningNumberInfo> getWinningNumbersList(LTD_LotteryDraw pDraw, string [] pWinningNumberArray)
        {
            List<WinningNumberInfo> listDataCollection = new List<WinningNumberInfo>();
            if (pDraw.LTD_Id != 0)
            {
                using (var context = new SILOEntities())
                {
                    long posId = UtilityService.getPointSale().LPS_Id;
                    var query = "SELECT LN.LNR_Number AS numberCode, N.LND_SaleImport AS saleImport, N.LND_SaleImport * 75 AS prizeImport, " 
                        + "L.LPS_LotteryPointSale AS salePoint, L.LTL_Id AS localId, L.LTL_CustomerName AS customerName"
                        + " FROM LTL_LotteryList AS L INNER JOIN LND_ListNumberDetail AS N ON N.LTL_LotteryList = L.LTL_Id " 
                        + "INNER JOIN LTD_LotteryDraw AS D ON D.LTD_Id = L.LTD_LotteryDraw INNER JOIN LNR_LotteryNumber AS LN ON LN.LNR_Id = N.LNR_LotteryNumber "
                        + "WHERE L.LPS_LotteryPointSale = " + posId + " "
                        + " AND D.LTD_Id = " + pDraw.LTD_Id + " AND LN.LNR_Number = '" + pWinningNumberArray[0] + "' ;";
                    listDataCollection = context.Database.
                        SqlQuery<WinningNumberInfo>(query)
                        .ToList()
                        ;
                    foreach (var item in listDataCollection)
                    {
                        //Console.WriteLine(item.prizeImport.ToString());
                        //Console.WriteLine(item.number + " " + item.import + " ");
                    }
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
                    SqlQuery<LotteryTuple>("SELECT LNR_LotteryNumber AS number, CAST(LND_SaleImport AS INTEGER) AS import FROM LND_ListNumberDetail  WHERE LTL_LotteryList = 1; ")
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

        public int[] getDrawListTotals(long posId, DateTime pDate, long pGroup, bool pOnlyPendingTransactions = false)
        {
            int[] importArray = new int[100];
            string drawDate = pDate.ToString("yyyy-MM-dd") + " 00:00:00";
            string pendingFilter = " AND L.SYS_SynchronyStatus = " + SystemConstants.SYNC_STATUS_PENDING_TO_SERVER + " ";
            Dictionary<int, int> importCollection = new Dictionary<int, int>();
            using (var context = new SILOEntities())
            {
                string query =
                    "SELECT N.LNR_LotteryNumber AS numberId, SUM(N.LND_SaleImport) AS totalImport "
                    + "FROM LTL_LotteryList AS L "
                    + "INNER JOIN LND_ListNumberDetail AS N ON N.LTL_LotteryList = L.LTL_Id "
                    + "INNER JOIN LTD_LotteryDraw AS D ON D.LTD_Id = L.LTD_LotteryDraw "
                    + "INNER JOIN LDT_LotteryDrawType AS T ON T.LDT_Id = D.LDT_LotteryDrawType "
                    + "WHERE L.LPS_LotteryPointSale = " + posId + " "
                    + "AND L.LLS_LotteryListStatus <> " + SystemConstants.LIST_STATUS_CANCELED + " "
                    + "AND D.LTD_CreateDate = '" + drawDate + "' "
                    + "AND D.LDT_LotteryDrawType = " + pGroup + " "
                    + (pOnlyPendingTransactions ? pendingFilter : "")
                    + "GROUP BY N.LNR_LotteryNumber "
                    + ";"
                    ;
                var listDetail = context.Database.SqlQuery<ListTotalRecord>(query).ToList();
                // Crear diccionario para realizar la conversión
                foreach (var item in listDetail)
                {
                    importCollection.Add(item.numberId, item.totalImport);
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

        //******************* Obtiene ListString de una Sucursal Específica *******************//
        
        public string getPosPendingTransactionsListString(DateTime pDate, long pGroup)
        {
            long salePointId = UtilityService.getPointSaleId();
            return this.getDrawListTotalCompressString(salePointId, pDate, pGroup, true);
        }

        public string getPosTotalListString(DateTime pDate, long pGroup)
        {
            long salePointId = UtilityService.getPointSaleId();
            return this.getDrawListTotalCompressString(salePointId, pDate, pGroup);
            /*
            string compressText = this.getDrawListTotalCompressString(salePointId, pDate, pGroup);
            for (int i = 0; i < 5; i++)
            {
                compressText += compressText;
            }
            return compressText;
            */
        }

        public string getDrawListTotalCompressString(long pSalePointId, DateTime pDate, long pGroup, bool pOnlyPendingTransactions = false)
        {
            string totalString = "";
            int[] importArray = new int[100];
            // Obtener colección con totales de números y su importe
            Dictionary<int, int> numberImportCollection = getDrawListTotalCollection(pSalePointId, pDate, pGroup, pOnlyPendingTransactions);
            // Construir hilera de números e importes comprimida
            for (int i = 0; i < importArray.Length; i++)
            {
                int importValue = 0;
                int numberId = (i == 0 ? 100 : i);
                if (numberImportCollection.TryGetValue(numberId, out importValue))
                {
                    totalString += UtilityService.fillString(i.ToString(), 2, "0") + "" + UtilityService.compressNumberString(importValue.ToString()) + "N";
                }
            }
            return totalString;
        }

        public Dictionary<int, int> getDrawListTotalCollection(long pSalePointId, DateTime pDate, long pGroup, bool pOnlyPendingTransactions = false)
        {
            string aditionalQueryFilters = " ";
            int[] importArray = new int[100];
            //string drawDate = pDate.ToString("yyyy-MM-dd") + " 00:00:00";
            Dictionary<int, int> importCollection = new Dictionary<int, int>();
            // Verificar parámetros para aplicar filtros
            if (pDate == null)
            {
                if (pGroup != 0)
                {
                    aditionalQueryFilters = " AND D.LDT_LotteryDrawType = " + pGroup + " ";
                }
            }
            else
            {
                if (pGroup == 0)
                {
                    aditionalQueryFilters = " AND D.LTD_CreateDate = '" + pDate.ToString("yyyy-MM-dd") + " 00:00:00' ";
                }
                else
                {
                    aditionalQueryFilters = " AND D.LDT_LotteryDrawType = " + pGroup + " ";
                    aditionalQueryFilters += " AND D.LTD_CreateDate = '" + pDate.ToString("yyyy-MM-dd") + " 00:00:00' ";
                }
            }
            // Verificar si se requieren solo transacciones pendientes
            if (pOnlyPendingTransactions)
            {
                aditionalQueryFilters += " AND L.SYS_SynchronyStatus <> " + SystemConstants.SYNC_STATUS_PENDING_TO_SERVER + " ";
            }
            // Aplicar el query para obtener los datos
            using (var context = new SILOEntities())
            {
                string query =
                    "SELECT N.LNR_LotteryNumber AS numberId, SUM(N.LND_SaleImport) AS totalImport "
                    + "FROM LTL_LotteryList AS L "
                    + "INNER JOIN LND_ListNumberDetail AS N ON N.LTL_LotteryList = L.LTL_Id "
                    + "INNER JOIN LTD_LotteryDraw AS D ON D.LTD_Id = L.LTD_LotteryDraw "
                    + "INNER JOIN LDT_LotteryDrawType AS T ON T.LDT_Id = D.LDT_LotteryDrawType "
                    + "WHERE L.LPS_LotteryPointSale = " + pSalePointId + " "
                    + aditionalQueryFilters
                    + "AND L.LLS_LotteryListStatus <> " + SystemConstants.LIST_STATUS_CANCELED + " "
                    + "GROUP BY N.LNR_LotteryNumber "
                    + ";"
                    ;
                var listDetail = context.Database.SqlQuery<ListTotalRecord>(query).ToList();
                // Crear diccionario para realizar la conversión
                foreach (var item in listDetail)
                {
                    importCollection.Add(item.numberId, item.totalImport);
                }
            }
            return importCollection;
        }

        /*
        public string getDrawListTotalString()
        {
            string totalString = "";
            int[] importArray = new int[100];
            //string drawDate = pDate.ToString("yyyy-MM-dd") + " 00:00:00";
            // Llenar el array
            for (int i = 0; i < importArray.Length; i++)
            {
                int importValue = 0;
                int numberId = (i == 0 ? 100 : i);
                if (getDrawListTotalCollection().TryGetValue(numberId, out importValue))
                {
                    totalString += i + "S" + importValue + "N";
                }
            }
            return totalString;
        }
        */

    }
}
