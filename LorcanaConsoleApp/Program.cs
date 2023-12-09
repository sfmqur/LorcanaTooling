using CollectionManagement;

namespace LorcanaConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numSets = 2;
            var ch = new CardHandler(numSets);
            var filePath = "C:\\Users\\Sam\\Downloads\\export.csv";
            var filePath2 = "C:\\Users\\Sam\\Downloads\\export(1).csv";

            ch.LoadCollectionFile(filePath);
            ch.LoadCollectionFile(filePath2);
            ch.PrintCollectionStats();
        }
    }
}
