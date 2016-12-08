﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLongOrbit
{
    [System.Serializable]
    public abstract class NavigationState 
    {

        public delegate void OnCompleteEvent();
        public event OnCompleteEvent OnComplete;

        protected NavigationModule navModule;

        public abstract void Enter();
        public abstract void Navigate();
        public abstract void Exit();

        public abstract string GetStateDescription();


    }

}
