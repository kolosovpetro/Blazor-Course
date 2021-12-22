using System.Collections.Generic;

namespace ProblemBasedCase3.Interfaces
{
    public interface IHanoiTower
    {
        int Capacity { get; }
        int Count { get; }
        void PushDisk(IHanoiDisk disk);
        void PopDisk();
        void PopDisk(int diskId);
        IEnumerable<IHanoiDisk> GetAllDisks();
    }
}