using DocumentFormat.OpenXml.Wordprocessing;
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

                // ºöÂÔ Visible ÊôÐÔ
                b.Property(m => m.Visible).IsRequired();

                b.Property(m => m.Icon).HasMaxLength(64);
                b.Property(m => m.Redirect).HasMaxLength(128);
                b.ConfigureByConvention();
            });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine, new[] { Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.CommandExecuting });
            base.OnConfiguring(optionsBuilder);
        }
      
    }
}

