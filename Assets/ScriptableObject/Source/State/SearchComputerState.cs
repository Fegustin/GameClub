using UnityEngine;

namespace ScriptableObject.Source.State
{
    [CreateAssetMenu(fileName = "Search state", menuName = "ScriptableObject/State/Search")]
    public class SearchComputerState : State
    {
        public State goToHomeState;

        private Transform _target;

        public override void Init()
        {
            var computers = GameObject.FindGameObjectsWithTag("PC");

            if (computers.Length == 0)
            {
                guest.SetState(goToHomeState);
                return;
            }

            _target = computers[Random.Range(0, computers.Length)].transform;
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
                guest.SetState(goToHomeState);
                isFinished = true;
            }
        }
    }
}