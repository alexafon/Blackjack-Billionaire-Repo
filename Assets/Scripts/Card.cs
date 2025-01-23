using UnityEngine;

public class Card
{
    public enum Suit { Hearts, Diamonds, Clubs, Spades }
    public Suit CardSuit { get; private set; }
    public int Value { get; private set; }

    public Card(Suit suit, int value)
    {
        CardSuit = suit;
        Value = value;
    }
}
