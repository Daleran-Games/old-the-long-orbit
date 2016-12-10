using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLongOrbit
{
    [System.Serializable]
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
            navModule.SetLocation(navModule.GetDestination());
            navModule.ChangeState(navModule.idleState);
           
        }

        public override string GetStateDescription()
        {
            if (navModule.GetCurrentLocation() == null)
                return "Decelerating towards " + navModule.GetDestination().GetNavBeaconName() + ".";
            else
                return "ERROR: Decelerating at location";
        }

    }
}