namespace ProblemBasedCase.Data
{
    public class Store
    {
        public long StoreId { get; set; }

        #region CurrentStoreState

        public string StoreName { get; set; }
        public int ShirtBoxes { get; set; }
        public int ShoePacks { get; set; }
        public int SuitPacks { get; set; }

        #endregion

        #region Maximum capacities

        public int MaxShirtBoxes { get; set; } = Constants.MaxShirtBoxes;
        public int MaxShoePacks { get; set; } = Constants.MaxShoePacks;
        public int MaxSuitPacks { get; set; } = Constants.MaxSuitPacks;

        #endregion
    }
}