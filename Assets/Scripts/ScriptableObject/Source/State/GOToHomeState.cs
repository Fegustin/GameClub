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
            var distance = (_target.position - character.transform.position).magnitude;

            if (distance > 1f)
            {
                character.MoveTo(_target.transform);
            }
            else
            {
                isFinished = true;
            }
        }
    }
}