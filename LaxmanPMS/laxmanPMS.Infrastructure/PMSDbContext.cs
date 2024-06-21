﻿using laxmanPMS.Infrastructure.Entity_Configuration;
using laxmanPMS.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laxmanPMS.Infrastructure
{
    public class PMSDbContext:DbContext
    {
        public PMSDbContext(DbContextOptions<PMSDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder Builder)
        {
            Builder.ApplyConfiguration(new CategoryConfiguration());
            Builder.ApplyConfiguration(new ProductConfiguration());
  
        }
    }
 }
      
   

