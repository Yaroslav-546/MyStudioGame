using System;
using UnityEngine;

public interface IJumpable
{
    public event Action Jumped;
    public void Jump(Vector3 direction);
    public bool CheckGround(Transform transform);
}
