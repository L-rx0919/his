using DocumentFormat.OpenXml.Wordprocessing;
using HIS.Notice;
using HIS.SettlementSystem;
using HIS.System_Administration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.SettingManagement.EntityFrameworkCore;

namespace HIS.EntityFrameworkCore
{

    [ConnectionStringName("Default")]
    public class HISDbContext :
        AbpDbContext<HISDbContext>
    {

        public DbSet<SystemDept> SysDepts { get; set; }
        public DbSet<SystemUser> SysUsers { get; set; }
        public DbSet<SysDictData> SysDictDatas { get; set; }
        public DbSet<SysDict> SysDicts { get; set; }
        public DbSet<SysMenu> SysMenus { get; set; }


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
        /// 系统动态表
        /// </summary>
        public DbSet<SystemDynamics> SystemDynamics { get; set; }
        /// <summary>
        /// 收费项目组合表
        /// </summary>
        public DbSet<Itemscharged> Itemschargeds { get; set; }
        /// <summary>
        /// 财务发票表
        /// </summary>
        public DbSet<FinancialInvoices> financialInvoices { get; set; }
        /// <summary>
        /// 角色表
        /// </summary>
        public DbSet<Rolemanagements> Rolemanagements { get; set; }
        /// <summary>
        /// 系统菜单表
        /// </summary>
        public DbSet<SystemMenu> SystemMenus { get; set; }
        /// <summary>
        /// 科室医生表
        /// </summary>
        public DbSet<DepartmentDocto> DepartmentDoctos { get; set; }



        /// <summary>
        /// 病人一卡通信息表
        /// </summary>
        public DbSet<Patient_Card_Info> Patient_Card_Infos { get; set; }
        /// <summary>
        /// 挂号表表
        /// </summary>
        public DbSet<Registration> Registrations { get; set; }
        /// <summary>
        /// 门诊类型与医生排班表
        /// </summary>
        public DbSet<Clinic_type_schedule> Clinic_type_schedules { get; set; }
        /// <summary>
        /// 门诊类型与科室关联表
        /// </summary>
        public DbSet<Clinic_type_department> Clinic_type_departments { get; set; }
        /// <summary>
        /// 门诊类型表
        /// </summary>
        public DbSet<Clinic_type> Clinic_types { get; set; }
       /// <summary>
       /// 通知表
       /// </summary>
        public DbSet<SysNotice> SysNotices { get; set; }
        /// <summary>
        /// 用户通知表
        /// </summary>
        public DbSet<SysUserNotice> SysUserNotices { get; set; }

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

            builder.Entity<SystemDept>(b =>
            {
                b.ToTable(nameof(SystemDept).ToLowerInvariant ());
                b.Property(m => m.Name).HasMaxLength(100).IsRequired();
                b.Property(m => m.Code).HasMaxLength(100).IsRequired();
                b.Property(m => m.ParentId).IsRequired();
                b.Property(m => m.TreePath).HasMaxLength(255).IsRequired();
                b.Property(m => m.Sort);
                b.Property(m => m.Status).IsRequired();
                b.ConfigureByConvention();
            });

            builder.Entity<SystemUser>(b =>
            {
                b.ToTable(nameof(SystemUser).ToLowerInvariant());
                b.Property(m => m.Username).HasMaxLength(64).IsRequired();
                b.Property(m => m.Nickname).HasMaxLength(64).IsRequired();
                b.Property(m => m.Gender).IsRequired();
                b.Property(m => m.Password).HasMaxLength(100).IsRequired();
                b.Property(m => m.DeptId).IsRequired();
                b.Property(m => m.Avatar).HasMaxLength(255).IsRequired();
                b.Property(m => m.Mobile).HasMaxLength(20);
                b.Property(m => m.Status).IsRequired();
                b.Property(m => m.Email).HasMaxLength(128);
                b.ConfigureByConvention();
            });

            builder.Entity<SysMenu>(b =>
            {
                b.ToTable(nameof(SysMenu).ToLowerInvariant());
                b.Property(m => m.ParentId).IsRequired();
                b.Property(m => m.TreePath).HasMaxLength(255);
                b.Property(m => m.Name).HasMaxLength(64).IsRequired();
                b.Property(m => m.Type).IsRequired();
                b.Property(m => m.RouteName).HasMaxLength(255);
                b.Property(m => m.RoutePath).HasMaxLength(128);
                b.Property(m => m.Component).HasMaxLength(128);
                b.Property(m => m.Perm).HasMaxLength(128);

                // 忽略 Visible 属性
                b.Property(m => m.Visible).IsRequired();

                b.Property(m => m.Icon).HasMaxLength(64);
                b.Property(m => m.Redirect).HasMaxLength(128);
                b.ConfigureByConvention();
            });
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.LogTo(Console.WriteLine, new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting });
        //    base.OnConfiguring(optionsBuilder);
        //}
      
    }
}

