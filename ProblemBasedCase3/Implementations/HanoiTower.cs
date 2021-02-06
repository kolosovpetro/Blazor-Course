using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProblemBasedCase3.Interfaces;

namespace ProblemBasedCase3.Implementations
{
    public class HanoiTower : IHanoiTower
    {
        private readonly List<IHanoiDisk> _disks = new List<IHanoiDisk>();
        public int Capacity { get; }
        public int Count => _disks.Count;
        public HanoiTower(int capacity) => Capacity = capacity;

        public void PushDisk(IHanoiDisk disk)
        {
            if (Count >= Capacity) return;
            _disks.Add(disk);
            disk.Id = _disks.IndexOf(disk);
        }

        public void PopDisk()
        {
            var last = _disks.FirstOrDefault();
            if (last != null) _disks.Remove(last);
        }

        public void PopDisk(int diskId)
        {
            var disk = _disks.FirstOrDefault(x => x.Id == diskId);
            if (disk == null) return;
            _disks.Remove(disk);
            Console.WriteLine($"{disk.Color} disk has been removed");
        }

        public IEnumerable<IHanoiDisk> GetAllDisks() => _disks;

        public override string ToString()
        {
            var builder = new StringBuilder();
            for (var i = 0; i < Count; i++) builder.Append($"Disk {i} {_disks[i]}\n");
            return builder.ToString();
        }
    }
}