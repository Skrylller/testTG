using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Меняет цвет у части фигуры при столкновении.
/// </summary>
public class FigurePart : MonoBehaviour
{
    private IFigurePartModel _model;

    [SerializeField] private Renderer _renderer;
    [SerializeField] private CollisionTrigger _collisionTrigger;

    public CollisionTrigger CollisionTrigger => _collisionTrigger;

    public void Constr(IFigurePartModel model)
    {
        _model = model;

        _renderer.material = _model.StartMaterial;
    }

    private void OnEnable()
    {
        _collisionTrigger.OnEnter += OnCollision;
    }

    private void OnDisable()
    {
        _collisionTrigger.OnEnter -= OnCollision;
    }

    private void OnCollision(Collider collider)
    {
        _renderer.material = _model.CollisionMaterial;
    }
}
