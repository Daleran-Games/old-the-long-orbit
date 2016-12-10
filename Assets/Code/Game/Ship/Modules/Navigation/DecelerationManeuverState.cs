using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLongOrbit
{
    [System.Serializable]
    public class DecelerationManeuverState : NavigationState
    {
        public DecelerationManeuverState(NavigationModule nav)
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
                return "Manuvering for deceleration burn to " + navModule.GetDestination().GetNavBeaconName() + ".";
            else
                return "ERROR: Decelration maneuver at location";
        }

    }
}
