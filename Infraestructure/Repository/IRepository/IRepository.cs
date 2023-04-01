using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        //GetAll
        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>> filter = null, 
            string incluideProperties = null
            );


        //GetFirst

        Task<T> GetFirstAsync(
            Expression<Func<T, bool>> filter = null,
            string incluideProperties = null
            );

        //Add
        Task AddAsync(T entity);

        //Remove 

        void RemoveAsync(T entity);
        
    }
}
