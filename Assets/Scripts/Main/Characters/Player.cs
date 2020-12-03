using System.Collections;
using UnityEngine;

namespace Main.Characters
{
    public class Player : TheCharacterAbstract
    {
        public static Player Singleton { get; private set; }

        public Joystick joystick;
        private Rigidbody2D _rigidbody2D;
        private Animator _animator;

        public float speed = 3f;
        private float _horizontal;
        private float _vertical;

        private Computer _computer;

        private void Awake()
        {
            if (!Singleton)
            {
                Singleton = this;
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

            StartCoroutine(UpdatePathfinding());

            _computer.GetMoneyEvent += Coins;
        }

        private void Update()
        {
            _horizontal = joystick.Horizontal;
            _vertical = joystick.Vertical;

            AbstractStartAnimationToWalk(_horizontal, _vertical, _animator);

            AbstractSetRotation(-_vertical, -_horizontal, transform);
        }

        private void FixedUpdate()
        {
            if (_horizontal != 0 || _vertical != 0)
            {
                MoveTo();
            }
        }

        public override void MoveTo(Transform target = default)
        {
            Vector2 position = _rigidbody2D.position;

            position.x = position.x + speed * _horizontal * Time.deltaTime;
            position.y = position.y + speed * _vertical * Time.deltaTime;

            _rigidbody2D.MovePosition(position);
        }

        private IEnumerator UpdatePathfinding()
        {
            // Потом дописать условие остановки, если на экране нет клиентов
            while (true)
            {
                AstarPath.active.Scan();
                yield return new WaitForSeconds(.4f);
            }
        }

        private void Coins(int coin) => Debug.Log("Соси " + coin);
    }
}