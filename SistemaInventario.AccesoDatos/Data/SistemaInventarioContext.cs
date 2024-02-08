using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaInventario.Modelos;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace SistemaInventario.AccesoDatos.Data;

public class SistemaInventarioContext : IdentityDbContext
{
    public SistemaInventarioContext(DbContextOptions<SistemaInventarioContext> options)
        : base(options)
    {
    }


    public DbSet <Bodega> Bodegas { get; set; }
    public DbSet <Categoria> Categorias { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
}
