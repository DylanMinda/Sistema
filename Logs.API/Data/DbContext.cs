using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Alertas.Modelos;

    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext (DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        public DbSet<Alertas.Modelos.Sensor> Sensores { get; set; } = default!;

public DbSet<Alertas.Modelos.Alerta> Alertas { get; set; } = default!;
    }
