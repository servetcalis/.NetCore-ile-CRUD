using _20230408_AsyncProgramming_CRUD.Models.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;

namespace _20230408_AsyncProgramming_CRUD.Infrastructure.Repositories.Interfaces
{
    #region Asenkron Programing (Eş zamansız programlama)

    // Bugüne kadar yaptığımız çalışmalarda senkron programlama (eş zamanlı programlama) yapıyorduk.
    // Bu yüzden bir iş (business) yapıldığında kullanıcı arayüzü (UI - User Interface) sadece yapılan bu işe bütün eforunu sarf ediyordu.
    // Örneğin bir webservisten data çekmek istiyorsunuz ve request(talep) attınız, response olarak gelen data'nın listelenmesi, işleme alınması aşamasında UI thread'ı kilitledi. Böylelikle kullanıcı uygulamanın ona verdiği not tutma için kullanılan bölümü kullanamaz hale geldi. Sonkron programlama burada yetersiz kaldı Bizim problemimizi yani data listelenirken arayüz üzerinde not tutma işini asenkron prgramlama ile yapabiliriz. Asenkron programlama aynı anda birden fazla işi yapmak isim bağımsız olarak çalışmaktadır.
    #endregion

    public interface IBaseRepository<T> where T : BaseEntity
    {
        // Bu projede elimizin asenkron programlamaya alışması için bütün metodları asenkron yazacağız. Lakin Create, Update ve Delete işlemleri çok aksi bir iş (business) olmadığı sürece asenkron programlanmaz. Bunun yanında bizim asıl odaklanmamız gereken nokta Read operasyonlarımızdır.
        Task Add(T entity);
        Task Update(T entity);
        Task<bool> Delete(T entity);

        Task<List<T>> GetByList(Expression<Func<T, bool>> expression);
        Task<T> GetByDefault(Expression<Func<T, bool>> expression);

        // Read Operations
        Task<List<OkResult>> GetFilteredList<OkResult>(
            Expression<Func<T, OkResult>> select,
            Expression<Func<T, bool>> where = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> join = null
        );

        Task<T> GetById(int? id);
        Task<bool> Any(Expression<Func<T, bool>> exp);
    }
}
