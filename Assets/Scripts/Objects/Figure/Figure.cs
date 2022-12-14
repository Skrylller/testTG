using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// Инициализирует Фигуру.
/// </summary>
[RequireComponent(typeof(Rotator), typeof(MoverToCenter))]
public class Figure : MonoBehaviour
{
    private FigureModel _model;
    private DataContainer _dataContainer;

    [SerializeField] private List<FigurePart> figureParts = new List<FigurePart>();

    private Rotator _rotator;
    private MoverToCenter _mover;

    private CompositeCollider3D _colliderConstructor;

    [Inject]
    public void Constr(FigureModel model, ICenter center, DataContainer dataContainer)
    {
        _model = model;
        _dataContainer = dataContainer;

        _mover ??= GetComponent<MoverToCenter>();
        _rotator ??= GetComponent<Rotator>();

        if (_colliderConstructor == null)
        {
            _colliderConstructor = new CompositeCollider3D();
            _colliderConstructor.Constr(figureParts);

            _colliderConstructor.OnEnter += _mover.Collision;
            _colliderConstructor.OnEnter += Collision;
        }

        foreach (FigurePart part in figureParts)
        {
            part.Constr(_model);
        }

        _mover.Constr(_model, center);
        _rotator.Constr(_model);
    }

    private void Collision(Collider collider)
    {
        _dataContainer.PlusCollision();
    }
}
