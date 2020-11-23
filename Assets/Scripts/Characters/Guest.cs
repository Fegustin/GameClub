using UnityEngine;
using Random = System.Random;
using Pathfinding;

namespace Characters
{
    public class Guest : MonoBehaviour
    {
        private AIPath _aiPath;
        private Animator _animator;
        
        private float _rotZ;

        public int money;
        public int mood;
        private static readonly int IsToWalk = Animator.StringToHash("isToWalk");

        private void Start()
        {
            _aiPath = gameObject.GetComponentInParent(typeof(AIPath)) as AIPath;
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
        }

        private void Rotation(float y, float x)
        {
            _rotZ = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, _rotZ);
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