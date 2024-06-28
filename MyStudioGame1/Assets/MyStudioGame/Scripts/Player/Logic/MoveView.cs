using System;
using UnityEngine;

namespace Player
{
    public class MoveView : IDisposable
    {
        private const string Horizontal = "Horizontal";

        private IMovable _movable;
        private AudioSource _audioSource;
        private AudioClip _runClip;
        private GameObject _auidioClipObject;
        private Transform _jumpTransform;
        private float _stepsDistance;
        private float _coveredDistance = 0f;
        private float _speed;

        public MoveView(IMovable movable, AudioSource source, GameObject runClip, Transform jumpTransform, Config config)
        {
            _movable = movable;
            _audioSource = source;
            _auidioClipObject = runClip;
            _jumpTransform = jumpTransform;
            _stepsDistance = config.StepsDistance;
            _speed = config.Speed;
            _runClip = config.RunClip;

            _movable.Moved += OnMoved;
        }

        private void OnMoved()
        {
            if (_movable.CheckGround(_jumpTransform) == true)
                SetEffect(_auidioClipObject, true);

            float distance = _speed * Input.GetAxis(Horizontal) * Time.deltaTime;
            _coveredDistance += Mathf.Abs(distance);

            if (_coveredDistance >= _stepsDistance)
            {
                _coveredDistance -= _stepsDistance;
                _audioSource.clip = _runClip;
                _audioSource.Play();
            }
        }

        public void Dispose()
        {
            _movable.Moved -= OnMoved;
        }

        private void SetEffect(GameObject effect, bool active)
        {
            effect.SetActive(active);
        }
    }
}
