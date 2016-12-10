using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLongOrbit
{
    [System.Serializable]
    public class IdleState : NavigationState
    {

        public IdleState(NavigationModule nav)
        {
            navModule = nav;
        }

        public override void Enter()
        {
            navModule.SetDestination(null);
        }

        public override void Navigate()
        {
            
        }

        public override void Exit()
        {
            navModule.ChangeState(navModule.initialManeuverState);
        }

        public override string GetStateDescription()
        {
            if (navModule.GetCurrentLocation() != null)
                return "Idling near " + navModule.GetCurrentLocation().GetNavBeaconName() + ".";
            else
                return "ERROR: Idling near no location";
        }


    }
}