﻿using System.Collections.Generic;
using System.Linq;

namespace BlackJack.model
{
  class Player
  {
    private List<Card> m_hand = new List<Card>();
    public List<IObserver> m_observers;
    public Player()
    {
      m_observers = new List<IObserver>();
    }
    public void AddObserver(IObserver a_observer)
    {
      m_observers.Add(a_observer);
    }

    public void DealCard(Card a_card)
    {
      m_hand.Add(a_card);
    }
    public IEnumerable<Card> GetHand()
    {
      return m_hand.Cast<Card>();
    }

    public void ClearHand()
    {
      m_hand.Clear();
    }

    public void ShowHand()
    {
      foreach (Card c in GetHand())
      {
        c.Show(true);
      }
    }

    public int CalcScore()
    {
      int[] cardScores = new int[(int)model.Card.Value.Count]
          {2, 3, 4, 5, 6, 7, 8, 9, 10, 10 ,10 ,10, 11};
      int score = 0;

      foreach (Card c in GetHand())
      {
        if (c.GetValue() != Card.Value.Hidden)
        {
          score += cardScores[(int)c.GetValue()];
        }
      }

      if (score > 21)
      {
        foreach (Card c in GetHand())
        {
          if (c.GetValue() == Card.Value.Ace && score > 21)
          {
            score -= 10;
          }
        }
      }

      return score;
    }
    public void Notify()
    {
      foreach (IObserver obs in m_observers)
      {
        obs.DisplayCards();
      }
    }
  }
}
