using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoverToCenter : MonoBehaviour
{
    private IMoveModel _model;

    private ICenter _center;

    private Vector3 _moveDirectional;
    private float _moveSpeed;

    public void Constr(IMoveModel model, ICenter center)
    {
        _model = model;
        _center = center;
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Collision(Collider collisionObj)
    {
        _moveSpeed = -UnityEngine.Random.Range(Math.Abs(_model.RepulsiveForceRange.x), Math.Abs(_model.RepulsiveForceRange.y));
        _moveDirectional = -GetDirectional(collisionObj.transform.position, transform.position) * _moveSpeed;
        transform.Translate(_moveDirectional * Time.fixedDeltaTime, Space.World);
    }

    private void Move()
    {
        if(_moveSpeed >= 0 && Vector3.Distance(transform.position, _center.Position) <= _model.StopDistance)
        {
            _moveSpeed = 0;
            return;
        }

        _moveSpeed += _model.GravityForce * Time.fixedDeltaTime;
        _moveDirectional = GetDirectional(transform.position, _center.Position) * _moveSpeed;
        transform.Translate(_moveDirectional * Time.fixedDeltaTime, Space.World);
    }

    /// <summary>
    /// Определяет коефицент векторов расстояния одного обьекта от другого
    /// </summary>
    /// <param name="pos1"> центр векторов </param>
    /// <param name="pos2"> направление векторов </param>
    /// <returns></returns>
    private Vector3 GetDirectional(Vector3 pos1, Vector3 pos2)
    {
        Vector3 directional = pos2 - pos1;

        float sumVectors = Mathf.Abs(directional.x) + Mathf.Abs(directional.y) + Mathf.Abs(directional.z);

        return new Vector3(directional.x / sumVectors, directional.y / sumVectors, directional.z / sumVectors);
    }
}
