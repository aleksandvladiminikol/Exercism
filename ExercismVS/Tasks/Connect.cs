using System;

public enum ConnectWinner
{
    White,
    Black,
    None
}

public class Connect
{
    private string[] _input;
    private readonly int _lengthLimit;
    private readonly int _widthLimit;
    private int _currentWayLength = 0;
    private ConnectWinner _currentWinner = ConnectWinner.None;
    private (int length, int width) _startSearchPosition;

    private Dictionary<char, ConnectWinner> _players = new()
    {
        ['X'] = ConnectWinner.Black,
        ['O'] = ConnectWinner.White
    };
    private bool ContinueWay(char target, int length, int width, string[] desk, int wayLength)
    {
        bool success = (_startSearchPosition.length == 0 && length == _lengthLimit - 1)
                       || (_startSearchPosition.width == 0 && width == _widthLimit - 1)
                       || (_startSearchPosition.length == _lengthLimit - 1 && length == 0)
                       || (_startSearchPosition.width == _widthLimit - 1 && width == 0);

        if (success && _currentWayLength < wayLength)
        {
            desk[length] = desk[length].Remove(width, 1).Insert(width, "_");
            _players.TryGetValue(target, out _currentWinner);
            _currentWayLength = wayLength;
            return success;
        }

        var _desk = CopyArray(desk);
        //Move right
        if (width + 1 < _widthLimit && desk[length][width+1] == target && !success)
        {
            _desk[length] = desk[length].Remove(width, 1).Insert(width, "_");
            success = ContinueWay(target, length, width + 1, _desk, wayLength + 1);
        }
        //Move left
        _desk = CopyArray(desk);
        if (width - 1 >= 0 && desk[length][width - 1] == target && !success)
        {
            _desk[length] = _desk[length].Remove(width, 1).Insert(width, "_");
            success = ContinueWay(target, length, width - 1, _desk, wayLength + 1);
        }
        //Move down
        _desk = CopyArray(desk);

        if (length + 1 < _lengthLimit && _desk[length+1][width] == target && !success)
        {
            _desk[length] = _desk[length].Remove(width, 1).Insert(width, "_");
            success = ContinueWay( target , length + 1, width, _desk, wayLength + 1);
        }
        //Move up
        _desk = CopyArray(desk);
        if (length - 1 >= 0 && _desk[length - 1][width] ==  target && !success)
        {
            _desk[length] = _desk[length].Remove(width, 1).Insert(width, "_");
            success = ContinueWay(target, length - 1, width, _desk, wayLength + 1);
        }
        //Move right up
        _desk = CopyArray(desk);
        if (width + 1 < _widthLimit && length - 1 >= 0 && desk[length - 1][width + 1] ==  target && !success)
        {
            _desk[length] = _desk[length].Remove(width, 1).Insert(width, "_");
            success =  ContinueWay(target, length - 1, width + 1, _desk, wayLength + 1);
        }
        
        //Move left down
        _desk = CopyArray(desk);
        if (width - 1 >= 0 && length + 1 < _lengthLimit && _desk[length + 1][width - 1] == target && !success)
        {
            _desk[length] = _desk[length].Remove(width, 1).Insert(width, "_");
            success = ContinueWay(target, length + 1, width - 1, _desk, wayLength + 1);
        }
        return success;
    }
    
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
                ProcessDesk(i, 0, targetKey);
            }
            for (var j = 0; j < _widthLimit; j++)
            {
                ProcessDesk(0, j, targetKey);
            }    
        }
        return _currentWinner;
    }

    private void ProcessDesk(int startLength, int startWidth, char targetKey)
    {
        _startSearchPosition = (startLength, startWidth);
        if (_input[startLength][startWidth] == targetKey)
            ContinueWay(targetKey, 
                startLength,
                startWidth, 
                CopyArray(_input), 
                1);
    }
    

    private string[] CopyArray(string[] array) => array.Select(_ => _).ToArray();
}