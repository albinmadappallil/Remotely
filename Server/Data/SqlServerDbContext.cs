﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tess.Server.Data
{
    public class SqlServerDbContext : AppDb
    {
        private readonly IConfiguration _configuration;

        public SqlServerDbContext(DbContextOptions context, IConfiguration configuration)
            : base(context)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("SQLServer"));
            base.OnConfiguring(options);
        }
    }
}
