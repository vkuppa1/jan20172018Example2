﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional NameSpaces
using System.Data.Entity;
using Chinook.Data.Entities;
#endregion

namespace ChinookSystem.DAL
{
    internal class ChinookContext:DbContext 
    {
        public ChinookContext():base("ChinookDB")
        {

        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }

    }
}
