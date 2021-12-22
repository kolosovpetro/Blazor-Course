using ProblemBasedCase3.Enums;
using ProblemBasedCase3.Interfaces;

namespace ProblemBasedCase3.Implementations
{
    public class HanoiDisk : IHanoiDisk
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Colors Color { get; set; }

        public override string ToString() => $"{Width} {Color}";
    }
}