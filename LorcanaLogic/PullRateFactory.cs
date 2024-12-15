using LorcanaLogic.Contracts;

namespace LorcanaLogic
{
    public class PullRateFactory
    {
        private ISetPullrates _set3Rates;

        public PullRateFactory()
        {
            _set3Rates = new Set3PullRates();// only have pullrates for set 3 but the dude that posted them said they were similar
        }

        public ISetPullrates GetSetPullrates(int set)
        {
            switch (set)
            {
                case 1: return _set3Rates;
                case 2: return _set3Rates;
                case 3: return _set3Rates;
                case 4: return _set3Rates;
                default: return _set3Rates;
            }
        }
    }
}