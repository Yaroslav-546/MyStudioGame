using UnityEngine;

namespace Player
{
    public class JumpCurveFX
    {
        private readonly AnimationCurve _yAnimation;
        private readonly AnimationCurve _scaleAnimation;
        private PureAnimation _playTime;
        private float _height;

        public JumpCurveFX(Transform jumper, Transform jumpTransform, Config config, MonoBehaviour context)
        {
            _yAnimation = config.YAnimation;
            _scaleAnimation = config.ScaleAnimation;
            _height = config.Height;

            _playTime = new PureAnimation(context);
        }

        public PureAnimation PlayAnimations(Transform jumper, float duration)
        {
            _playTime.Play(duration, (float progress) =>
            {
                Vector3 position = new Vector3(0, _height * _yAnimation.Evaluate(progress));
                Vector3 scale = Vector3.one;

                return new TransformChanges(position, scale);
            });

            return _playTime;
        }
    }
}
