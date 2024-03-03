namespace LorcanaLogic.Contracts
{
    public interface IDeck
    {
        string Name { get; }
        List<ICard> CardList { get; }
        List<int> CardQuantity { get; }

        string Diff(IDeck other);
    }
}