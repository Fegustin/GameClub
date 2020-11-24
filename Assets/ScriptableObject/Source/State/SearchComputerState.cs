using UnityEngine;

namespace ScriptableObject.Source.State
{
    public class SearchComputerState : State
    {
        public State noFindComputerState;

        private Transform _target;

        public override void Init()
        {
            var computers = GameObject.FindGameObjectsWithTag("PC");

            if (computers.Length == 0)
            {
                guest.SetState(noFindComputerState);
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
                Destroy(guest);
                isFinished = true;
            }
        }
    }
}