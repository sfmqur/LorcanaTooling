namespace LorcanaLogic.Contracts
{
    public interface ICollectionHandler
    {
        Dictionary<int,Dictionary<int,Card>> Cards { get; } // keys: setno, cardno
        void LoadCollectionFile(string collectionFilePath);
        List<string[]> CleanCollectionFile(string collectionFilePath);
        void SaveCollectionFile();
        void PrintCollectionStats();
    }
}
