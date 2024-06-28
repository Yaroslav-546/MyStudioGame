using System;
using UnityEngine;

public interface IMovableEnemy
{
    public void Move(Vector3 direction);
    public event Action Moved;
}

