using Main;
using Main.Characters;
using UnityEngine;

namespace ScriptableObject.Source.State
{
    [CreateAssetMenu(fileName = "Search state", menuName = "ScriptableObject/State/Search")]
    public class SearchComputerState : State
    {
        public State goToHomeState;

        private GameObject _target;
        private Computer _computer;

        public delegate void IsCameUpDelegate(bool isCameUp);

        public event IsCameUpDelegate IsCameUpEvent;

        public override void Init()
        {
            var computers = GameObject.FindGameObjectsWithTag("PC");

            if (computers.Length != 0)
            {
                _computer = computers[Random.Range(0, computers.Length)].GetComponent<Computer>();
                _target = _computer.transform.GetChild(0).gameObject;
            }
            else
            {
                character.SetState(goToHomeState);
                return;
            }
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
            if (_target == null || _computer.TimerIsRunning)
            {
                Init();
                return;
            }

            var distance = (_target.transform.position - character.transform.position).magnitude;

            if (distance > 1f)
            {
                character.MoveTo(_target.transform);
            }
            else
            {
                var guest = character as Guest;
                _computer.TimerIsRunning = true;
                if (!(guest is null)) _computer.Money = guest.Money;
                isFinished = true;
            }
        }
    }
}