using ProblemBasedCase3.Enums;

namespace ProblemBasedCase3.Interfaces
{
    public interface IHanoiDisk
    {
        public int Id { get; set; }
        public int Width { get; }
        public int Height { get; }
        public Colors Color { get; }
    }
}