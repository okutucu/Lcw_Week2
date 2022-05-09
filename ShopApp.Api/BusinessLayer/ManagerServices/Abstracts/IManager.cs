using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShopApp.Api.EntityLayer.CoreInterfaces;

namespace ShopApp.Api.BusinessLayer.ManagerServices.Abstracts
{
    public interface IManager<T> where T : class, IEntity
    {
        //List Commands

        List<T> GetAll(); // Bu metot ilgili T Neyse o yapıdaki tüm verileri getirecek..
        List<T> GetActives(); //Bu metot sadece AKTİF kullanımda olan verileri getirecek..
        List<T> GetPassives(); //Bu metot sadece Pasif olan verileri getirecek...
        List<T> GetModifieds(); // BU metot sadece güncellenmiş olan verileri getirecek...

        //Modify Commands
        string Add(T item); 
        void AddRange(List<T> list);

        /// <summary>
        /// Bu metot argüman olarak verdiginiz veriyi pasife ceker
        /// </summary>
        /// <param name="item">Pasife cekilecek olan veri</param>
        void Delete(T item);
        void DeleteRange(List<T> list);
        void Update(T item);
        void UpdateRange(List<T> list);

        void SetActive(T item);

        /// <summary>
        /// Bu metot argüman olarak verdiginiz veriyi siler
        /// </summary>
        /// <param name="item">Silinmesini istediginiz veri</param>
        void Destroy(T item);
        void DestroyRange(List<T> list);

        //Linq
        List<T> Where(Expression<Func<T, bool>> exp);
        bool Any(Expression<Func<T, bool>> exp);
        T FirstOrDefault(Expression<Func<T, bool>> exp);
        object Select(Expression<Func<T, object>> exp);
        IQueryable<X> SelectViaClass<X>(Expression<Func<T, X>> exp);

        //Find Command
        T Find(int id);

        //Last Data
        T GetLastData();

        //First Data
        T GetFirstData();

        public Task<IEnumerable<View>> getListAsync();

        public Task<View> findByIdAsync(int id);



    }
}
