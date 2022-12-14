using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private IRotateModel _model;

    private Vector3 _rotation;

    public void Constr(IRotateModel model)
    {
        _model = model;
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    private void Rotate()
    {
        _rotation = _rotation + _model.RotationVector * Time.fixedDeltaTime;
        transform.eulerAngles = _rotation;
    }
}
