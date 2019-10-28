namespace BlackJack.model.rules
{
    class InternationalNewGameStrategy : INewGameStrategy
    {
        public bool NewGame(Deck a_deck, Dealer a_dealer, Player a_player)
        {
            a_player.DrawCardToHand(a_deck, true);

            a_dealer.DrawCardToHand(a_deck, true);

            a_player.DrawCardToHand(a_deck, true);

            return true;
        }
    }
}
