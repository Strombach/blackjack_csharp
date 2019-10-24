using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class BasicHitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            IEnumerable<Card> cards = a_dealer.GetHand();

            foreach (Card card in cards)
            {
                if (card.GetValue() == Card.Value.Ace && a_dealer.CalcScore() == g_hitLimit)
                {
                    return true;
                }
            }
            return a_dealer.CalcScore() < g_hitLimit;
        }
    }
}
