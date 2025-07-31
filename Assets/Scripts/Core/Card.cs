
public enum suit
{
    Hearts, // dell
    Spades, // pick
    Diamonds, // khesht
    Clubs // geshniz

}


public class Card
{
    public suit Suit;
    public int Value; // 1 تا 13، که 1 = آس، 11 = سرباز، 12 = بی‌بی، 13 = شاه

    public Card(suit suit, int value)
    {
        Suit = suit;
        Value = value;
    }

    public override string ToString()
    {
        return $"{Value} of {Suit}";
    }
}