using _20230408_AsyncProgramming_CRUD.Infrastructure.Context;
using _20230408_AsyncProgramming_CRUD.Infrastructure.Repositories.Interfaces;
using _20230408_AsyncProgramming_CRUD.Models.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace _20230408_AsyncProgramming_CRUD.Infrastructure.Repositories.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;
        protected readonly DbSet<T> _table;
        // DbSet hatırlarsanız AppDbContext sınıfı içerisinde tanımladığımız bir yapıdır. O da uygulama tarafında veri tabanındaki tabloların karşılığına denk gelir.

        // Biz veri tabanı üzerinde herhangi bir CRUD operasyonu gerçekleştireceğimiz zaman teorik olarak düşünürsek verit abanı ve onun üzerindeki ilgili tabloya erişmemiz gerekmektedir. ORM gereği burada muhakkak onların bir karşılığının olması zorunludur.
        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            #region Despendency Injection

            // Eski çalışmalarımızda tam burada yukarıda anlattığım sebepten dolayı ApplicationDbContext.cs nesnesini çalıştırdık. Bu örnekten alma işlemi yüzünden repository sınıfları ile ApplicationDbContext sınıfı arasında sıkı sıkı bağlı bir ilişki kurulmuş oldu. Ayrıca memory(bellek) yönetimi açısından sıkı sıkıya bağlı sınıfların maliyeti oluşturulduğunda RAM'in Heap alanında yönetilmeyen kaynaklara neden olmaktadır. Sonuç olarak her sınıfın instance'si çıkardığımızda bu nesnelerin yönetimide projelerimiz büyüdükçe sıkıntılar yaşanmaktadır. Bu yüzden dolayı projelerimizde bu tarz bağımlılıklara sebep olan sınıfları DIP ve IoC prensiplerine de uymak için Dependency Injection deseni kullanarak gevşek bağlı bir hale getirmek istiyoruz.

            // Injection ederken 3 farklı yol ile inject edebiliriz:
            // 1. Constructer injection
            // 2. Custom metod injection
            // 3. Property ile injection

            // DI bir desendir, prensip değildir. Hatta DIP ve IoC pronsiplerini uygulamanızda bize yardımcı olan bir araçtır. Asp.Net Core bu prensipleri projelerimizde rahatlıkla kullanmamız için dizayn edilmiştir.

            #endregion

            this._dbContext = applicationDbContext;
            this._table = _dbContext.Set<T>();
        }


        public async Task Add(T entity)
        {
            await _table.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Any(Expression<Func<T, bool>> exp) => await _table.AnyAsync(exp);

        public async Task<bool> Delete(T entity)
        {
            try
            {
                entity.DeleteDate = DateTime.Now;
                entity.Status = Status.Passive;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {

                return false;
            }

        }

        public async Task<T> GetByDefault(Expression<Func<T, bool>> expression) => await _table.FirstOrDefaultAsync(expression);

        public async Task<T> GetById(int? id) => await _table.FindAsync(id);

        public async Task<List<T>> GetByList(Expression<Func<T, bool>> expression) => await _table.Where(expression).ToListAsync();

        public async Task<List<OkResult>> GetFilteredList<OkResult>(
            Expression<Func<T, OkResult>> select,
            Expression<Func<T, bool>> where = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> join = null
        )
        {
            IQueryable<T> query = _table;

            if (join != null)
                query = join(query);
            if (where != null)
                query = query.Where(where);
            if (orderBy != null)
                query = orderBy(query);

            return await query.Select(select).ToListAsync();
        }

        public async Task Update(T entity)
        {
            entity.UpdateDate = DateTime.Now;
            entity.Status = Status.Modified;
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
