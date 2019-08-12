using Microsoft.EntityFrameworkCore;
using SchoolApp.DAL.Interfaces;
using SchoolApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchoolApp.DAL.Repositories
{
    public class EFGenericRepository<TEntity>:IRepository<TEntity> where TEntity:class
    {
        DbContext _context;
        DbSet<TEntity> _dbSet;

        public EFGenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }
        public TEntity Get(int id)
        {
            return _dbSet.Find(id);
        }
        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }
        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            TEntity entity= _dbSet.Find(id);
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
        public IEnumerable<TEntity> Find(Func<TEntity, Boolean> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }
    }
}
