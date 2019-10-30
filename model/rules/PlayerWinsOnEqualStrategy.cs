namespace BlackJack.model.rules
{
  class PlayerWinsOnEqual : IWinnerStrategy
  {
    public bool DoCheckWinner(model.Dealer a_dealer, model.Player a_player)
    {
      if (a_dealer.CalcScore() == a_player.CalcScore())
      {
        return false;
      }
      else
      {
        return a_dealer.CalcScore() > a_player.CalcScore();
      }
    }
  }
}
