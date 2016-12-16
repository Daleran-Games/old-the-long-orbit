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
            Debug.Log("Starting Deceleration Maneuver State");
        }

        public override void Navigate()
        {
            if (navModule.RotateShipTowards(navModule.Position - navModule.DestinationPosition))
            {

            }
            else
            {
                Exit();
            }
        }

        public override void Exit()
        {
            //navModule.TeleportToVector(navModule.FinishTurnPosition);
            navModule.ChangeState(navModule.DecelerationBurn);
            Debug.Log("Exiting Deceleration Maneuver State");
        }

        public override string GetStateDescription()
        {
            if (navModule.CurrentLocation == null)
                return "Manuvering for deceleration burn to " + navModule.Destination.Name + ".";
            else
                return "ERROR: Decelration maneuver at location";
        }

    }
}
