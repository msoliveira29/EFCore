using EFCore.Domain.Entities;
using EFCore.Infra.Data.Context;
using EFCore.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Infra.Data.Repositories
{
    /// <summary>
    /// Author...............: Marcelo Souza de Oliveira.
    /// Creation/Change Date.: .
    /// Description..........: .
    /// Reason...............: .
    /// </summary>
    /// <remarks></remarks>
    public class EFCoreRepository : IEFCoreRepository
    {
        #region Attributes

        private readonly HeroiContext _context;

        #endregion

        #region Properties
        #endregion

        #region Constructors

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="context"></param>
        /// <remarks></remarks>
        public EFCoreRepository(HeroiContext context)
        {
            _context = context;
        }

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <remarks></remarks>
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <remarks></remarks>
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <remarks></remarks>
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Heroi>> GetAllHerois(bool incluirBatalha = false)
        {
            IQueryable<Heroi> query = _context.Herois
                                              .Include(h => h.Identidade)
                                              .Include(h => h.Armas);

            if (incluirBatalha)
            {
                query = query.Include(h => h.HeroisBatalhas)
                             .ThenInclude(hb => hb.Batalha);
            }

            query = query.AsNoTracking().OrderBy(h => h.Id);

            return await query.ToArrayAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Heroi> GetHeroiById(int id, bool incluirBatalha = false)
        {
            IQueryable<Heroi> query = _context.Herois
                                              .Include(h => h.Identidade)
                                              .Include(h => h.Armas);

            if (incluirBatalha)
            {
                query = query.Include(h => h.HeroisBatalhas)
                             .ThenInclude(hb => hb.Batalha);
            }

            query = query.AsNoTracking().OrderBy(h => h.Id);

            return await query.FirstOrDefaultAsync(h => h.Id == id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Heroi>> GetHeroisByNome(string nome, bool incluirBatalha = false)
        {
            IQueryable<Heroi> query = _context.Herois
                                              .Include(h => h.Identidade)
                                              .Include(h => h.Armas);

            if (incluirBatalha)
            {
                query = query.Include(h => h.HeroisBatalhas)
                             .ThenInclude(hb => hb.Batalha);
            }

            query = query.AsNoTracking()
                         .Where(h => h.Nome.Contains(nome))
                         .OrderBy(h => h.Id);

            return await query.ToArrayAsync();
        }

        public async Task<IEnumerable<Batalha>> GetAllBatalhas(bool incluirHeroi = false)
        {
            IQueryable<Batalha> query = _context.Batalhas;

            if (incluirHeroi)
            {
                query = query.Include(h => h.HeroisBatalhas)
                             .ThenInclude(hb => hb.Heroi);
            }

            query = query.AsNoTracking().OrderBy(h => h.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Batalha> GetBatalhaById(int id, bool incluirHeroi = false)
        {
            IQueryable<Batalha> query = _context.Batalhas;

            if (incluirHeroi)
            {
                query = query.Include(h => h.HeroisBatalhas)
                             .ThenInclude(hb => hb.Heroi);
            }

            query = query.AsNoTracking().OrderBy(h => h.Id);

            return await query.FirstOrDefaultAsync(h => h.Id == id);
        }

        #endregion
    }
}