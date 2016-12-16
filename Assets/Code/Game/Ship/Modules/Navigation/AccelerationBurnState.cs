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
            Debug.Log("Starting Acceleration State");
            
        }

        public override void Navigate()
        {

            if (navModule.HasNotPassedPoint(navModule.InitiateTurnPosition))
            {
                navModule.Accelerate();
            }
            else
            {
                Exit();
            }

        }

        public override void Exit()
        {
            //navModule.TeleportToVector(navModule.InitiateTurnPosition);
            //Debug.Log("Error Speed: " + navModule.Speed);
            //Debug.Log("Correction Speed: " + navModule.VelocityAtTurn);
            //navModule.Speed = navModule.VelocityAtTurn;
            navModule.ChangeState(navModule.DecelerationManeuver);
            Debug.Log("Exiting Acceleration State");
        }

        public override string GetStateDescription()
        {
            if (navModule.CurrentLocation == null)
                return "Accelerating towards " + navModule.Destination.Name + ".";
            else
                return "ERROR: Accelerating at location";
        }

    }
}