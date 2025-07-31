using System.Collections.Generic;

public class Player
{
    public int ID; // 0 تا 3
    public List<Card> Hand = new List<Card>();

    public Player(int id)
    {
        ID = id;
    }

    public void AddCard(Card card)
    {
        Hand.Add(card);
    }

    public void RemoveCard(Card card)
    {
        Hand.Remove(card);
    }

    // فعلاً ساده‌ترین کارت ممکن رو بازی می‌کنه
    public Card PlayCard(Card leadCard, suit trumpSuit)
    {
        // فعلاً کارت اول رو بازی کن
        Card cardToPlay = Hand[0];
        Hand.RemoveAt(0);
        return cardToPlay;
    }
}