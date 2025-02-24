using HIS.SettlementSystem;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;

namespace HIS.EntityFrameworkCore;


[ConnectionStringName("Default")]
public class HISDbContext :
    AbpDbContext<HISDbContext>
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
