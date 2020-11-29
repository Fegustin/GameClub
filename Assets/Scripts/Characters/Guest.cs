using Pathfinding;
using ScriptableObject.Source.State;
using UnityEngine;
using Random = System.Random;

namespace Characters
{
    public class Guest : MonoBehaviour
    {
        public int money;
        public int mood;
        
        public State searchComputerState;
        public State goToHomeState;
        [Header("Actual state")] public State currentState;
        
        private AIPath _aiPath;
        private AIDestinationSetter _aiDestinationSetter;
        private Animator _animator;

        private float _rotZ;

        private static readonly int IsToWalk = Animator.StringToHash("isToWalk");

        private void Start()
        {
            SetState(searchComputerState);
            _aiPath = gameObject.GetComponentInParent<AIPath>();
            _aiDestinationSetter = gameObject.GetComponentInParent<AIDestinationSetter>();
            _animator = GetComponent<Animator>();

            var random = new Random();
            money = random.Next(5, 10);
            mood = random.Next(1, 5);
        }

        private void Update()
        {
            var yDirection = _aiPath.desiredVelocity.y;
            var xDirection = _aiPath.desiredVelocity.x;

            Rotation(yDirection, xDirection);
            StartAnimationToWalk(yDirection, xDirection);

            // State Guest
            if (!currentState.isFinished)
            {
                currentState.Run();
            }
            else
            {
                SetState(goToHomeState);
            }
        }

        public void SetState(State state)
        {
            currentState = Instantiate(state);
            currentState.guest = this;
            currentState.Init();
        }

        public void MoveTo(Transform target)
        {
            _aiDestinationSetter.target = target;
        }

        private void Rotation(float y, float x)
        {
            _rotZ = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            if (y != 0 || x != 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, _rotZ);
            }
        }

        private void StartAnimationToWalk(float y, float x)
        {
            if (y == 0 || x == 0)
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