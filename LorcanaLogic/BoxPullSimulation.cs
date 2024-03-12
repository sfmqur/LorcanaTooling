using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LorcanaLogic.Contracts;

namespace LorcanaLogic
{
    public class BoxPullSimulation
    {
        private readonly int _set;
        private readonly ISetPullrates _pullrates;
        private Card[] _commons;
        private Card[] _uncommons;
        private Card[] _rares;
        private Card[] _superRares;
        private Card[] _legendaries;
        private Card[] _enchanteds;
        private Random _rand; 

        public BoxPullSimulation(int set, Dictionary<int, Dictionary<int, Card>> cards)
        {
            if (!cards.Keys.Contains(set)) throw new ArgumentOutOfRangeException(nameof(set), "set does not exist in cards");
            var pullRateFactory = new PullRateFactory();
            _set = set;
            _pullrates = pullRateFactory.GetSetPullrates(set);
            _commons = selectRarity(set, cards, Rarity.Common);
            _uncommons = selectRarity(set, cards, Rarity.Uncommon);
            _rares = selectRarity(set, cards, Rarity.Rare);
            _superRares = selectRarity(set, cards, Rarity.SuperRare);
            _legendaries = selectRarity(set, cards, Rarity.Legendary);
            _enchanteds = selectRarity(set, cards, Rarity.Enchanted);
            _rand = new Random();
        }

        /// <summary>
        /// arrary of cards in pack, last card is a foil. 
        /// </summary>
        /// <returns></returns>
        public Card[] PullPack() 
        {
            var pack = new Card[12];
            var fillPointer = 0;
            
            for (var i=0; i < 6; i++) //roll commons
            {
                var choice = _rand.Next(0, _commons.Length-1);
                pack[fillPointer++] = _commons[choice];
            }
            for (var i = 0; i < 3; i++) //roll uncommons
            {
                var choice = _rand.Next(0, _uncommons.Length - 1);
                pack[fillPointer++] = _uncommons[choice];
            }
            for (var i = 0; i < 2; i++) //roll rare slots
            {
                Card[] raresArr = getRareSlotCardsArray();
                var choice = _rand.Next(0, raresArr.Length - 1);
                pack[fillPointer++] = raresArr[choice];
            }
            Card[] foilArr = getFoilSlotCardsArray();
            var choicefoil = _rand.Next(0, foilArr.Length - 1);
            pack[fillPointer++] = foilArr[choicefoil];
            return pack; 
        }

        /// <summary>
        /// returns an array of pulled non foil cards, and an array of foil cards.
        /// </summary>
        /// <returns></returns>
        public (Card[], Card[]) PullBox()
        {
            var cards = new Card[11 * 24];
            var cardsFilledPointer = 0; 
            var foils = new Card[24];
            var foilsFilledPointer = 0;

            for (var i = 0; i < 24; i++)
            {
                var pack = PullPack();
                Array.Copy(pack, 0, cards,cardsFilledPointer, 11);
                cardsFilledPointer += 11;
                foils[foilsFilledPointer++] = pack[11];
            }
            return (cards, foils);
        }

        public decimal CalcBoxValue(Card[] cards, Card[] foils)
        {
            decimal value = 0;
            foreach (var card in cards)
            {
                value += card.Price;
            }
            foreach (var foil in foils)
            {
                value += foil.PriceFoil;
            }
            return value; 
        }

        /// <summary>
        /// rolls a rarity for a rare slot, returns reference to array of that rarity's cards. 
        /// </summary>
        /// <returns></returns>
        private Card[] getRareSlotCardsArray() // todo unit test against pull rates. 
        {
            var prob = _rand.NextDouble();
            var lowerThreshold = 0.0;
            if (prob < _pullrates.GetSlotProbability(Rarity.Rare)) 
            {
                return _rares; 
            }
            lowerThreshold += _pullrates.GetSlotProbability(Rarity.Rare);
            if (lowerThreshold <= prob && prob < _pullrates.GetSlotProbability(Rarity.SuperRare) + lowerThreshold)
            {
                return _superRares;
            }
            return _legendaries;
        }

        private Card[] getFoilSlotCardsArray() // todo unit test this and validate against set pull rates. 
        {
            var prob = _rand.NextDouble();
            var lowerThreshold = 0.0;
            if (prob < _pullrates.GetSlotProbability(Rarity.Common, true))
            {
                return _commons;
            }
            lowerThreshold += _pullrates.GetSlotProbability(Rarity.Common, true);
            if (lowerThreshold <= prob && prob < _pullrates.GetSlotProbability(Rarity.Uncommon, true) + lowerThreshold)
            {
                return _uncommons;
            }
            lowerThreshold += _pullrates.GetSlotProbability(Rarity.Uncommon, true);
            if (lowerThreshold <= prob && prob < _pullrates.GetSlotProbability(Rarity.Rare, true) + lowerThreshold)
            {
                return _rares;
            }
            lowerThreshold += _pullrates.GetSlotProbability(Rarity.Rare, true);
            if (lowerThreshold <= prob && prob < _pullrates.GetSlotProbability(Rarity.SuperRare, true) + lowerThreshold)
            {
                return _superRares;
            }
            lowerThreshold += _pullrates.GetSlotProbability(Rarity.SuperRare, true);
            if (lowerThreshold <= prob && prob < _pullrates.GetSlotProbability(Rarity.Legendary, true) + lowerThreshold)
            {
                return _legendaries;
            }
            return _enchanteds;
        }
            private static Card[] selectRarity(int set, Dictionary<int, Dictionary<int, Card>> cards, Rarity rarity)
        {
            return cards[set].Where(cardKeyVal => cardKeyVal.Value.Rarity == rarity)
                .Select(carkKeyVal => carkKeyVal.Value).ToArray() ?? throw new ArgumentNullException($"set{set} {rarity}");
        }
    }
}
