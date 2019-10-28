namespace BlackJack.controller
{
    class PlayGame : model.IObserver
    {
        view.IView m_view;
        view.InputLetter m_inputLetter;
        model.Game m_game;
        public PlayGame(model.Game a_game, view.IView a_view, view.InputLetter a_inputLetter)
        {
            m_view = a_view;
            m_inputLetter = a_inputLetter;
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

            if (input == m_inputLetter.getPlay())
            {
                m_game.NewGame();
            }
            else if (input == m_inputLetter.getHit())
            {
                m_game.Hit();
            }
            else if (input == m_inputLetter.getStand())
            {
                m_game.Stand();
            }

            return input != m_inputLetter.getQuit();
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
