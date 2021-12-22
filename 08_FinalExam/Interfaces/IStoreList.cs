using System.Collections.Generic;
using ProblemBasedCase.Data;

namespace ProblemBasedCase.Interfaces
{
    public interface IStoreList
    {
        /// <summary>
        /// Returns the list of all stores in database.
        /// </summary>
        IEnumerable<Store> GetAllStores();

        /// <summary>
        /// Gets a store from database by id.
        /// </summary>
        Store GetStoreById(long id);
        
        /// <summary>
        /// Inserts new store to database.
        /// </summary>
        void InsertStore(Store store);
        
        /// <summary>
        /// Updates existing store in database.
        /// </summary>
        void UpdateStore(Store store);
        
        /// <summary>
        /// Deletes store from database by store id.
        /// </summary>
        void DeleteStore(long storeId);
    }
}