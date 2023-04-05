using System;

public enum Direction
{
    North = 0,
    East = 1,
    South = 2,
    West = 3
}

public class RobotSimulator
{
    private Direction _direction;
    private int _x;
    private int _y;
    
    public RobotSimulator(Direction direction, int x, int y)
    {
        _direction = direction;
        _x = x;
        _y = y;
    }

    public Direction Direction => _direction;

    public int X => _x;

    public int Y => _y;

    public void Move(string instructions)
    {
        foreach (var command in instructions)
        {
            switch (command)
            {
                case 'L': TurnLeft();
                    break;
                case 'R':  TurnRight();
                    break;
                case 'A':  Advance();
                    break;
                default: throw new ArgumentException();
            }
            
        }
    }

    private void TurnRight()
    {
        _direction = _direction + 1 > Direction.West ? Direction.North : _direction + 1;
    }
    private void TurnLeft()
    {
        _direction = _direction - 1 < Direction.North ? Direction.West : _direction - 1;
    }

    private void Advance()
    {
        switch (_direction)
        {
            case Direction.East:
                _x++;
                break;
            case Direction.North:
                _y++;
                break;
            case Direction.West:
                _x--;
                break;
            case Direction.South:
                _y--;
                break;
        }
    }
}