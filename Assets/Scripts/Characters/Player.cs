using UnityEngine;

namespace Characters
{
    public class Player : MonoBehaviour
    {
        public static Player singleton { get; private set; }

        public Joystick joystick;
        private Rigidbody2D _rigidbody2D;
        private Animator _animator;

        public float speed = 3f;
        private float _horizontal;
        private float _vertical;
        private float _rotZ;
        
        private static readonly int IsToWalk = Animator.StringToHash("isToWalk");

        private void Awake()
        {
            if (!singleton)
            {
                singleton = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _horizontal = joystick.Horizontal;
            _vertical = joystick.Vertical;

            StartAnimationToWalk(_horizontal, _vertical);
            Rotation();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            Vector2 position = _rigidbody2D.position;

            position.x = position.x + speed * _horizontal * Time.deltaTime;
            position.y = position.y + speed * _vertical * Time.deltaTime;

            _rigidbody2D.MovePosition(position);
        }

        private void Rotation()
        {
            _rotZ = Mathf.Atan2(-_vertical, -_horizontal) * Mathf.Rad2Deg;

            if (_horizontal != 0 || _vertical != 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, _rotZ);
            }
        }

        private void StartAnimationToWalk(float h, float v)
        {
            if (h == 0 || v == 0)
            {
                _animator.SetBool(IsToWalk, false);
            }
            else
            {
                _animator.SetBool(IsToWalk, true);
            }
        }
    }
}