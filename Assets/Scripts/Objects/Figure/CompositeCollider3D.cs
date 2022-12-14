using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ”правл€ет стокновением всей фигуры. Ќужен дл€ одноразового столкновени€, независимо от количества столкнувшихс€ частей.
/// </summary>
public class CompositeCollider3D
{
    public Action<Collider> OnEnter;
    public Action<Collider> OnExit;

    private List<FigurePart> _parts = new List<FigurePart>();
    private int numCollisions;

    public void Constr(List<FigurePart> parts)
    {
        if(_parts != parts)
        {
            foreach (var part in _parts)
            {
                part.CollisionTrigger.OnEnter -= TriggerEnter;
                part.CollisionTrigger.OnExit -= TriggerExit;
            }

            _parts = parts;

            foreach (var part in _parts)
            {
                part.CollisionTrigger.OnEnter += TriggerEnter;
                part.CollisionTrigger.OnExit += TriggerExit;
            }
        }
    }

    public void TriggerEnter(Collider collider)
    {
        if (numCollisions <= 0)
            OnEnter?.Invoke(collider);
        numCollisions++;
    }

    public void TriggerExit(Collider collider)
    {
        numCollisions--;
        if (numCollisions <= 0)
            OnExit?.Invoke(collider);
    }
}
