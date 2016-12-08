using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLongOrbit
{
    public class DecelerationBurnState : NavigationState
    {
        public DecelerationBurnState(NavigationModule nav)
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
                return "Decelerating towards " + navModule.GetDestination() + ".";
            else
                return "ERROR: Manuvering at location";
        }

    }
}