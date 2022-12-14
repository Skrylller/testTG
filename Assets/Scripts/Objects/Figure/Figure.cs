using System.Collections.Generic;
using UnityEngine;
using Zenject;

/// <summary>
/// Инициализирует Фигуру.
/// </summary>
public class Figure : MonoBehaviour
{
    private FigureModel _model;

    [SerializeField] private Rotator _rotator;
    [SerializeField] private MoverToCenter _mover;

    [SerializeField] private List<FigurePart> figureParts = new List<FigurePart>();

    private CompositeCollider3D _colliderConstructor;
    private DataContainer _dataContainer;

    [Inject]
    public void Constr(FigureModel model, ICenter center, DataContainer dataContainer)
    {
        _model = model;
        _dataContainer = dataContainer;

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
