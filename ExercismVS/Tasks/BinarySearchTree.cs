using System;
using System.Collections;
using System.Collections.Generic;

public class BinarySearchTree : IEnumerable<int>
{

    private int? _value = null;
    private BinarySearchTree? _left;
    private BinarySearchTree? _right;
    public BinarySearchTree(int value)
    {
        _value = value;
    }

    public BinarySearchTree(IEnumerable<int> values)
    {
        foreach (var value in values)
        {
            Add(value);
        }
    }

    public int? Value => _value;

    public BinarySearchTree? Left => _left;

    public BinarySearchTree? Right => _right;

    public BinarySearchTree Add(int value)
    {
        if (_value == null)
        {
            _value = value;
        }
        else if (value > _value)
        {
            if (_right == null)
            {
                _right = new BinarySearchTree(value);
            }
            else
            {
                _right.Add(value);
            }
        }
        else if (value <= _value)
        {
            if (_left == null)
            {
                _left = new BinarySearchTree(value);
            }
            else
            {
                _left.Add(value);
            }
        }

        return this;
    }

    public IEnumerator<int> GetEnumerator()
    {
        if (_left != null)
        {
            foreach (var value in _left)
            {
                yield return value;
            }
        }

        if (_value != null)
        {
            yield return _value.Value;
        }

        if (_right != null)
        {
            foreach (var value in _right)
            {
                yield return value;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}