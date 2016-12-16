using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLongOrbit
{
    [System.Serializable]
    public class IdleState : NavigationState
    {

        public IdleState(NavigationModule nav)
        {
            navModule = nav;
        }

        public override void Enter()
        {
            //Debug.Log("Starting Idle State");
            
        }

        public override void Navigate()
        {
            
        }

        public override void Exit()
        {
            navModule.ChangeState(navModule.InitialManeuver);
            //Debug.Log("Exiting Idle State");
        }

        public override string GetStateDescription()
        {
            if (navModule.CurrentLocation != null)
                return "Idling near " + navModule.CurrentLocation.Name + ".";
            else
                return "ERROR: Idling near no location";
        }


    }
}