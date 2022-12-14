using System;

public class DataContainer
{
    private int _collisions;
    private DateTime _resetTime;

    /// <summary>
    /// ���������� ������������ ���� ����� ���� � ������.
    /// </summary>
    public int Collisions 
    { 
        get 
        {
            return _collisions / 2; 
        }
    }

    /// <summary>
    /// ����� ��������� �� ������ ��������.
    /// </summary>
    public int Time
    {
        get
        {
            return (int)(DateTime.UtcNow - _resetTime).TotalSeconds;
        }
    }

    public DataContainer()
    {
        Reset();
    }

    public void Reset()
    {
        _collisions = 0;
        _resetTime = DateTime.UtcNow;
    }

    public void PlusCollision()
    {
        _collisions++;
    }
}
