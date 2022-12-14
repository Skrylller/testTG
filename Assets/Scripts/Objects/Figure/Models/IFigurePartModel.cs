using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFigurePartModel
{
    public Material StartMaterial { get; }
    public Material CollisionMaterial { get; }
}
