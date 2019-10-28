using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Game
    {
        private model.Dealer m_dealer;
        private model.Player m_player;
        List<IObserver> m_observers;
        public Game()
        {
            m_dealer = new Dealer(new rules.RulesFactory());
            m_player = new Player();
            m_observers = new List<IObserver>();
        }

        public void AddObserver(IObserver a_observer)
        {
            m_observers.Add(a_observer);
        }
        public bool Hit()
        {
            bool doesDealerHit = m_dealer.Hit(m_player);
            foreach (IObserver obs in m_observers)
            {
                // obs.Play(obs.);
            }
            return doesDealerHit;
        }

        public bool IsGameOver()
        {
            return m_dealer.IsGameOver();
        }

        public bool IsDealerWinner()
        {
            return m_dealer.IsDealerWinner(m_player);
        }

        public bool NewGame()
        {
            return m_dealer.NewGame(m_player);
        }

        public bool Stand()
        {
            return m_dealer.Stand();
        }

        public IEnumerable<Card> GetDealerHand()
        {
            return m_dealer.GetHand();
        }

        public IEnumerable<Card> GetPlayerHand()
        {
            return m_player.GetHand();
        }

        public int GetDealerScore()
        {
            return m_dealer.CalcScore();
        }

        public int GetPlayerScore()
        {
            return m_player.CalcScore();
        }
    }
}
