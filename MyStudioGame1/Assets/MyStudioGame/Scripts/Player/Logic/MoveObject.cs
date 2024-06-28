using System;
using UnityEngine;

namespace Player
{
    public class MoveObject : IMovable
    {
        private const string Horizontal = "Horizontal";

        private float _speed;
        private float _radius;
        private LayerMask _groundMask;

        public event Action Moved;

        public MoveObject(Config config)
        {
            _speed = config.Speed;
            _radius = config.Radius;
            _groundMask = config.LayerMask;
        }

        public void Move(Transform transform)
        {
            var horizontal = Input.GetAxis(Horizontal);

            transform.position = new Vector3(transform.position.x + _speed * horizontal * Time.deltaTime,
                transform.position.y, transform.position.z);

            float distance = _speed * horizontal * Time.deltaTime;

            if (distance < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (distance > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }

            Moved?.Invoke();
        }

        public bool CheckGround(Transform transform)
        {
            return Physics2D.OverlapCircle(transform.position, _radius, _groundMask);
        }
    }
}

