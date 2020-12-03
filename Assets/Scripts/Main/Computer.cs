using UnityEngine;

namespace Main
{
    public class Computer : MonoBehaviour
    {
        public bool TimerIsRunning { get; set; }
        public int Money { get; set; }
        
        private float _timeRemaining = 3f;
        private Animator _animator;
        
        private static readonly int IsBusy = Animator.StringToHash("isBusy");

        public delegate void GetMoneyActive(int money);

        public event GetMoneyActive GetMoneyEvent;
        
        private void Start()
        {
            _animator = gameObject.GetComponent<Animator>();

            TimerIsRunning = false;
        }

        private void Update()
        {
            Timer();
        }

        private void Timer()
        {
            if (TimerIsRunning)
            {
                if (_timeRemaining > 0)
                {
                    _timeRemaining -= Time.deltaTime;
                    BusyComputerAnimation(true);
                }
                else
                {
                    _timeRemaining = 0;
                    TimerIsRunning = false;
                    BusyComputerAnimation(false);
                    GetMoneyEvent?.Invoke(Money);
                }
            }
        }

        private void BusyComputerAnimation(bool isBusy)
        {
            _animator.SetBool(IsBusy, isBusy);
        }
    }
}