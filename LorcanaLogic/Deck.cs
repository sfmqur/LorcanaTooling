using LorcanaLogic.Contracts;

namespace LorcanaLogic
{
    public class Deck : IDeck
    {
        public string Name { get; }

        public List<Card> CardList { get; }

        public List<int> CardQuantity { get; }

        public Deck(string deckListPath)
        {
            Name = deckListPath.Substring(deckListPath.LastIndexOf("\\"), deckListPath.LastIndexOf('.'));
            CardList = new List<Card>();
            CardQuantity = new List<int>();
            importDeckFromDreambornExport(deckListPath);
        }
        public string Diff(IDeck other)
        {
            throw new NotImplementedException();
        }

        private void importDeckFromDreambornExport(string deckListPath)
        {

        }
    }
}
