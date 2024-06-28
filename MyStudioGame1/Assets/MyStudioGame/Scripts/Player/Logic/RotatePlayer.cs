using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    [SerializeField] Camera _mainCamera;

    private Vector3 _position;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    { 
        _position = _mainCamera.WorldToScreenPoint(transform.position);
        Flip();
    }

    private void Flip()
    {
        if (Input.mousePosition.x < _position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
