using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TheLongOrbit
{
    [System.Serializable]
    public class InitialManeuverState : NavigationState
    {

        public InitialManeuverState(NavigationModule nav)
        {
            navModule = nav;
        }


        public override void Enter()
        {
            Debug.Log("Starting Iniital Maneuver State");
        }

        public override void Navigate()
        {
            if (navModule.RotateShipTowards(navModule.DestinationPosition - navModule.Position))
            {

            }else
            {
                Exit();
            }
        }

        public override void Exit()
        {
            navModule.ChangeState(navModule.AccelerationBurn);
           Debug.Log("Exiting Maneuver State");
        }

        public override string GetStateDescription()
        {
            if (navModule.CurrentLocation == null)
                return "Lining up with " + navModule.Destination.Name + ".";
            else
                return "ERROR: Manuvering at location";
        }





    }
}