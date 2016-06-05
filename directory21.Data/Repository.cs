using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using directory21.Core.Data;
using directory21.Core.Domain;

namespace directory21.Data
{
    public class Repository<T>:IRepository<T> where T:BaseEntity
    {
        #region Variable

        private readonly IDbContext _context;
        private IDbSet<T> _entity;
        private string _errorMessage;

        #endregion

        #region Constructor

        public Repository(IDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Implementation of IRepository<T>

        protected virtual IDbSet<T> Entities
        {
            get { return _entity ?? (_entity = _context.Set<T>()); }
        }

        public IQueryable<T> Table
        {
            get { return Entities; }
        }

        public T GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                Entities.Add(entity);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var err in dbEx.EntityValidationErrors.SelectMany(errors => errors.ValidationErrors))
                {
                    _errorMessage += String.Format("Property {0} Error {1}", err.PropertyName, err.ErrorMessage) +
                                     Environment.NewLine;
                    throw new Exception(_errorMessage, dbEx);
                }
            }
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                //Entities.Add(entity);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var err in dbEx.EntityValidationErrors.SelectMany(errors => errors.ValidationErrors))
                {
                    _errorMessage += String.Format("Property {0} Error {1}", err.PropertyName, err.ErrorMessage) +
                                     Environment.NewLine;
                    throw new Exception(_errorMessage, dbEx);
                }
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");
                Entities.Remove(entity);
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var err in dbEx.EntityValidationErrors.SelectMany(errors => errors.ValidationErrors))
                {
                    _errorMessage += String.Format("Property {0} Error {1}", err.PropertyName, err.ErrorMessage) +
                                     Environment.NewLine;
                    throw new Exception(_errorMessage, dbEx);
                }
            }
        }

        #endregion
    }
}
