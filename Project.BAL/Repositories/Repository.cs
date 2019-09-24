using Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected C1709M_PROJ db;
        protected DbSet<TEntity> tbl;
        

        public Repository()
        {
            db = new C1709M_PROJ();
            tbl = db.Set<TEntity>();
        }
        /// <summary>
        /// hàm xóa đối tượng
        /// </summary>
        /// <param name="entity">Truyền vào đối tượng cần xóa</param>
        /// <returns></returns>
        public bool Add(TEntity entity)
        {
            try
            {
                tbl.Add(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(TEntity entity)
        {
            try
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Hàm để trả về một đối tượng
        /// </summary>
        /// <param name="id">id của đối tượng cần tìm</param>
        /// <returns></returns>
        public TEntity Get(object id)
        {
            return tbl.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return tbl;
        }

        public IEnumerable<TEntity> GetBy(Func<TEntity, bool> predicate)
        {
            return tbl.Where(predicate);
        }

        public bool Remove(TEntity entity)
        {
            try
            {
                tbl.Remove(entity);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        bool IRepository<TEntity>.Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        bool IRepository<TEntity>.AddRange(IEnumerable<TEntity> entity)
        {
            throw new NotImplementedException();
        }

        bool IRepository<TEntity>.Edit(TEntity entity)
        {
            throw new NotImplementedException();
        }

        TEntity IRepository<TEntity>.Get(object id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TEntity> IRepository<TEntity>.GetAll()
        {
            throw new NotImplementedException();
        }

    }
}
