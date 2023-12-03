using CollectionManagement.Contracts;

namespace CollectionManagement
{
    public class CardHandler : ICardHandler
    {
        public Dictionary<int, Dictionary<int, ICard>> Cards { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numSets">Number of sets in Lorcana</param>
        public CardHandler(int numSets)
        {
            Cards = new Dictionary<int, Dictionary<int, ICard>> ();
            for (int set = 1; set <= numSets; set++) // initialize set dictionaries
            {
                Cards[set] = new Dictionary<int, ICard> ();
            }
        }

        /// <summary>
        /// Takes a collection file path as input, edits the file to turn price sections into decimals
        /// </summary>
        /// <param name="collectionFilePath"></param>
        public void CleanCollectionFile(string collectionFilePath)
        {
            if (File.Exists(collectionFilePath))
            {
                var lines = collectionFileToCleanLineArr(collectionFilePath);
                using (var fs = File.CreateText(collectionFilePath))
                {
                    foreach (var line in lines)
                    {
                        fs.WriteLine(string.Join(",", line));
                    }
                }
                Console.WriteLine("Clean Complete");
            }
            else
            {
                Console.WriteLine($"{collectionFilePath} does not exist.");
            }
        }   

        public void  LoadCollectionFile(string collectionFilePath) //todo
        {
            var lines = collectionFileToCleanLineArr(collectionFilePath); 
            throw new NotImplementedException();
        }

        /// <summary>
        /// takes in a collection file, returns a array of lines of the file, with the price sections cleaned into decimals
        /// </summary>
        /// <param name="collectionFilePath"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        private List<string[]> collectionFileToCleanLineArr(string collectionFilePath)
        {
            var lines = new List<string[]>();
            if (File.Exists(collectionFilePath))
            {
                using (var fs = File.OpenText(collectionFilePath))
                {
                    string s = "";
                    while ((s = fs.ReadLine()) != null)
                    {
                        var lineArr = s.Split(',');
                        if (lineArr[0] != "Normal") // do no changes if already clean, this breaks on empty cell
                        {
                            if (lineArr[7].Contains('$'))
                            {
                                var dolSignInd = lineArr[7].IndexOf('$');
                                lineArr[7] = lineArr[7].Substring(dolSignInd + 1, getNumberLength(lineArr[7], dolSignInd + 1));
                            }
                            if (lineArr[8].Contains('$'))
                            {
                                var dolSignInd = lineArr[8].IndexOf('$');
                                lineArr[8] = lineArr[8].Substring(dolSignInd + 1, getNumberLength(lineArr[8], dolSignInd + 1));
                            }
                        }
                        lines.Add(lineArr);
                    }
                }
            }
            else
            {
                throw new FileNotFoundException(collectionFilePath);
            }
            return lines;
        }

        /// <summary>
        /// starting at startIndex in stringIn, returns how many characters including the startindex are numeric chars or . or ,
        /// </summary>
        /// <param name="stringIn"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        private int getNumberLength(string stringIn, int startIndex)
        {
            int length = 0;
            var charList = new List<char> { '0','1','2','3','4','5', '6', '7', '8', '9', '.', ','};
            for( int i = startIndex; i < stringIn.Length; i++ )
            {
                if (charList.Contains(stringIn[i]))
                {
                    length++;
                }
                else
                {
                    break;
                }
            }
            return length;
        }
    }
}
