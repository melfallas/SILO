﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SILO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SILOEntities : DbContext
    {
        public SILOEntities()
            : base("name=SILOEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CPN_Company> CPN_Company { get; set; }
        public virtual DbSet<LDT_LotteryDrawType> LDT_LotteryDrawType { get; set; }
        public virtual DbSet<LND_ListNumberDetail> LND_ListNumberDetail { get; set; }
        public virtual DbSet<LNR_LotteryNumber> LNR_LotteryNumber { get; set; }
        public virtual DbSet<LPS_LotteryPointSale> LPS_LotteryPointSale { get; set; }
        public virtual DbSet<LTD_LotteryDraw> LTD_LotteryDraw { get; set; }
        public virtual DbSet<LTL_LotteryList> LTL_LotteryList { get; set; }
        public virtual DbSet<PSP_PointSaleParameter> PSP_PointSaleParameter { get; set; }
        public virtual DbSet<DNW_DrawNumberWinning> DNW_DrawNumberWinning { get; set; }
        public virtual DbSet<SYS_SynchronyStatus> SYS_SynchronyStatus { get; set; }
    }
}
