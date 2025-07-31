using UnityEngine;
using System.Collections.Generic;

public class DeckManager : MonoBehaviour
{
    public List<Card> deck = new List<Card>();

    public DeckManager()
    {
        CreateDeck();
        ShuffleDeck();
    }

    void CreateDeck()
    {
        deck.Clear();
        foreach (suit suit in System.Enum.GetValues(typeof(suit)))
        {
            for (int i = 1; i <= 13; i++)
            {
                deck.Add(new Card(suit, i));
            }
        }
    }

    void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            int rand = Random.Range(i, deck.Count);
            var temp = deck[i];
            deck[i] = deck[rand];
            deck[rand] = temp;
        }
    }

    public void DealCards(List<Player> players)
    {
        int index = 0;
        while (deck.Count > 0)
        {
            Card card = deck[0];
            deck.RemoveAt(0);
            players[index % 4].AddCard(card);
            index++;
        }
    }
}