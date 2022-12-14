using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Хранит параметры фигуры.
/// </summary>
[CreateAssetMenu(fileName = "Figure", menuName = "ScriptableObjects/FigureModel")]
public class FigureModel : ScriptableObject, IRotateModel, IMoveModel, IFigurePartModel
{
    #region Moving
    [Header("Moving")]

    [SerializeField] private Vector2 _repulsiveForceRange;
    [SerializeField] private float _gravityForce;
    [SerializeField] private float _stopDistance;

    public Vector2 RepulsiveForceRange => _repulsiveForceRange;
    public float GravityForce => _gravityForce;
    public float StopDistance => _stopDistance;
    #endregion

    #region Rotation
    [Header("Rotation")]

    [SerializeField] private Vector3 _rotationVector;

    public Vector3 RotationVector => _rotationVector;
    #endregion

    #region FigurePart
    [Header("FigurePart")]

    [SerializeField] private Material _startMaterial;
    [SerializeField] private Material _collisionMaterial;

    public Material StartMaterial => _startMaterial;
    public Material CollisionMaterial => _collisionMaterial;
    #endregion
}
