using System.Collections.Generic;
using UnityEngine;

public class TrickManager
{
    public List<Card> CardsPlayed = new List<Card>();
    public List<int> PlayersPlayed = new List<int>();
    public suit LeadSuit;
    public suit TrumpSuit;

    public TrickManager(suit trump)
    {
        TrumpSuit = trump;
    }

    public void AddPlay(int playerID, Card card)
    {
        if (CardsPlayed.Count == 0)
        {
            LeadSuit = card.Suit;
        }

        CardsPlayed.Add(card);
        PlayersPlayed.Add(playerID);
    }

    public int GetWinnerPlayerID()
    {
        int winnerIndex = 0;
        Card bestCard = CardsPlayed[0];

        for (int i = 1; i < CardsPlayed.Count; i++)
        {
            Card c = CardsPlayed[i];
            if (c.Suit == bestCard.Suit && c.Value > bestCard.Value)
            {
                bestCard = c;
                winnerIndex = i;
            }
            else if (c.Suit == TrumpSuit && bestCard.Suit != TrumpSuit)
            {
                bestCard = c;
                winnerIndex = i;
            }
        }

        return PlayersPlayed[winnerIndex];
    }

    public void Reset()
    {
        CardsPlayed.Clear();
        PlayersPlayed.Clear();
    }
}
