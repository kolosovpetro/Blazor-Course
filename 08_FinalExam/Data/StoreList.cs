using System.Collections.Generic;
using System.Linq;
using ProblemBasedCase.Interfaces;

namespace ProblemBasedCase.Data
{
    public class StoreList : IStoreList
    {
        private readonly PostgresContext _postgresContext = new PostgresContext();

        /// <summary>
        /// Returns the list of all stores in database.
        /// </summary>
        public IEnumerable<Store> GetAllStores() => StoreMapper.Map(_postgresContext.GetAllStores());

        /// <summary>
        /// Gets a store from database by id.
        /// </summary>
        public Store GetStoreById(long id) =>
            StoreMapper.Map(_postgresContext.GetAllStores()).FirstOrDefault(x => x.StoreId == id);

        /// <summary>
        /// Inserts new store to database.
        /// </summary>
        public void InsertStore(Store store) => PostgresContext.Insert(store);

        /// <summary>
        /// Updates existing store in database.
        /// </summary>
        public void UpdateStore(Store store) => PostgresContext.Update(store);

        /// <summary>
        /// Deletes store from database by store id.
        /// </summary>
        public void DeleteStore(long storeId) => PostgresContext.DeleteStore(storeId);
    }
}