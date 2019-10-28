namespace BlackJack.model.rules
{
    class BasicWinnerStrategy : IWinnerStrategy
    {
        private const bool g_DealerWinsOnEqual = true;
        public bool DoCheckWinner(model.Dealer a_dealer, model.Player a_player)
        {
            if (a_dealer.CalcScore() == a_player.CalcScore())
            {
                return g_DealerWinsOnEqual;
            }
            else
            {
                return a_dealer.CalcScore() > a_player.CalcScore();
            }
        }
    }
}
