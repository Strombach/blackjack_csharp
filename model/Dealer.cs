namespace BlackJack.model
{
  class Dealer : Player
  {
    private Deck m_deck = null;
    private const int g_maxScore = 21;

    private rules.INewGameStrategy m_newGameRule;
    private rules.IHitStrategy m_hitRule;
    private rules.IWinnerStrategy m_winnerOnEqualRule;

    public Dealer(rules.RulesFactory a_rulesFactory)
    {
      m_newGameRule = a_rulesFactory.GetNewGameRule();
      m_hitRule = a_rulesFactory.GetHitRule();
      m_winnerOnEqualRule = a_rulesFactory.GetWinnerRule();
    }

    public bool NewGame(Player a_player)
    {
      if (m_deck == null || IsGameOver())
      {
        m_deck = new Deck();
        ClearHand();
        a_player.ClearHand();
        return m_newGameRule.NewGame(this, a_player);
      }
      return false;
    }

    public bool Hit(Player a_player)
    {
      if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
      {
        DrawCardToHand(a_player, true);

        return true;
      }
      return false;
    }

    public void DrawCardToHand(Player a_player, bool shouldShow)
    {
      Card c;

      c = m_deck.GetCard();
      c.Show(shouldShow);
      a_player.DealCard(c);

      a_player.Notify();
    }

    public bool Stand()
    {
      if (m_deck != null)
      {
        ShowHand();
        while (m_hitRule.DoHit(this))
        {
          m_hitRule.DoHit(this);
          DrawCardToHand(this, true);
        }
        return true;
      }
      return false;
    }
    public bool IsDealerWinner(Player a_player)
    {
      if (a_player.CalcScore() > g_maxScore)
      {
        return true;
      }
      else if (CalcScore() > g_maxScore)
      {
        return false;
      }

      return m_winnerOnEqualRule.DoCheckWinner(this, a_player);
    }

    public bool IsGameOver()
    {
      if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
      {
        return true;
      }
      return false;
    }
  }
}
