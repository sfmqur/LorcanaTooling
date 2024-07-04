using Newtonsoft.Json;

namespace LorcanaLogic
{
    internal static class CollectionJsonHandler
    {
        private const string collectionFileName = "lorcana_collection.json";

        public static void SaveCollectionFile(Dictionary<int, Dictionary<int, Card>> collection)
        {
            var fileString = JsonConvert.SerializeObject(collection, Formatting.Indented);
            using (var fs = File.CreateText(collectionFileName))
            {
                fs.Write(fileString);
            }
        }

        public static Dictionary<int, Dictionary<int, Card>> GetCards()
        {
            if (File.Exists(collectionFileName))
            {
                var fileString = "";
                using (var fs = File.OpenText(collectionFileName))
                {
                    fileString = fs.ReadToEnd();
                }
                var importDict = JsonConvert.DeserializeObject< Dictionary<int, Dictionary<int, Card>>>(fileString);
                if (importDict == null)
                {
                    return new Dictionary<int, Dictionary<int, Card>>();
                }
                return importDict; 
            }
            else
            {
                return new Dictionary<int, Dictionary<int, Card>>();
            }
        }
    }
}
