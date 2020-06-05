using System;
using System.Collections.Generic;

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
    public class Heroi
    {
        #region Attributes
        #endregion

        #region Properties

        public int Id { get; set; }

        public string Nome { get; set; }

        public IdentidadeSecreta Identidade { get; set; }

        public List<Arma> Armas { get; set; }

        public List<HeroiBatalha> HeroisBatalhas { get; set; }

        #endregion

        #region Constructors
        #endregion

        #region Methods
        #endregion
    }
}