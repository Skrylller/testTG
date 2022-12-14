using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveModel
{
    public Vector2 RepulsiveForceRange { get; }
    public float GravityForce { get; }
    public float StopDistance { get; }
}
