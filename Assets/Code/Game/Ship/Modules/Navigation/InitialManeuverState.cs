using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheLongOrbit
{
    [System.Serializable]
    public class InitialManeuverState : NavigationState
    {
        private Vector3 destinationVector;

        public InitialManeuverState(NavigationModule nav)
        {
            navModule = nav;
        }


        public override void Enter()
        {
            
        }

        public override void Navigate()
        {
            if (RotateShipTowards(navModule.GetMovementVector()))
            {

            }else
            {
                Exit();
            }
        }

        public override void Exit()
        {
            navModule.ChangeState(navModule.accelerationBurnState);
        }

        public override string GetStateDescription()
        {
            if (navModule.GetCurrentLocation() == null)
                return "Lining up with " + navModule.GetDestination().GetNavBeaconName() + ".";
            else
                return "ERROR: Manuvering at location";
        }

        public bool RotateShipTowards(Vector3 facingVector)
        {
            float angle = Mathf.Atan2(facingVector.y, facingVector.x) * Mathf.Rad2Deg;

            if (angle > navModule.transform.eulerAngles.z + navModule.GetHeadingErrorTolerance() && angle > navModule.transform.eulerAngles.z - navModule.GetHeadingErrorTolerance())
            {
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                navModule.transform.rotation = Quaternion.Slerp(navModule.transform.rotation, q, Time.deltaTime * navModule.GetTurningSpeed());
                return true;
            } else
            {
                return false;
            }
        }

    }
}