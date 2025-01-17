﻿namespace BlackJack.model.rules
{
    class BasicHitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;
        public bool DoHit(model.Player a_dealer)
        {
            return a_dealer.CalcScore() < g_hitLimit;
        }
    }
}
