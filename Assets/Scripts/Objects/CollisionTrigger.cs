using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CollisionTrigger : MonoBehaviour
{
    public Action<Collider> OnEnter;
    public Action<Collider> OnExit;

    private void OnTriggerEnter(Collider other)
    {
        OnEnter?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        OnExit?.Invoke(other);
    }
}
