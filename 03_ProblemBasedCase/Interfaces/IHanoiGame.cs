using System.Collections.Generic;

namespace ProblemBasedCase3.Interfaces
{
    public interface IHanoiGame
    {
        List<IHanoiTower> Towers { get; }
        void PushTower(IHanoiTower tower);
        void ToConsole();
    }
}