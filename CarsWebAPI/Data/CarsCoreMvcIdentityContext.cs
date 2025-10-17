using System;
using System.Collections.Generic;
using CarsWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarsWebAPI.Data;

public partial class CarsCoreMvcIdentityContext : DbContext
{
    public CarsCoreMvcIdentityContext()
    {
    }

    public CarsCoreMvcIdentityContext(DbContextOptions<CarsCoreMvcIdentityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MyCar> MyCars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
