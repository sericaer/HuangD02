namespace HuangD.Interfaces
{
    public interface IPerson2Office : IRelation
    {
        IPerson person { get; }
        IOffice office { get; }

        bool isCurrent { get; }

    }
}
