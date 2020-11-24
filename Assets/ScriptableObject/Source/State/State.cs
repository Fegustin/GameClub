﻿using Characters;
using UnityEngine;

namespace ScriptableObject.Source.State
{
    [CreateAssetMenu(fileName = "State", menuName = "ScriptableObject/State")]
    public abstract class State : UnityEngine.ScriptableObject
    {
        public bool isFinished { get; protected set; }
        [HideInInspector] public Guest guest;

        public virtual void Init()
        {
        }

        public abstract void Run();
    }
}