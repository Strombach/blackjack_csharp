namespace BlackJack.model.rules
{
    interface IWinnerStrategy
    {
        bool DoCheckWinner(model.Dealer a_dealer, model.Player a_player);
    }
}
