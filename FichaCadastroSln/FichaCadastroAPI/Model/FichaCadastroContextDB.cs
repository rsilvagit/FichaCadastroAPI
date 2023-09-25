using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FichaCadastroAPI.Model
{
    public class FichaCadastroContextDB : DbContext
    {
        public DbSet<FichaModel> FichaModels { get; set; }
        public DbSet<DetalheModel> DetalheModels { get; set; }
        public DbSet<TelephoneModel> TelephoneModels { get; set; }
        public FichaCadastroContextDB(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetalheModel>()
                        .HasOne(h => h.Ficha)
                        .WithMany(w => w.DetalheModels)
                        .Metadata
                        .DeleteBehavior = DeleteBehavior.Restrict;//impede que os dados sejam apagados em cascata
            
            modelBuilder.Entity<TelephoneModel>()
                        .HasOne(h => h.Ficha)
                        .WithMany(w => w.TelephoneModels)
                        .Metadata
                        .DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<DetalheModel>()
                        .Property(p => p.DataCadastro)
                        .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<FichaModel>()
                        .Property(p => p.DataCadastro)
                        .HasDefaultValueSql("GETDATE()");
            modelBuilder.Entity<TelephoneModel>()
                        .Property(p => p.DataCadastro)
                        .HasDefaultValueSql("GETDATE()");

            base.OnModelCreating(modelBuilder);
        }

    }
}