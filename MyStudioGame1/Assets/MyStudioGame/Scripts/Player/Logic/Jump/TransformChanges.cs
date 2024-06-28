using UnityEngine;

public class TransformChanges
{
    private Vector3 _position;
    private Vector3 _scale;

    public Vector3 Position => _position;
    public Vector3 Scale => _scale;

    public TransformChanges(Vector3 position, Vector3 scale)
    {
        _position = position;
        _scale = scale;
    }
}

