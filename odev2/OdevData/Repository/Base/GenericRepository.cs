using Microsoft.EntityFrameworkCore;
using OdevData.Context;


namespace OdevData.Repository.Base
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        protected readonly Odev2DbContext _db;
        private bool _disposed;

        public GenericRepository(Odev2DbContext db) 
        {
           this._db= db;
        }
       
        public List<Entity> GetAll() 
        {
            return _db.Set<Entity>().ToList();  
        }
        public void Delete(Entity entity)
        {
            _db.Set<Entity>().Remove(entity);
        }
        public void DeleteById(int id)
        {
            var entity = _db.Set<Entity>().Find(id);
            _db.Set<Entity>().Remove(entity);
        }
        public void Insert(Entity entity) 
        {
            

            _db.Set<Entity>().Add(entity);
        }
        
        public void Update(Entity entity) 
        {
            _db.Set<Entity>().Update(entity);
        }
        public Entity GetById(int id) 
        {
            return  _db.Set<Entity>().Find(id);
            
        }
        public List<Entity> Where(Func<Entity, bool> predicate)
        {
            return _db.Set<Entity>().Where(predicate).ToList();
        }

        public void Complete()
        {
            _db.SaveChanges();
        }
        public void CompleteWithTransaction()
        {
            using (var dbDcontextTransaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.SaveChanges();
                    dbDcontextTransaction.Commit();
                }
                catch (Exception)
                {
                    dbDcontextTransaction.Rollback();
                }
            }
        }

    }
    
    
}
