using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLongOrbit
{
    [System.Serializable]
    public class AccelerationBurnState : NavigationState
    {
        public AccelerationBurnState(NavigationModule nav)
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
            if (navModule.GetCurrentLocation() == null)
                return "Accelerating towards " + navModule.GetDestination().GetNavBeaconName() + ".";
            else
                return "ERROR: Accelerating at location";
        }
    }
}