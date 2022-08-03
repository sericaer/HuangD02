namespace LogicSimEngine.Interfaces
{
    public interface IBuffer
    {
        (int year, int month, int day) startDate { get; }
        IBufferDef def { get; }
    }

}
