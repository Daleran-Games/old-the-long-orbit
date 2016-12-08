using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLongOrbit
{
    public class InitialManeuverState : NavigationState
    {
        public InitialManeuverState(NavigationModule nav)
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
                return "Lining up with " + navModule.GetDestination() + ".";
            else
                return "ERROR: Manuvering at location";
        }

    }
}