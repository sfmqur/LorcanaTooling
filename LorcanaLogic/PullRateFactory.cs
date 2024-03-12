using LorcanaLogic.Contracts;

namespace LorcanaLogic
{
    public class PullRateFactory
    {
        private ISetPullrates _set1Rates;
        private ISetPullrates _set2Rates; // with enough sets, pull this into a factory
        private ISetPullrates _set3Rates;

        public PullRateFactory()
        {
            _set1Rates = new Set3PullRates();
            _set2Rates = new Set3PullRates(); // only have pullrates for set 3 but the dude that posted them said they were similar
            _set3Rates = new Set3PullRates();
        }

        public ISetPullrates GetSetPullrates(int set)
        {
            switch (set)
            {
                case 1: return _set1Rates;
                case 2: return _set2Rates;
                case 3: return _set3Rates;
                default: throw new ArgumentException($"Invalid set: {set}");
            }
        }
    }
}