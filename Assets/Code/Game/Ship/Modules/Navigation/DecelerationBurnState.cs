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
            Debug.Log("Starting Deceleration State");
        }

        public override void Navigate()
        {
            if (navModule.Speed < 0)
            {
                Exit();
            }
            else if (navModule.HasNotPassedPoint(navModule.DestinationPosition))
            {
                navModule.Decelerate();
            }
            else
            {
                Exit();
            }
        }

        public override void Exit()
        {
            Debug.Log("Final Error Speed: " + navModule.Speed);
            navModule.Speed = 0f;
            navModule.TeleportToVector(navModule.DestinationPosition);
            navModule.CurrentLocation = navModule.Destination;
            navModule.ChangeState(navModule.Idle);
            navModule.Destination = null;
            Debug.Log("Exiting Deceleration State");

        }

        public override string GetStateDescription()
        {
            if (navModule.CurrentLocation == null)
                return "Decelerating towards " + navModule.Destination.Name + ".";
            else
                return "ERROR: Decelerating at location";
        }

    }
}