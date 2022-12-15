using UnityEngine;

/// <summary>
/// Обьект центра.
/// </summary>
public class Center : MonoBehaviour, ICenter
{
    public Vector3 Position => transform.position;
}

/// <summary>
/// Существует для уникального DI контейнера и скрытия обьекта центра.
/// </summary>
public interface ICenter
{
    public Vector3 Position { get; }
}
