using LorcanaLogic;

namespace LorcanaConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numSets = 3;
            var ch = new CollectionHandler(numSets);
            var filePath = "C:\\Users\\Sam\\Downloads\\export(2).csv";
            var filePath2 = "C:\\Users\\Sam\\Downloads\\export(3).csv";

            ch.LoadCollectionFile(filePath);
            ch.LoadCollectionFile(filePath2);
            ch.PrintCollectionStats();
        }
    }
}
