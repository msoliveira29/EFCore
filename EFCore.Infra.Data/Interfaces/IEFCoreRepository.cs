using EFCore.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.Infra.Data.Interfaces
{
    /// <summary>
    /// Author...............: Marcelo Souza de Oliveira.
    /// Creation/Change Date.: .
    /// Description..........: .
    /// Reason...............: .
    /// </summary>
    /// <remarks></remarks>
    public interface IEFCoreRepository
    {
        #region Attributes
        #endregion

        #region Properties
        #endregion

        #region Constructors
        #endregion

        #region Methods

        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangeAsync();

        Task<IEnumerable<Heroi>> GetAllHerois(bool incluirBatalha = false);

        Task<Heroi> GetHeroiById(int id, bool incluirBatalha = false);

        Task<IEnumerable<Heroi>> GetHeroisByNome(string nome, bool incluirBatalha = false);

        Task<IEnumerable<Batalha>> GetAllBatalhas(bool incluirHeroi = false);

        Task<Batalha> GetBatalhaById(int id, bool incluirHeroi = false);

        #endregion
    }
}