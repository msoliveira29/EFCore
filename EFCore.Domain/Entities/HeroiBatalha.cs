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
    public class HeroiBatalha
    {
        #region Attributes
        #endregion

        #region Properties

        public int HeroiId { get; set; }

        public Heroi Heroi { get; set; }

        public int BatalhaId { get; set; }

        public Batalha Batalha { get; set; }

        #endregion

        #region Constructors
        #endregion

        #region Methods
        #endregion
    }
}