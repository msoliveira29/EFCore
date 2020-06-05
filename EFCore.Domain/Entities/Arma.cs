using System;

namespace EFCore.Domain.Entities
{
    /// <summary>
    /// Author...............: Marcelo Souza de Oliveira.
    /// Creation/Change Date.: .
    /// Description..........: .
    /// Reason...............: .
    /// </summary>
    /// <remarks></remarks>
    [Serializable()]
    public class Arma
    {
        #region Attributes
        #endregion

        #region Properties

        public int Id { get; set; }

        public string Nome { get; set; }

        public Heroi Heroi { get; set; }

        public int HeroiId { get; set; }

        #endregion

        #region Constructors
        #endregion

        #region Methods
        #endregion
    }
}