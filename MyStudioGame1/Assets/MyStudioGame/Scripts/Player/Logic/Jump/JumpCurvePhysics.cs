using UnityEngine;

namespace Player
{
    public class JumpCurvePhysics
    {
        private JumpCurveFX _jumpFX;
        private float _lenght;
        private float _duration;
        private Transform _jumper;

        private PureAnimation _playTime;

        public JumpCurvePhysics(Transform jumper, Transform jumpTransform, Config config, MonoBehaviour context, JumpCurveFX jumpFX)
        {
            _jumper = jumper;
            _duration = config.Duration;
            _lenght = config.Height;
            _jumpFX = jumpFX;

            _playTime = new PureAnimation(context);
        }

        public void Jump(Vector3 direction)
        {
            Vector3 target = _jumper.position + (direction * _lenght);
            Vector3 startPosition = _jumper.position;
            PureAnimation fxPlayTime = _jumpFX.PlayAnimations(_jumper, _duration);

            _playTime.Play(_duration, (progress) =>
            {
                _jumper.position = Vector3.Lerp(startPosition, target, progress) + fxPlayTime.LastChanges.Position;
                _jumper.localScale = fxPlayTime.LastChanges.Scale;

                return null;
            });
        }
    }
}
