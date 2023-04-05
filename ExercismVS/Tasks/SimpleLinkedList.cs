using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SimpleLinkedListNode<T>
{
    public T Value { get; }
    public SimpleLinkedListNode<T>? Next { get; set; }
    public SimpleLinkedListNode(T value) => Value = value;
}

public class SimpleLinkedList<T> : IEnumerable<T>
{
    private SimpleLinkedListNode<T> _head;
    private SimpleLinkedListNode<T> _current;
    private SimpleLinkedListNode<T> _pointer;

    public SimpleLinkedList(T value)
    {
        InitializeHead(value);    
    }

    private void InitializeHead(T value)
    {
        _head = new SimpleLinkedListNode<T>(value);
        _current = _head;
        _pointer = _head;
        Count = 1;
    }
    
    public SimpleLinkedList(IEnumerable<T> values)
    {
        foreach (var item in values)
        {
            if (_current == null)
            {
                InitializeHead(item);
                continue;
            }
            Add(item);
        }
    }
    
    public int Count { get; private set; }

    public T Value 
    { 
        get
        {
            var result = _pointer.Value;
            _pointer = _head;
            return result;
        }
    }

    public SimpleLinkedList<T>? Next
    { 
        get
        {
            if (_pointer.Next == null)
            {
                return null;
            }
            _pointer = _pointer.Next;
            return this;
        }
        
    }

    public SimpleLinkedList<T> Add(T value)
    {
        var node = new SimpleLinkedListNode<T>(value);
        _current.Next = node;
        _current = node;
        Count++;
        return this;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var node = _head;
        while (node != null)
        {
            yield return node.Value;
            node = node.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}