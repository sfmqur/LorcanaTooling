namespace CollectionManagement.Contracts
{
    public interface ICollectionHandler
    {
        public Dictionary<int,Dictionary<int,ICard>> Cards { get; } // keys: setno, cardno
        public void LoadCollectionFile(string collectionFilePath);
        public List<string[]> CleanCollectionFile(string collectionFilePath);

    }
}
