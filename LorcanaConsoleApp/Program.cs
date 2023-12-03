using CollectionManagement;

namespace LorcanaConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var filePath = "C:\\Users\\Sam\\Downloads\\export(3).csv";
            var ch = new CardHandler(2);
            ch.CleanCollectionFile(filePath);
        }
    }
}
