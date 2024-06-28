using System;
using UnityEngine;

namespace Player
{
    public class JumpCurve : IJumpable
    {
        private JumpCurvePhysics _physics;
        private Transform _jumpTransform;
        public bool _isJumped;
        private Transform _jumper;
        private Config _config;

        public JumpCurve(JumpCurvePhysics physics, Transform jumpTransform, Transform jumper, Config config)
        {
            _physics = physics;
            _jumpTransform = jumpTransform;
            _jumper = jumper;
            _config = config;
        }

        public event Action Jumped;

        public void Jump(Vector3 direction)
        {
            if (!CheckGround(_jumpTransform))
                return;

            if (_isJumped)
                return;

            Vector3 target = _jumper.position + (direction);

            _physics.Jump(direction);
            Jumped?.Invoke();
        }

        public bool CheckGround(Transform transform)
        {
            return Physics2D.OverlapCircle(transform.position, _config.Radius, _config.LayerMask);
        }
    }
}
