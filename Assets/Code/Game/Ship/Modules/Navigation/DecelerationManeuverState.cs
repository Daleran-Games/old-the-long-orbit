using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLongOrbit
{
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
                return "Manuvering for deceleration burn to " + navModule.GetDestination() + ".";
            else
                return "ERROR: Manuvering at location";
        }

    }
}
