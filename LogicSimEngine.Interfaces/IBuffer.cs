namespace LogicSimEngine.Interfaces
{
    public interface IBuffer
    {
        (int year, int month, int day) startDate { get; }
        IBufferDef def { get; }
    }

    public interface ICommand
    {
        bool CanExecute();
        void Execute();
    }
}
