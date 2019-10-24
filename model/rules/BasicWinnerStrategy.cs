using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class BasicWinnerStrategy : IWinnerStrategy
    {
        private const bool g_DealerWinsOnEqual = true;
        public bool DoDealerWinsOnEqual()
        {
            return g_DealerWinsOnEqual;
        }
    }
}
