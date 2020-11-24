using UnityEngine;

namespace ScriptableObject.Source.State
{
    public class NoFindComputerState : State
    {
        public override void Init()
        {
            Debug.Log("Нет компов");
        }

        public override void Run()
        {
        }
    }
}