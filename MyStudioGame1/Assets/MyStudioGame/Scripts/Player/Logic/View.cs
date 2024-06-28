using UnityEngine;
using VContainer;
//using Zenject;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(AudioSource))]
    [RequireComponent(typeof(Animator))]

    public class View : MonoBehaviour
    {
        private const string Horizontal = "Horizontal";

        [SerializeField] private Transform _jumpPosition;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private ParticleSystem _jumpEffect;
        [SerializeField] private ParticleSystem _runEffect;
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Transform _checkEmpty;
        [SerializeField] private LayerMask _groundMask;

        private ViewModel _viewModel;
        private bool _isGround;
        private float _groundRadius = 0.3f;

        public Animator _animator;

        private void OnValidate()
        {
            _rigidbody2D ??= GetComponent<Rigidbody2D>();
            _spriteRenderer ??= GetComponent<SpriteRenderer>();
            _audioSource ??= GetComponent<AudioSource>();
            _animator ??= GetComponent<Animator>();
        }

        [Inject]
        public void Construct(Data data, IDataSaver saver, Config config, IMovable movable, Health playerHealth)
        {
            _viewModel = new ViewModel(config, movable, _runEffect.gameObject, _audioSource, _jumpPosition, _jumpEffect.gameObject, playerHealth, transform, this);
            SetPlayer();
            Debug.Log("InjectYes");
        }

        private void SetPlayer()
        {
            _spriteRenderer.color = _viewModel.PlayerColor;
            _spriteRenderer.sprite = _viewModel.PlayerSprite;
        }

        private void Update()
        {
            _isGround = Physics2D.OverlapCircle(_checkEmpty.position, _groundRadius, _groundMask);

            if (Input.GetAxis(Horizontal) != 0)
            {
                _viewModel.Move(gameObject.transform);
                _animator.SetFloat("moveX", Mathf.Abs(Input.GetAxisRaw(Horizontal)));
            }
            else
            {
                _viewModel.SetEffect(_runEffect.gameObject, false);
            }

            if (_viewModel.CheckGround(_jumpPosition) == false)
            {
                _viewModel.SetEffect(_jumpEffect.gameObject, true);
            }
            else
            {
                _viewModel.SetEffect(_jumpEffect.gameObject, false);
            }

            if (Input.GetKeyDown(KeyCode.Space) && _viewModel.CheckGround(_jumpPosition))
            {
                _viewModel.Jump(new Vector3(Input.GetAxis(Horizontal), 0, 0).normalized);
            }

            if (_isGround)
            {
                _animator.SetBool("Jumping", false);
            }
            else
            {
                _animator.SetBool("Jumping", true);
            }
        }

        public void SpendHealth(int value)
        {
            _viewModel.SpendHealth(value);
        }

        public void AddHealth(int value)
        {
            _viewModel.AddHealth(value);
        }
    }
}

