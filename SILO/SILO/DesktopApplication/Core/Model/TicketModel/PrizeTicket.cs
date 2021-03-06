﻿using SILO.DesktopApplication.Core.Model.NumberModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SILO.DesktopApplication.Core.Model.TicketModel
{
    public class PrizeTicket
    {
        public string companyName { get; set; }
        public string title { get; set; }
        public string pointSaleName { get; set; }
        public string userName { get; set; }
        public string drawTypeCode { get; set; }
        public DateTime drawDate { get; set; }
        public DateTime createDate { get; set; }
        public string[] winnerNumbers { get; set; }
        public List<WinningNumberInfo> listWinningInfo { get; set; }
        public double[] prizeFactorArray { get; set; }


        public PrizeTicket()
        {
            this.prizeFactorArray = new double[3];
            for (int i = 0; i < this.prizeFactorArray.Length; i++)
            {
                this.prizeFactorArray[i] = 0;
            }
        }

        public long getTotalSaleImport()
        {
            long totalImport = 0;
            foreach (WinningNumberInfo winningInfo in this.listWinningInfo)
            {
                totalImport += Convert.ToInt64(winningInfo.saleImport);
            }
            return totalImport;
        }

        public long getTotalPrizeImport()
        {
            long totalImport = 0;
            foreach (WinningNumberInfo winningInfo in this.listWinningInfo)
            {
                totalImport += Convert.ToInt64(winningInfo.prizeImport);
            }
            return totalImport;
        }
    }
}
