using System;
using System.Collections.Generic;
using ProblemBasedCase3.Interfaces;

namespace ProblemBasedCase3.Implementations
{
    public class HanoiGame : IHanoiGame
    {
        public List<IHanoiTower> Towers { get; } = new List<IHanoiTower>();

        public void PushTower(IHanoiTower tower) => Towers.Add(tower);

        public void ToConsole()
        {
            if (Towers.Count <= 0) return;
            for (var i = 0; i < Towers.Count; i++)
                Console.WriteLine($"Tower {i} - {Towers[i].Count} disks\n {Towers[i]}");
        }
    }
}