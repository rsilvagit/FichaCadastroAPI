using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FichaCadastroAPI.Enumerators;
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

            //modelBuilder.Entity<FichaModel>()
            //   .HasData(new FichaModel
            //   {
            //       Id = 1,
            //       DataCadastro = DateTime.Now,
            //       DataNascimento = DateTime.Now,
            //       Email = "tafusam@email.com.br",
            //       Nome = "teste umes"
            //   },
            //   new FichaModel
            //   {
            //       Id = 2,
            //       DataCadastro = DateTime.Now,
            //       DataNascimento = DateTime.Now.AddYears(-30),
            //       Email = "paranguarik@email.com.br",
            //       Nome = "teste dois"
            //   });
            // Configurando a entidade FichaModel
            modelBuilder.Entity<FichaModel>().HasData(
                new FichaModel
                {
                    Id = 1,
                    DataCadastro = DateTime.Now,
                    Nome = "Jo�o",
                    Email = "joao@example.com",
                    DataNascimento =DateTime.Now.AddYears(-25),
                },
                new FichaModel
                {
                    Id = 2,
                    DataCadastro = DateTime.Now,
                    Nome = "Maria",
                    Email = "maria@example.com",
                    DataNascimento = DateTime.Now.AddYears(-45),
                }
                
            );

            //Configurando a entidade DetalheModel
            modelBuilder.Entity<DetalheModel>().HasData(
                new DetalheModel
                {
                    Id = 1,
                    DataCadastro = DateTime.Now,
                    Feedback = "Bom trabalho!",
                    Nota = NotasEnum.Cinco,
                    Situacao = true,
                    FichaId = 1 // Associando � FichaModel correspondente
                },
                new DetalheModel
                {
                    Id = 2,
                    DataCadastro = DateTime.Now,
                    Feedback = "Precisa melhorar",
                    Nota = NotasEnum.Tres,
                    Situacao = false,
                    FichaId = 2 // Associando � FichaModel correspondente
                }

            );

            modelBuilder.Entity<TelephoneModel>().HasData(
                new TelephoneModel
                {
                    Id = 1,
                    DataCadastro = DateTime.Now,
                    Ddd = "123",
                    Number = "555-1234",
                    Ative = true,
                    FichaId = 1,  // Associando � FichaModel correspondente
                },
                new TelephoneModel
                {
                    Id = 2,
                    DataCadastro = DateTime.Now,
                    Ddd = "456",
                    Number = "555-5678",
                    Ative = true,
                    FichaId = 2 // Associando � FichaModel correspondente
                }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}