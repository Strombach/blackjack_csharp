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
      return new InternationalNewGameStrategy();
    }
    public IWinnerStrategy GetWinnerRule()
    {
      return new PlayerWinsOnEqual();
    }
  }
}
