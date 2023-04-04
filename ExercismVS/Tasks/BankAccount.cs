using System;

public class BankAccount
{
    private decimal _balance;
    private bool _isOpen = false;
    private readonly object _balanceLock = new object();
    public void Open()
    {
        if (_isOpen)
        {
            throw new InvalidOperationException("Account is already open.");
        }

        lock (_balanceLock)
        {
            _isOpen = true;
        }
    }

    public void Close()
    {
        if (!_isOpen)
        {
            throw new InvalidOperationException("Account is not opened.");
        }
        lock (_balanceLock)
        {
            _isOpen = false;
        }
    }

    public decimal Balance => _isOpen ? _balance : throw new InvalidOperationException("Account is not opened.");

    public void UpdateBalance(decimal change)
    {
        lock (_balanceLock)
        {
            var result = _balance + change;
            _balance = result;
        }
    }
}