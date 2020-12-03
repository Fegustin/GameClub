using Main.Characters;
using UnityEngine;

namespace ScriptableObject.Source.State
{
    public abstract class State : UnityEngine.ScriptableObject
    {
        public bool isFinished { get; protected set; }
        [HideInInspector] public TheCharacterAbstract character;

        public virtual void Init()
        {
        }

        public abstract void Run();
    }
}