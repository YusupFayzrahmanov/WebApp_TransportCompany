using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp_TransportCompany.Data;

namespace WebApp_TransportCompany.Repositories
{
    public abstract class BaseRepository:IRepository
    {
        /// <summary>
        /// Контекст базы данных
        /// </summary>
        protected readonly ApplicationDbContext _context;

        /// <summary>
        /// Конструктор базового репозитория
        /// </summary>
        /// <param name="context">Контекст базы данных</param>
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Реализация интерфейса IDisposable

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Реализация интерфейса IRepository

        /// <summary>
        /// Сохраняет изменения репозитория
        /// </summary>
        /// <returns></returns>
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
