﻿using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HIS.Data;
using Volo.Abp.DependencyInjection;

namespace HIS.EntityFrameworkCore;

public class EntityFrameworkCoreHISDbSchemaMigrator
    : IHISDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreHISDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    /// <summary>
    /// 迁移数据库
    /// </summary>
    /// <returns></returns>
    public async Task MigrateAsync()
    {
      

        await _serviceProvider
            .GetRequiredService<HISDbContext>()
            .Database
            .MigrateAsync();
    }
}
