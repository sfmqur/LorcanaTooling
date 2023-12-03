namespace CollectionManagement.Contracts
{
    public interface ICardHandler
    {
        public Dictionary<int,Dictionary<int,ICard>> Cards { get; } // keys: setno, cardno
        public void LoadCollectionFile(string collectionFilePath);
        public void CleanCollectionFile(string collectionFilePath);
    }
}
