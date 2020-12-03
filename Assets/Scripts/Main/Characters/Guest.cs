using Pathfinding;
using ScriptableObject.Source.State;
using UnityEngine;
using Random = System.Random;

namespace Main.Characters
{
    public class Guest : TheCharacterAbstract
    {
        public int Money { get; set; }
        [HideInInspector] public int mood;

        public State searchComputerState;
        public State goToHomeState;
        [Header("Actual state")] public State currentState;

        private AIPath _aiPath;
        private AIDestinationSetter _aiDestinationSetter;
        private Animator _animator;

        private void Start()
        {
            SetState(searchComputerState);
            _aiPath = gameObject.GetComponentInParent<AIPath>();
            _aiDestinationSetter = gameObject.GetComponentInParent<AIDestinationSetter>();
            _animator = GetComponent<Animator>();
            

            var random = new Random();
            Money = 10;
            mood = 10;
        }

        private void Update()
        {
            var yDirection = _aiPath.desiredVelocity.y;
            var xDirection = _aiPath.desiredVelocity.x;

            AbstractStartAnimationToWalk(yDirection, xDirection, _animator);
            AbstractSetRotation(yDirection, xDirection, transform);
            
            // State Guest
            if (!currentState.isFinished)
            {
                currentState.Run();
            }
            else
            {
                if (Money == 0 || mood == 0)
                {
                    SetState(goToHomeState);
                }
                else
                {
                    
                }
            }
        }

        public override void SetState(State state)
        {
            currentState = Instantiate(state);
            currentState.character = this;
            currentState.Init();
        }

        public override void MoveTo(Transform target = default)
        {
            _aiDestinationSetter.target = target;
        }
    }
}