﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Economizar.Models
{
    public class EconomizarContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public EconomizarContext() : base("name=EconomizarContext")
        {
        }

        public System.Data.Entity.DbSet<Economizar.Models.Supermercado> Supermercadoes { get; set; }

        public System.Data.Entity.DbSet<Economizar.Models.Item> Items { get; set; }

        public System.Data.Entity.DbSet<Economizar.Models.Compra> Compras { get; set; }
    }
}
