using HIS.RBAC;
using HIS.SettlementSystem;
using HIS.System_Administration;
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





    /// <summary>
    /// 病人性质
    /// </summary>
    public DbSet<NatureofPatient> NatureofPatients { get; set; }

    /// <summary>
    /// 收费模块表
    /// </summary>
    public DbSet<Chargingmodule> Chargingmodules { get; set; }
    /// <summary>
    /// 收费项目表
    /// </summary>
    public DbSet<Chargingprojects> Chargingprojects { get; set; }
    /// <summary>
    /// 发票配置表
    /// </summary>
    public DbSet<InvoiceConfiguration> InvoiceConfigurations { get; set; }

    /// <summary>
    /// 权限表
    /// </summary>
    public DbSet<Permissions> Permissionss { get; set; }
    /// <summary>
    /// 角色表
    /// </summary>
    public DbSet<Role> Roles { get; set; }
    /// <summary>
    /// 角色权限表
    /// </summary>
    public DbSet<RolePermissions> RolePermissionss { get; set; }
    /// <summary>
    /// 用户表
    /// </summary>
    public DbSet<User> Users { get; set; }
    /// <summary>
    /// 用户角色表
    /// </summary>
    public DbSet<UserRole> UserRole { get; set; }


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
