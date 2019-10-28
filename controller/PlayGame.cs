using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame : model.IObserver
    {
        view.IView m_view;
        public PlayGame(view.IView a_view)
        {
            m_view = a_view;
        }
        public bool Play(model.Game a_game)
        {
            a_game.AddObserver(this);

            m_view.DisplayWelcomeMessage();

            m_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            m_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                m_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            char input = m_view.GetInput();

            if (input == view.InputLetters.toPlay)
            {
                a_game.NewGame();
            }
            else if (input == view.InputLetters.toHit)
            {
                a_game.Hit();
            }
            else if (input == view.InputLetters.toStand)
            {
                a_game.Stand();
            }

            return input != view.InputLetters.toQuit;
        }

        public void CardDrawn(model.Card card)
        {
            m_view.DisplayCard(card);
        }
    }
}
