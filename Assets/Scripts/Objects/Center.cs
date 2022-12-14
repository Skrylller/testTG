using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ ������.
/// </summary>
public class Center : MonoBehaviour, ICenter
{
    public Vector3 Position => transform.position;
}

/// <summary>
/// ���������� ��� ������� ������� ������. �� ���� ��� ����� ������ �������� �������.
/// </summary>
public interface ICenter
{
    public Vector3 Position { get; }
}
