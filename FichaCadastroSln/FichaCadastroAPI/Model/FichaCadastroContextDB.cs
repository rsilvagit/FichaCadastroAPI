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

            
            modelBuilder.Entity<FichaModel>().HasData(
                new FichaModel
                {
                    Id = 1,
                    DataCadastro = DateTime.Now,
                    Nome = "João",
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
                },
                new FichaModel
                {
                    Id = 3,
                    DataCadastro = DateTime.Now,
                    Nome = "Joaquim",
                    Email = "joaquim@example.com",
                    DataNascimento = DateTime.Now.AddYears(-25),
                },
                new FichaModel
                {
                    Id = 4,
                    DataCadastro = DateTime.Now,
                    Nome = "Mario",
                    Email = "mario@example.com",
                    DataNascimento = DateTime.Now.AddYears(-85),
                },
                new FichaModel
                {
                    Id = 5,
                    DataCadastro = DateTime.Now,
                    Nome = "Junior",
                    Email = "junior@example.com",
                    DataNascimento = DateTime.Now.AddYears(-15),
                },
                new FichaModel
                {
                    Id = 6,
                    DataCadastro = DateTime.Now,
                    Nome = "Marina",
                    Email = "marina@example.com",
                    DataNascimento = DateTime.Now.AddYears(-25),
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
                    FichaId = 5 // Associando à FichaModel correspondente
                },
                new DetalheModel
                {
                    Id = 2,
                    DataCadastro = DateTime.Now,
                    Feedback = "Precisa melhorar",
                    Nota = NotasEnum.Tres,
                    Situacao = false,
                    FichaId = 2 // Associando à FichaModel correspondente
                },
                new DetalheModel
                {
                    Id = 3,
                    DataCadastro = DateTime.Now,
                    Feedback = "Bom trabalho!",
                    Nota = NotasEnum.Cinco,
                    Situacao = true,
                    FichaId = 3 // Associando à FichaModel correspondente
                },
                new DetalheModel
                {
                    Id = 4,
                    DataCadastro = DateTime.Now,
                    Feedback = "Precisa melhorar",
                    Nota = NotasEnum.Tres,
                    Situacao = false,
                    FichaId = 2 // Associando à FichaModel correspondente
                },
                new DetalheModel
                {
                    Id = 5,
                    DataCadastro = DateTime.Now,
                    Feedback = "Bom trabalho!",
                    Nota = NotasEnum.Cinco,
                    Situacao = true,
                    FichaId = 1 // Associando à FichaModel correspondente
                },
                new DetalheModel
                {
                    Id = 6,
                    DataCadastro = DateTime.Now,
                    Feedback = "Precisa melhorar",
                    Nota = NotasEnum.Tres,
                    Situacao = false,
                    FichaId = 3 // Associando à FichaModel correspondente
                },
                new DetalheModel
                {
                    Id = 7,
                    DataCadastro = DateTime.Now,
                    Feedback = "Bom trabalho!",
                    Nota = NotasEnum.Cinco,
                    Situacao = true,
                    FichaId = 1 // Associando à FichaModel correspondente
                },
                new DetalheModel
                {
                    Id = 8,
                    DataCadastro = DateTime.Now,
                    Feedback = "Precisa melhorar",
                    Nota = NotasEnum.Tres,
                    Situacao = false,
                    FichaId = 4 // Associando à FichaModel correspondente
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
                    FichaId = 1,  // Associando à FichaModel correspondente
                },
                new TelephoneModel
                {
                    Id = 2,
                    DataCadastro = DateTime.Now,
                    Ddd = "456",
                    Number = "555-5678",
                    Ative = true,
                    FichaId = 2 // Associando à FichaModel correspondente
                },
                new TelephoneModel
                {
                    Id = 3,
                    DataCadastro = DateTime.Now,
                    Ddd = "123",
                    Number = "555-1234",
                    Ative = true,
                    FichaId = 5,  // Associando à FichaModel correspondente
                },
                new TelephoneModel
                {
                    Id = 4,
                    DataCadastro = DateTime.Now,
                    Ddd = "456",
                    Number = "555-5578",
                    Ative = true,
                    FichaId = 4 // Associando à FichaModel correspondente
                },
                new TelephoneModel
                {
                    Id = 5,
                    DataCadastro = DateTime.Now,
                    Ddd = "123",
                    Number = "555-1234",
                    Ative = true,
                    FichaId = 1,  // Associando à FichaModel correspondente
                },
                new TelephoneModel
                {
                    Id = 6,
                    DataCadastro = DateTime.Now,
                    Ddd = "456",
                    Number = "555-5678",
                    Ative = true,
                    FichaId = 3 // Associando à FichaModel correspondente
                },
                new TelephoneModel
                {
                    Id = 7,
                    DataCadastro = DateTime.Now,
                    Ddd = "123",
                    Number = "555-1004",
                    Ative = true,
                    FichaId = 1,  // Associando à FichaModel correspondente
                },
                new TelephoneModel
                {
                    Id = 8,
                    DataCadastro = DateTime.Now,
                    Ddd = "456",
                    Number = "555-5008",
                    Ative = true,
                    FichaId = 2 // Associando à FichaModel correspondente
                }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}