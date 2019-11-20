namespace BlackJack.model.rules
{
  class InternationalNewGameStrategy : INewGameStrategy
  {
    public bool NewGame(Dealer a_dealer, Player a_player)
    {
      a_dealer.DrawCardToHand(a_player, true);

      a_dealer.DrawCardToHand(a_dealer, true);

      a_dealer.DrawCardToHand(a_player, true);

      return true;
    }
  }
}
