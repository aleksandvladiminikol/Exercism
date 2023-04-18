using System;
using System.Collections.Generic;
using System.Linq;

public enum Suits
{
    Clubs,
    Diamonds,
    Hearts,
    Spades
}

public class Card: IComparable<Card>
{
    public Card(string card)
    {
        if (card.Length > 3)
            throw new ArgumentException("Invalid card length");
        
        var suit = card[^1];
        Suit = suit switch
        {
            'D' => Suits.Diamonds,
            'H' => Suits.Hearts,
            'S' => Suits.Spades,
            'C' => Suits.Clubs,
            _ => throw new ArgumentException("Invalid suit")
        };
        
        var value =  card.Remove(card.Length - 1);
        if (Int32.TryParse(value, out var number))
        {
            Value = number;
        }
        else
        {
            Value = card[0] switch
            {
                'J' => 11,
                'Q' => 12,
                'K' => 13,
                'A' => 14,
                _ => throw new ArgumentException("Invalid value")
            };
        }
    }
    public Card (int value, Suits suit)
    {
        Value = value;
        Suit = suit;
    }
    
    public int Value { get; }
    public Suits Suit { get; }

    public int CompareTo(Card? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        return Value.CompareTo(other.Value);
    }
}

public class Hand : IComparable<Hand>
{
    private readonly string _handString;
    private Card[] _cards = new Card[5];
    public Hand(string hand)
    {
        _handString = hand;
        var cards = hand.Split(' ');
        if (cards.Length != 5)
            throw new ArgumentException("Invalid hand length");
        for (var i = 0; i < 5; i++)
            _cards[i] = new Card(cards[i]);

        Array.Sort(_cards);
    }
    private IOrderedEnumerable<IGrouping<int, Card>> SameCardsGroup =>
        _cards.GroupBy(_ => _.Value).OrderByDescending(_ => _.Count()).ThenByDescending(_ => _.Key);

    private int MostCommonCardCount => SameCardsGroup.First().Count();
    private bool ContainsPair => MostCommonCardCount == 2;
    private bool ContainsThreeOfAKind => MostCommonCardCount == 3;
    private bool ContainsFourOfAKind => MostCommonCardCount == 4;
    private bool ContainsFullHouse => ContainsThreeOfAKind && SameCardsGroup.Count() == 2;
    private bool ContainsTwoPairs => _cards.GroupBy(_ => _.Value).Count(_ => _.Count() == 2) == 2;
    private bool ContainsFlush => _cards.GroupBy(_ => _.Suit).Count() == 1;

    private bool ContainsStraight()
    {
        var previous = _cards[0].Value;
        for (var i = 1; i < 4; i++)
        {
            if (_cards[i].Value != previous + 1)
                return false;
            previous = _cards[i].Value;
        }

        if (_cards[4].Value != previous + 1)
        {
            if (!(_cards[4].Value == 14 && _cards[0].Value == 2))
                return false;
            _cards[4] = new Card(1, _cards[4].Suit);
            Array.Sort(_cards);
        }
        return true;
    } 
    private bool ContainsStraightFlush => ContainsStraight() && ContainsFlush;
    public override string ToString() => _handString;

    public int CompareTo(Hand other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        return CompareHands(other);
    }

    private int CompareHighCard(Hand other)
    {
        for (var i = 1; i <= 5; i++)
        {
            if (_cards[^i].Value > other._cards[^i].Value)
                return 1;
            else if (_cards[^i].Value < other._cards[^i].Value)
                return -1;
        }
        return 0;
    }

