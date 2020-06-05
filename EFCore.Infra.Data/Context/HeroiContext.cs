using EFCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFCore.Infra.Data.Context
{
    /// <summary>
    /// Author...............: Marcelo Souza de Oliveira.
    /// Creation/Change Date.: .
    /// Description..........: .
    /// Reason...............: .
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public class HeroiContext : DbContext
    {
        #region Attributes
        #endregion

        #region Properties

        public DbSet<Heroi> Herois { get; set; }

        public DbSet<Batalha> Batalhas { get; set; }

        public DbSet<Arma> Armas { get; set; }

        public DbSet<HeroiBatalha> HeroisBatalhas { get; set; }

        public DbSet<IdentidadeSecreta> IdentidadesSecretas { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <remarks></remarks>
        public HeroiContext(DbContextOptions<HeroiContext> options) : base(options) { }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <remarks></remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroiBatalha>(entity =>
            {
                entity.HasKey(e => new { e.BatalhaId, e.HeroiId });
            });
        }

        #endregion
    }
}