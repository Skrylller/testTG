using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Обьект центра.
/// </summary>
public class Center : MonoBehaviour, ICenter
{
    public Vector3 Position => transform.position;
}

/// <summary>
/// Существует для скрытия обьекта центра. От него нам нужно только получать позицию.
/// </summary>
public interface ICenter
{
    public Vector3 Position { get; }
}
