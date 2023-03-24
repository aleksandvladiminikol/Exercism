using System;
using System.Collections.Generic;
public class CircularBuffer<T>
{
    private readonly List<T> _storage = new();
    private int _capacity;
    public CircularBuffer(int capacity)
    {
        _capacity = capacity;
    }

    public T Read()
    {
        if (_storage.Count == 0)
            throw new InvalidOperationException();
        var value = _storage[0];
        Clear();
        return value;
    }

    public void Write(T value)
    {
        if (_storage.Count == _capacity)
            throw new InvalidOperationException();
        _storage.Add(value);
    }

    public void Overwrite(T value)
    {
        if (_storage.Count == _capacity)
            Clear();
        Write(value);
    }

    public void Clear()
    {
        if (_storage.Count > 0)
            _storage.RemoveAt(0);
    }
}