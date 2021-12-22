using System;

namespace ProblemBasedCase.Data
{
    public class StatusModel
    {
        private readonly int _height;
        
        public double ShirtsPercentage { get; }
        public string ShirtsColor => GetColor(ShirtsPercentage);
        public int ShirtBarY => GetPosY(ShirtBarHeight);
        public int ShirtBarHeight { get; }

        public double ShoePercentage { get; }
        public string ShoeColor => GetColor(ShoePercentage);
        public int ShoeBarY => GetPosY(ShoeBarHeight);
        public int ShoeBarHeight { get; }
        
        public double SuitsPercentage { get; }
        public string SuitsColor => GetColor(SuitsPercentage);
        public int SuitBarY => GetPosY(SuitBarHeight);
        public int SuitBarHeight { get; }
        
        public string StoreName { get; }

        public StatusModel(Store store, int height)
        {
            _height = height;
            ShirtsPercentage = Math.Round((double) store.ShirtBoxes / store.MaxShirtBoxes * 100);
            ShirtBarHeight = (int) (_height * ShirtsPercentage / 100);
            ShoePercentage = Math.Round((double) store.ShoePacks / store.MaxShoePacks * 100);
            ShoeBarHeight = (int) (_height * ShoePercentage / 100);
            SuitsPercentage = Math.Round((double) store.SuitPacks / store.MaxSuitPacks * 100);
            SuitBarHeight = (int) (_height * SuitsPercentage / 100);
            StoreName = store.StoreName;
        }

        private static string GetColor(double percentage)
        {
            return percentage < 20 || percentage > 80 ? "red" : "green";
        }

        private int GetPosY(double barHeight)
        {
            return (int) (_height - barHeight - 4);
        }
    }
}