﻿using HIS.SettlementSystem;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;

namespace HIS.EntityFrameworkCore;


[ConnectionStringName("Default")]
public class HISDbContext :
    AbpDbContext<HISDbContext>
<<<<<<< HEAD

{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */
    /// <summary>
    /// 科室表
    /// </summary>
    public DbSet<Department> Departments { get; set; }

    /// <summary>
    /// 费用折扣表
    /// </summary>
    public DbSet<Discount> Discounts { get; set; }
    /// <summary>
    /// 医生表
    /// </summary>
    public DbSet<Doctor> Doctors { get; set; }
    /// <summary>
    /// 费用类别表
    /// </summary>
    public DbSet<Fee_Category> Fee_Category { get; set; }
    /// <summary>
    /// 费用明细表
    /// </summary>
    public DbSet<Fee_Detail> Fee_Details { get; set; }
    /// <summary>
    /// 费用项目表
    /// </summary>
    public DbSet<FeeItem> FeeItem { get; set; }
    /// <summary>
    /// 账单表
    /// </summary>
    public DbSet<Hospital_Bill> Hospital_Bills { get; set; }
    /// <summary>
    /// 住院记录表
    /// </summary>
    public DbSet<InpatientRecord> InpatientRecords { get; set; }
    /// <summary>
    /// 医保记录表
    /// </summary>
    public DbSet<Insurance_Record> Insurance_Records { get; set; }
    /// <summary>
    /// 患者信息表
    /// </summary>
    public DbSet<Patient> Patients { get; set; }
    /// <summary>
    /// 支付方式表
    /// </summary>
    public DbSet<Payment_Method> Payment_Methods { get; set; }
    /// <summary>
    /// 支付记录表
    /// </summary>
    public DbSet<Payment_Record> Payment_Records { get; set; }
    /// <summary>
    /// 处方表
    /// </summary>
    public DbSet<Receipt> Receipts { get; set; }
    /// <summary>
    /// 退费记录表
    /// </summary>
    public DbSet<Refund_Record> Refund_Records { get; set; }
    /// <summary>
    /// 结算表
    /// </summary>
    public DbSet<Settlement_Record> Settlement_Records { get; set; }




=======
{



    /// <summary>
    /// 科室
    /// </summary>
    public DbSet<Department> Departments { get; set; }
    /// <summary>
    /// 费用折扣
    /// </summary>
    public DbSet<Discount> Discounts { get; set; }
    /// <summary>
    /// 医生
    /// </summary>
    public DbSet<Doctor> Doctors { get; set; }
    /// <summary>
    /// 费用类别
    /// </summary>
    public DbSet<Fee_Category> Fee_Categorys { get; set; }
    /// <summary>
    /// 结算明细
    /// </summary>
    public DbSet<Fee_Detail> Fee_Details { get; set; }
    /// <summary>
    /// 退款记录
    /// </summary>
    public DbSet<Refund_Record> Refund_Records { get; set; }
    /// <summary>
    /// 票据
    /// </summary>
    public DbSet<Receipt> Receipts { get; set; }
    /// <summary>
    /// 支付方式
    /// </summary>
    public DbSet<Payment_Method> Payment_Methods { get; set; }
    /// <summary>
    /// 住院账单
    /// </summary>
    public DbSet<Hospital_Bill> Hospital_Bills { get; set; }
    /// <summary>
    /// 医保记录
    /// </summary>
    public DbSet<Insurance_Record> Insurance_Records { get; set; }
    /// <summary>
    /// 支付记录
    /// </summary>
    public DbSet<Payment_Record> Payment_Records { get; set; }
    /// <summary>
    /// 费用项目
    /// </summary>
    public DbSet<FeeItem> FeeItems { get; set; }
    /// <summary>
    /// 结算记录
    /// </summary>
    public DbSet<Settlement_Record> Settlement_Records { get; set; }
    /// <summary>
    /// 患者
    /// </summary>
    public DbSet<Patient> Patients { get; set; }
    /// <summary>
    /// 住院记录
    /// </summary>
    public DbSet<InpatientRecord> InpatientRecords { get; set; }
>>>>>>> f41e346e9416bb6bb0d45b64fef4c184f2d401c4
    public HISDbContext(DbContextOptions<HISDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);



        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();


    }
}
