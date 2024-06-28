using UnityEngine;

namespace Player
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Game/new PlayerConfig")]
    public class Config : ScriptableObject
    {
        [Header("Player")]
        [Space(32)]
        [Header("Color and Sprite")]
        [SerializeField] private Color _color;
        [SerializeField] private Sprite _sprite;
        [Header("Jump Settings")]
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private AudioClip _jumpClip;
        [SerializeField] private float _radius;
        [SerializeField] private AnimationCurve _yAnimation;
        [SerializeField] private AnimationCurve _scaleAnimation;
        [SerializeField] private float _duration;
        [SerializeField] private float _height;
        [Header("Run Settings")]
        [SerializeField] private AudioClip _runClip;
        [SerializeField] private float _stepsDistance;
        [SerializeField] private float _speed;

        public Color Color => _color;
        public LayerMask LayerMask => _layerMask;
        public AudioClip JumpClip => _jumpClip;
        public AudioClip RunClip => _runClip;
        public Sprite Sprite => _sprite;
        public float Radius => _radius;
        public float StepsDistance => _stepsDistance;
        public float Speed => _speed;
        public AnimationCurve YAnimation => _yAnimation;
        public AnimationCurve ScaleAnimation => _scaleAnimation;
        public float Duration => _duration;
        public float Height => _height;

    }
}