    private int CompareHands(Hand other)
    {
        switch (ContainsStraightFlush)
        {
            case true when other.ContainsStraightFlush:
                return CompareHighCard(other);
            case true:
                return 1;
            default:
            {
                if (other.ContainsStraightFlush)
                    return -1;
                break;
            }
        }

        switch (ContainsFourOfAKind)
        {
            case true when other.ContainsFourOfAKind:
                if (SameCardsGroup.First().Key > other.SameCardsGroup.First().Key)
                    return 1;
                else if (SameCardsGroup.First().Key == other.SameCardsGroup.First().Key)
                    return CompareHighCard(other);
                else
                    return 0;
            case true:
                return 1;
            default:
            {
                if (other.ContainsFourOfAKind)
                    return -1;
                break;
            }
        }

        switch (ContainsFullHouse)
        {
            case true when other.ContainsFullHouse:
                if (SameCardsGroup.First().Key > other.SameCardsGroup.First().Key)
                    return 1;
                else if (SameCardsGroup.First().Key < other.SameCardsGroup.First().Key)
                    return -1;
                else if (SameCardsGroup.ElementAt(1).Key > other.SameCardsGroup.ElementAt(1).Key)
                    return 1;
                else if (SameCardsGroup.ElementAt(1).Key < other.SameCardsGroup.ElementAt(1).Key)
                    return -1;
                else 
                    return 0;
            case true:
                return 1;
            default:
            {
                if (other.ContainsFullHouse)
                    return -1;
                break;
            }
        }

        switch (ContainsFlush)
        {
            case true when other.ContainsFlush:
                return CompareHighCard(other);
            case true:
                return 1;
            default:
            {
                if (other.ContainsFlush)
                    return -1;
                break;
            }
        }

        switch (ContainsStraight())
        {
            case true when other.ContainsStraight():
                return CompareHighCard(other);
            case true:
                return 1;
            default:
            {
                if (other.ContainsStraight())
                    return -1;
                break;
            }
        }

        switch (ContainsThreeOfAKind)
        {
            case true when other.ContainsThreeOfAKind:
                if (SameCardsGroup.First().Key > other.SameCardsGroup.First().Key)
                    return 1;
                else if (SameCardsGroup.First().Key < other.SameCardsGroup.First().Key)
                    return -1;
                else
                    return CompareHighCard(other);
            case true:
                return 1;
            default:
            {
                if (other.ContainsThreeOfAKind)
                    return -1;
                break;
            }
        }

        switch (ContainsTwoPairs)
        {
            case true when other.ContainsTwoPairs:
                if (SameCardsGroup.First().Key > other.SameCardsGroup.First().Key)
                    return 1;
                else if (SameCardsGroup.First().Key < other.SameCardsGroup.First().Key)
                    return -1;
                else if (SameCardsGroup.ElementAt(1).Key > other.SameCardsGroup.ElementAt(1).Key)
                    return 1;
                else if (SameCardsGroup.ElementAt(1).Key < other.SameCardsGroup.ElementAt(1).Key)
                    return -1;
                else if (SameCardsGroup.First().Key == other.SameCardsGroup.First().Key &&
                         SameCardsGroup.ElementAt(1).Key == other.SameCardsGroup.ElementAt(1).Key)
                    return CompareHighCard(other);
                else
                    return -1;
            case true:
                return 1;
            default:
            {
                if (other.ContainsTwoPairs)
                    return -1;
                break;
            }
        }

        switch (ContainsPair)
        {
            case true when other.ContainsPair:
                if (SameCardsGroup.First().Key > other.SameCardsGroup.First().Key)
                    return 1;
                else if (SameCardsGroup.First().Key == other.SameCardsGroup.First().Key)
                    return CompareHighCard(other);
                else
                    return 0;
            case true:
                return 1;
            default:
            {
                if (other.ContainsPair)
                    return -1;
                break;
            }
        }

        return CompareHighCard(other);
    }

}

public static class Poker
{
    public static IEnumerable<string> BestHands(IEnumerable<string> hands)
    {
        var bestHands = new List<Hand>();
        foreach (var hand in hands)
        {
            var newHand = new Hand(hand);
            if (bestHands.Count == 0)
            {
                bestHands.Add(newHand);
                continue;
            }

            var compare = newHand.CompareTo(bestHands[0]);
            switch (compare)
            {
                case 1:
                    bestHands.Clear();
                    bestHands.Add(newHand);
                    break;
                case 0:
                    bestHands.Add(newHand);
                    break;
            }
        }
        return bestHands.Select(_ => _.ToString()).ToArray();
    }
}