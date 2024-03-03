using LorcanaLogic.Contracts;
using Newtonsoft.Json;

namespace LorcanaLogic
{
    internal static class CollectionJsonHandler
    {
        private const string collectionFileName = "lorcana_collection.json";

        public static void SaveCollectionFile(Dictionary<int, Dictionary<int, ICard>> collection)
        {
            var fileString = JsonConvert.SerializeObject(collection, Formatting.Indented);
            using (var fs = File.CreateText(collectionFileName))
            {
                fs.Write(fileString);
            }
        }

        public static Dictionary<int, Dictionary<int, ICard>> GetCards()
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
                    return new Dictionary<int, Dictionary<int, ICard>>();
                }
                var tempDict = new Dictionary<int, Dictionary<int, ICard>>();
                foreach (var set in importDict.Keys) //need this double for to rectify the type. differences, wasn't able to deserialize as ICard. 
                {
                    tempDict[set] = new Dictionary<int, ICard>();
                    foreach (var cardNo in importDict[set].Keys)
                    {
                        tempDict[set][cardNo] = importDict[set][cardNo];
                    }
                }
                return tempDict; 
            }
            else
            {
                return new Dictionary<int, Dictionary<int, ICard>>();
            }
        }
    }
}
