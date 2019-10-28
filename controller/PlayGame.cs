using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame : model.IObserver
    {
        view.IView m_view;
        model.Game m_game;
        public PlayGame(model.Game a_game, view.IView a_view)
        {
            m_view = a_view;
            m_game = a_game;

            a_game.AddObservers(this);
        }
        public bool Play()
        {
            this.DisplayCards();

            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
            }

            char input = m_view.GetInput();

            if (input == view.InputLetters.toPlay)
            {
                m_game.NewGame();
            }
            else if (input == view.InputLetters.toHit)
            {
                m_game.Hit();
            }
            else if (input == view.InputLetters.toStand)
            {
                m_game.Stand();
            }

            return input != view.InputLetters.toQuit;
        }

        public void DisplayCards()
        {
            System.Threading.Thread.Sleep(1000);

            m_view.DisplayWelcomeMessage();

            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());

        }
    }
}
