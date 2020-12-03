using ScriptableObject.Source.State;
using UnityEngine;

namespace Main.Characters
{
    public abstract class TheCharacterAbstract : MonoBehaviour
    {
        private static readonly int IsToWalk = Animator.StringToHash("isToWalk");

        protected void AbstractSetRotation(float y, float x, Transform myTransform)
        {
            if (y != 0 || x != 0)
            {
                var rotZ = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
                myTransform.rotation = Quaternion.Euler(0f, 0f, rotZ);
            }
        }

        protected void AbstractStartAnimationToWalk(float y, float x, Animator animator)
        {
            if (y == 0 || x == 0)
            {
                animator.SetBool(IsToWalk, false);
            }
            else
            {
                animator.SetBool(IsToWalk, true);
            }
        }

        public virtual void SetState(State state)
        {
        }

        public abstract void MoveTo(Transform target = default);
    }
}