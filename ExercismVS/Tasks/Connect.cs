using System;
using System.Collections.Generic;
using System.Linq;
public enum ConnectWinner
{
    White,
    Black,
    None
}

public class Connect
{
    private readonly string[] _input;
    private readonly int _lengthLimit;
    private readonly int _widthLimit;
    private int _currentWayLength = 0;
    private ConnectWinner _currentWinner = ConnectWinner.None;
    private (int length, int width) _startSearchPosition;

    private readonly Dictionary<char, ConnectWinner> _players = new()
    {
        ['X'] = ConnectWinner.Black,
        ['O'] = ConnectWinner.White
    };

    public Connect(string[] input)
    {
        _input = input.Select(_ => string.Concat(_.Where(c => !char.IsWhiteSpace(c)))).ToArray();
        _lengthLimit = _input.Length;
        _widthLimit = _input[0].Length;
    }
    
    public ConnectWinner Result()
    {
        foreach (var targetKey in _players.Keys)
        {
            for (var i = 0; i < _lengthLimit; i++)
            {
                ProcessStartingPoint(i, 0, targetKey);
            }
            for (var j = 0; j < _widthLimit; j++)
            {
                ProcessStartingPoint(0, j, targetKey);
            }    
        }
        return _currentWinner;
    }

    private void ProcessStartingPoint(int startLength, int startWidth, char targetKey)
    {
        _startSearchPosition = (startLength, startWidth);
        if (_input[startLength][startWidth] == targetKey)
            ContinueWay(targetKey, 
                startLength,
                startWidth, 
                CopyArray(_input), 
                1);
    }
    
    private static void SetProcessedPlace(string[] desk, int length, int width)
    {
        desk[length] = desk[length].Remove(width, 1).Insert(width, "_");
    }

    private bool Move(char target, int length, int width, string[] desk, int wayLength, bool success)
    {
        if (width >= _widthLimit || width < 0 || 
            length >= _lengthLimit || length < 0 || 
            desk[length][width] != target || success) 
            return false;
        var copyDesk = CopyArray(desk);
        return ContinueWay(target, length, width, copyDesk, wayLength + 1);
    }

    private bool ContinueWay(char target, int length, int width, string[] desk, int wayLength)
    {
        SetProcessedPlace(desk, length, width);

        bool success = (_startSearchPosition.length == 0 && length == _lengthLimit - 1)
                       || (_startSearchPosition.width == 0 && width == _widthLimit - 1)
                       || (_startSearchPosition.length == _lengthLimit - 1 && length == 0)
                       || (_startSearchPosition.width == _widthLimit - 1 && width == 0);

        if (success && _currentWayLength < wayLength)
        {
            _players.TryGetValue(target, out _currentWinner);
            _currentWayLength = wayLength;
            return success;
        }

        success = Move(target, length, width + 1, desk, wayLength, success); // right
        success = Move(target, length, width - 1, desk, wayLength, success); // left
        success = Move(target, length + 1, width, desk, wayLength, success); // down
        success = Move(target, length - 1, width, desk, wayLength, success); // up
        success = Move(target, length - 1, width + 1, desk, wayLength, success); // up right
        success = Move(target, length + 1, width - 1, desk, wayLength, success); // left down
        
        return success;
    }
    private static string[] CopyArray(string[] array) => array.Select(_ => _).ToArray();
}