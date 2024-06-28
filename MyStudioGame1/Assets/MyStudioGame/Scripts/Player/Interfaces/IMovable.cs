using System;
using UnityEngine;

public interface IMovable
{
    public event Action Moved;
    public void Move(Transform transform);
    public bool CheckGround(Transform transform);
}

