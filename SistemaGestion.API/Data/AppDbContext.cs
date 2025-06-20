using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sistema.Modelos;

    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Sistema.Modelos.Camion> Camiones { get; set; } = default!;

public DbSet<Sistema.Modelos.Conductor> Conductores { get; set; } = default!;

public DbSet<Sistema.Modelos.Mantenimiento> Mantenimientos { get; set; } = default!;

public DbSet<Sistema.Modelos.Taller> Talleres { get; set; } = default!;

public DbSet<Sistema.Modelos.Usuario> Usuarios { get; set; } = default!;
    }
