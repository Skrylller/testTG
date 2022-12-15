using UnityEngine;

/// <summary>
/// ������ ������.
/// </summary>
public class Center : MonoBehaviour, ICenter
{
    public Vector3 Position => transform.position;
}

/// <summary>
/// ���������� ��� ����������� DI ���������� � ������� ������� ������.
/// </summary>
public interface ICenter
{
    public Vector3 Position { get; }
}
