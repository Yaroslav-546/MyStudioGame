using System;
using UnityEngine;
using Player;

public class RigidbodyJump : IJumpable
{
    private Rigidbody2D _rb;
    private float _jumpForce;
    private float _radius;
    private LayerMask _groundMask;
    private Transform _jumpTransform;

    public event Action Jumped;

    public RigidbodyJump(Rigidbody2D rb, Config config, GameObject runClip, Transform jumpTransform)
    {
        _rb = rb;
        _radius = config.Radius;
        _groundMask = config.LayerMask;
        _jumpTransform = jumpTransform;
    }

    public void Jump(Vector3 direction)
    {
        if (!CheckGround(_jumpTransform))
            return;

        _rb.AddForce(Vector3.up * _jumpForce);
        Jumped?.Invoke();
    }

    public bool CheckGround(Transform transform)
    {
        return Physics2D.OverlapCircle(transform.position, _radius, _groundMask);
    }
}


