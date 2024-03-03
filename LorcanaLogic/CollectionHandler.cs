using LorcanaLogic.Contracts;
using Microsoft.VisualBasic.FileIO;

namespace LorcanaLogic
{
    public class CollectionHandler : ICollectionHandler
    {
        public Dictionary<int, Dictionary<int, ICard>> Cards { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="numSets">Number of sets in Lorcana</param>
        public CollectionHandler()
        {
            Cards = CollectionJsonHandler.GetCards();
        }

        /// <summary>
        /// Takes a collection file path as input, edits the file to turn price sections into decimals
        /// </summary>
        /// <param name="collectionFilePath"></param>
        public List<string[]> CleanCollectionFile(string collectionFilePath)
        {
            var lines = new List<string[]>();
            if (File.Exists(collectionFilePath))
            {
                lines = collectionFileToCleanLineArr(collectionFilePath);
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
            return lines;
        }

        public void LoadCollectionFile(string collectionFilePath) // todo LoadCollectionFile
        {
            var lines = collectionFileToCleanLineArr(collectionFilePath);
            foreach (var line in lines)
            {
                int cardNo;
                var cardNoResult = Int32.TryParse(line[4], out cardNo);

                if (line[0] != "Normal" && cardNoResult)
                {
                    var set = Int32.Parse(line[3]);
                    if (!Cards.ContainsKey(set))
                    {
                        Cards[set] = new Dictionary<int, ICard>();
                    }
                    decimal tempPrice;
                    if (line[6][0..3] == "Sup")
                    {
                        line[6] = "SuperRare"; 
                    }
                    if (Cards[set].ContainsKey(cardNo))
                    {
                        Cards[set][cardNo].QuantNormal = Int32.Parse(line[0]);
                        Cards[set][cardNo].QuantFoil = Int32.Parse(line[1]);
                        Cards[set][cardNo].Price = decimal.TryParse(line[7], out tempPrice) ? tempPrice : 0;
                        Cards[set][cardNo].PriceFoil = decimal.TryParse(line[8], out tempPrice) ? tempPrice : 0;
                    }
                    else
                    {
                        Cards[set][cardNo] = new Card(
                        line[2], set, cardNo, //name, set, cardno
                        (Color)Enum.Parse(typeof(Color), line[5]),
                        (Rarity)Enum.Parse(typeof(Rarity), line[6]),
                        Int32.Parse(line[0]), //quant norm
                        Int32.Parse(line[1]), //quant foil
                        decimal.TryParse(line[7], out tempPrice) ? tempPrice : 0, //price
                        decimal.TryParse(line[8], out tempPrice) ? tempPrice : 0 // foil price
                        );
                    }
                }
            }
        }

        public void SaveCollectionFile()
        {
            CollectionJsonHandler.SaveCollectionFile(Cards);
        }

        public void PrintCollectionStats()
        {
            foreach (var set in Cards.Keys)
            {
                Console.WriteLine($"Set  {set} stats:");
                Console.WriteLine($"Rare\t\tTotal\tRemain");
                decimal sumTotalPriceSet = 0;
                decimal sumPriceRemainingSet = 0;
                foreach (var rarity in Enum.GetValues(typeof(Rarity)))
                {
                    var cardsKVPairs = Cards[set].Where(cardKVPair => cardKVPair.Value.Rarity == (Rarity) rarity);

                    decimal sumTotalPrice = 0;
                    decimal sumPriceRemaining = 0;
                    foreach (var cardKV in cardsKVPairs)
                    {
                        sumTotalPrice += 4 * cardKV.Value.Price;
                        var quant = cardKV.Value.QuantNormal + cardKV.Value.QuantFoil;
                        sumPriceRemaining += quant >= 4 ? 0 : (4 - quant) * cardKV.Value.Price;
                    }
                    sumTotalPriceSet += sumTotalPrice;
                    sumPriceRemainingSet += sumPriceRemaining;

                    var tabstring = (Rarity)rarity == Rarity.Uncommon || (Rarity)rarity == Rarity.SuperRare 
                        || (Rarity)rarity == Rarity.Legendary || (Rarity)rarity == Rarity.Enchanted ? "\t" : "\t\t";
                    Console.WriteLine($"{(Rarity) rarity}:{tabstring}{sumTotalPrice}\t{sumPriceRemaining}");
                }
                
                Console.WriteLine($"Total:\t\t{sumTotalPriceSet}\t{sumPriceRemainingSet}");
                Console.WriteLine("");

            }
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
            var charList = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '.', ',' };
            for (int i = startIndex; i < stringIn.Length; i++)
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