namespace BlackJack.model.rules
{
    class RulesFactory
    {
        public IHitStrategy GetHitRule()
        {
            return new Soft17HitStrategy();
        }
        public INewGameStrategy GetNewGameRule()
        {
            return new AmericanNewGameStrategy();
        }
        public IWinnerStrategy GetWinnerRule()
        {
            return new BasicWinnerStrategy();
        }
    }
}
