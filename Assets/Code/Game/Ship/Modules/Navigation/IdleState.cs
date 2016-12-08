using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLongOrbit
{
    public class IdleState : NavigationState
    {

        public IdleState(NavigationModule nav)
        {
            navModule = nav;
        }

        public override void Enter()
        {

        }

        public override void Navigate()
        {
            
        }

        public override void Exit()
        {

        }

        public override string GetStateDescription()
        {
            if (navModule.GetCurrentLocation() != null)
                return "Idling near " + navModule.GetCurrentLocation() + ".";
            else
                return "ERROR: Idling near no location";
        }


    }
}