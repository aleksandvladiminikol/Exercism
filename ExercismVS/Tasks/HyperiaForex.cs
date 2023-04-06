using System;
public struct CurrencyAmount: IEquatable<CurrencyAmount>, IComparable<CurrencyAmount>
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }
    public bool Equals(CurrencyAmount other)
    {
        if (currency != other.currency)
            throw new ArgumentException();
        return amount == other.amount;
    }
    
    public int GetHashCode(CurrencyAmount obj)
    {
        return obj.amount.GetHashCode() ^ obj.currency.GetHashCode();
    }

    public int CompareTo(CurrencyAmount other)
    {
        var amountComparison = amount.CompareTo(other.amount);
        if (amountComparison != 0) return amountComparison;
        return decimal.Compare(amount, other.amount);
    }
    public static void ValidateCompatibility(CurrencyAmount c1, CurrencyAmount c2)
    {
        if (c1.currency != c2.currency)
            throw new ArgumentException();
    }
    public static CurrencyAmount operator +(CurrencyAmount c1, CurrencyAmount c2)
    {
        ValidateCompatibility(c1, c2);
        return new CurrencyAmount(c1.amount + c2.amount, c1.currency);
    }
    public static CurrencyAmount operator -(CurrencyAmount c1, CurrencyAmount c2)
    {
        ValidateCompatibility(c1, c2);
        return new CurrencyAmount(c1.amount - c2.amount, c1.currency);
    }
    public static CurrencyAmount operator *(CurrencyAmount c1, CurrencyAmount c2)
    {
        ValidateCompatibility(c1, c2);
        return new CurrencyAmount(c1.amount * c2.amount, c1.currency);
    }

    public static CurrencyAmount operator /(CurrencyAmount c1, CurrencyAmount c2)
    {
        ValidateCompatibility(c1, c2);
        return new CurrencyAmount(c1.amount / c2.amount, c1.currency);
    }

    public static CurrencyAmount operator +(decimal c1, CurrencyAmount c2)
    {
        return new CurrencyAmount(c1 + c2.amount, c2.currency);
    }
    public static CurrencyAmount operator -(decimal c1, CurrencyAmount c2)
    {
        return new CurrencyAmount(c1 - c2.amount, c2.currency);
    }
    public static CurrencyAmount operator *(decimal c1, CurrencyAmount c2)
    {
        return new CurrencyAmount(c1 * c2.amount, c2.currency);
    }
    public static CurrencyAmount operator /(decimal c1, CurrencyAmount c2)
    {
        return new CurrencyAmount(c1 / c2.amount, c2.currency);
    }
    public static CurrencyAmount operator +(CurrencyAmount c1, decimal c2)
    {
        return new CurrencyAmount(c1.amount + c2, c1.currency);
    }
    public static CurrencyAmount operator -(CurrencyAmount c1, decimal c2)
    {
        return new CurrencyAmount(c1.amount - c2, c1.currency);
    }
    public static CurrencyAmount operator *(CurrencyAmount c1, decimal c2)
    {
        return new CurrencyAmount(c1.amount * c2, c1.currency);
    }
    public static CurrencyAmount operator /(CurrencyAmount c1, decimal c2)
    {
        return new CurrencyAmount(c1.amount / c2, c1.currency);
    }
    public static bool operator ==(CurrencyAmount c1, CurrencyAmount c2)
    {
        ValidateCompatibility(c1, c2);
        return c1.Equals(c2);
    }
    public static bool operator !=(CurrencyAmount c1, CurrencyAmount c2)
    {
        ValidateCompatibility(c1, c2);
        return !c1.Equals(c2);
    }
    public static bool operator <(CurrencyAmount c1, CurrencyAmount c2)
    {
        ValidateCompatibility(c1, c2);
        return c1.CompareTo(c2) < 0;
    }
    public static bool operator >(CurrencyAmount c1, CurrencyAmount c2)
    {
        ValidateCompatibility(c1, c2);
        return c1.CompareTo(c2) > 0;
    }
    public static bool operator <=(CurrencyAmount c1, CurrencyAmount c2)
    {
        ValidateCompatibility(c1, c2);
        return c1.CompareTo(c2) <= 0;
    }
    public static bool operator >=(CurrencyAmount c1, CurrencyAmount c2)
    {
        ValidateCompatibility(c1, c2);
        return c1.CompareTo(c2) >= 0;
    }
    public static implicit operator decimal (CurrencyAmount c1)
    {
        return (decimal) c1.amount;
    }
    public static implicit operator double (CurrencyAmount c1)
    {
        return (double) c1.amount;
    }
    
}
