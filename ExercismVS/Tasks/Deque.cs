namespace Exercism.Tasks;

using System;

public class Deque<T>
{
    private class Node
    {
        public readonly T _value;
        public Node _previous;
        public Node _next;
        public Node(T value = default(T)) => _value = value;
        public Node(T value, Node previous, Node next) : this(value) => (_previous, _next) = (previous, next);
        public void Append(T value) => _next = _next._previous = new Node(value, this, _next);
        public T Remove()
        {
            _previous._next = _next;
            _next._previous = _previous;
            _previous = _next = null;
            return _value;
        }
    }
    private readonly Node head = new Node();
    public Deque() => head._next = head._previous = head;
    public void Push(T value) => head.Append(value);
    public T Pop() => head._next.Remove();
    public void Unshift(T value) => head._previous.Append(value);
    public T Shift() => head._previous.Remove();
}