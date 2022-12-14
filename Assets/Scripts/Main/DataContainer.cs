using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataContainer : MonoBehaviour
{
    private int _collisions;
    private DateTime _resetTime;

    /// <summary>
    /// Количество столкновений двух фигур друг с другом.
    /// </summary>
    public int Collisions 
    { 
        get 
        {
            return _collisions / 2; 
        }
    }

    /// <summary>
    /// Время прошедшее со сброса счетчика.
    /// </summary>
    public int Time
    {
        get
        {
            return (int)(DateTime.UtcNow - _resetTime).TotalSeconds;
        }
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
