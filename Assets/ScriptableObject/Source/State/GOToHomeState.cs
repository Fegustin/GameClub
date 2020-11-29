using UnityEngine;

namespace ScriptableObject.Source.State
{
    [CreateAssetMenu(fileName = "Go to home state", menuName = "ScriptableObject/State/GoToHome")]
    public class GOToHomeState : State
    {
        private Transform _target;
        public override void Init()
        {
            var exit = GameObject.FindWithTag("Exit");

            if (exit == null)
            {
                return;
            }

            _target = exit.transform;
        }

        public override void Run()
        {
            if (isFinished)
            {
                return;
            }
            
            MoveTo();
        }
        
        private void MoveTo()
        {
            var distance = (_target.position - guest.transform.position).magnitude;

            if (distance > 1f)
            {
                guest.MoveTo(_target.transform);
            }
            else
            {
                Destroy(guest.transform.parent.gameObject);
                isFinished = true;
            }
        }
    }
}