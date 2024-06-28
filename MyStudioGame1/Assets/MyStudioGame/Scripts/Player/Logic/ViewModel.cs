using UnityEngine;
namespace Player
{
    public class ViewModel
    {
        private Config _config;
        private IMovable _movable;
        private IJumpable _jumpable;
        private MoveView _moveView;
        private JumpView _jumpView;
        private Health _health;
        private JumpCurve _jumpCurve;

        public Color PlayerColor => _config.Color;
        public Sprite PlayerSprite => _config.Sprite;

        public ViewModel(Config config, IMovable movable, GameObject runClip, AudioSource audioSource,
            Transform jumpTransform, GameObject jumpClipObject, Health health, Transform jumper, MonoBehaviour context)
        {
            _config = config;
            _movable = movable;

            var fx = new JumpCurveFX(jumper, jumpTransform, config, context);
            var physics = new JumpCurvePhysics(jumper, jumpTransform, config, context, fx);

            _moveView = new MoveView(_movable, audioSource, runClip, jumpTransform, _config);
            _jumpable = new JumpCurve(physics, jumpTransform,jumper , config);
            _jumpView = new JumpView(_jumpable, audioSource, jumpClipObject, config);
            _health = health;
        }

        public void Move(Transform transform)
        {
            _movable.Move(transform);
        }

        public void Jump(Vector3 direction)
        {
            _jumpable.Jump(direction);
        }

        public bool CheckGround(Transform transform)
        {
            return _jumpable.CheckGround(transform);
        }

        public void SpendHealth(int value)
        {
            _health.SpendHealth(value);
        }

        public void AddHealth(int value)
        {
            _health.AddHealth(value);
        }

        public void SetEffect(GameObject effect, bool active)
        {
            effect.SetActive(active);
        }
    }
}
