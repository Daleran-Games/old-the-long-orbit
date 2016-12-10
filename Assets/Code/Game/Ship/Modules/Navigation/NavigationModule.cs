using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TheLongOrbit
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class NavigationModule : MonoBehaviour, IDescribable
    {

        [Header("Nav Stats")]
        [ReadOnly]
        [SerializeField]
        private float speed = 0f;
        [SerializeField]
        private float turningSpeed = 1f;
        [SerializeField]
        private float acceleration = 0f;
        [SerializeField]
        private float maxAcceleration = 0f;
        [SerializeField]
        private float positionErrorTolerance = 2f;
        [SerializeField]
        private float headingErrorTolerance = 1f;
        [SerializeField]
        private int tooltipPriority = 3;

        [Header("Locations")]
        [ReadOnly]
        [SerializeField]
        private string stateText;
        public NavigationState currentState;
        [ReadOnly]
        [SerializeField]
        private string currentLocationText;
        private NavBeacon currentLocation;
        [ReadOnly]
        [SerializeField]
        private string destinationText;
        private NavBeacon destination;
        [ReadOnly]
        [SerializeField]
        private float distanceToDestination;

        [Header("Debug")]
        [ReadOnly]
        [SerializeField]
        private Rigidbody2D navRigidBody;
        [ReadOnly]
        [SerializeField]
        private Vector3 movementVector;




        [HideInInspector]
        public IdleState idleState;
        [HideInInspector]
        public InitialManeuverState initialManeuverState;
        [HideInInspector]
        public AccelerationBurnState accelerationBurnState;
        [HideInInspector]
        public DecelerationManeuverState decelerationManeuverState;
        [HideInInspector]
        public DecelerationBurnState decelerationBurnState;

        void Awake()
        {
            navRigidBody = gameObject.GetRequiredComponent<Rigidbody2D>();

            idleState = new IdleState(this);
            initialManeuverState = new InitialManeuverState(this);
            accelerationBurnState = new AccelerationBurnState(this);
            decelerationManeuverState = new DecelerationManeuverState(this);
            decelerationBurnState = new DecelerationBurnState(this);
            
        }

        void Update()
        {

            if (currentLocation != null)
                currentLocationText = currentLocation.GetNavBeaconName();
            else
                currentLocationText = "";

            if (destination != null)
                destinationText = destination.GetNavBeaconName();
            else
                destinationText = "";

            if (currentState != null)
                stateText = currentState.GetStateDescription();
            else
                stateText = "";
        }

        #region StateMachine

        // Use this for initialization
        void Start()
        {
            currentState = idleState;
        }

        void FixedUpdate()
        {
            if (destination != null)
            {
                distanceToDestination = DistanceToLocation(destination);
                movementVector = VectorToLocation(destination).normalized;
            } else
            {
                distanceToDestination = 0f;
                movementVector = Vector3.zero;
            }

            currentState.Navigate();
            
        }

        public void StartStateMachine()
        {
            currentState.Enter();
        }

        public void ChangeState(NavigationState newState)
        {
            currentState = newState;
            currentState.Enter();
        }

        #endregion
        #region MovementPhysics

        public float CalculateNewSpeed()
        {
            return speed + acceleration;
        }

        public bool CheckIfAtLocation (NavBeacon loc)
        {
            if (DistanceToLocation(loc) > positionErrorTolerance)
                return false;
            else
                return true;
        }



        public void TranslateObject (Vector3 movementV, float movementSpeed)
        {
            transform.position += movementV * movementSpeed;
        }

        Vector3 VectorToLocation(NavBeacon loc)
        {
            return transform.position - loc.GetOrbitPosition();
        }

        float DistanceToLocation(NavBeacon loc)
        {
            return VectorToLocation(loc).magnitude;
        }

        #endregion

        #region MovementCommands

        public void Teleport (NavBeacon loc)
        {

            if (loc != null)
            {
                Debug.Log("Teleporting to: " + loc.GetNavBeaconName());
                transform.position = loc.GetOrbitPosition();
                currentLocation = loc;
                destination = null;
            }
            else
                Debug.Log("ERROR: Teleport location set to null");

            
        }

        public void Move (NavBeacon loc)
        {
            if (destination == null)
            {
                destination = loc;
                StartStateMachine();
            }
            else
                Debug.Log("ERROR: Movement command sent when destination already set.");
            
        }

        #endregion

        #region Accessors
        public NavBeacon GetCurrentLocation()
        {
            if (destination == null)
                return currentLocation;
            else
                return null;
        }

        public void SetLocation (NavBeacon loc)
        {
            currentLocation = loc;
        }

        public NavBeacon GetDestination()
        {
            return destination;
        }

        public void SetDestination(NavBeacon loc)
        {
            destination = loc;
        }

        public string GetStateDescription ()
        {
            return currentState.GetStateDescription();
        }

        public float GetDistanceToDestination ()
        {
            return distanceToDestination;
        }

        public Vector3 GetMovementVector()
        {
            return movementVector;
        }

        public float GetHeadingErrorTolerance()
        {
            return headingErrorTolerance;
        }

        public float GetPositionErrorTolerance()
        {
            return positionErrorTolerance;
        }
        
        public float GetTurningSpeed ()
        {
            return turningSpeed;
        }

        public string GetRichTextBasicInfo()
        {
            string header = UIManager.Instance.Style.Subheading.ApplyTextSyle("Navigation");
            string state = UIManager.Instance.Style.Body.ApplyTextSyle(currentState.GetStateDescription());
            string spd = UIManager.Instance.Style.Body.ApplyTextSyle("Speed: " + speed.ToString() + " m/s");
            string accel = UIManager.Instance.Style.Body.ApplyTextSyle("Acceleration: " + acceleration.ToString() + " / " + maxAcceleration.ToString() + " m/s^2");
            string tspd = UIManager.Instance.Style.Body.ApplyTextSyle("Turning: " + turningSpeed.ToString() + " m/s");

            return header + Environment.NewLine + state + Environment.NewLine + spd + Environment.NewLine + accel + Environment.NewLine + tspd;
        }

        public int GetPriority()
        {
            return tooltipPriority;
        }

        #endregion

    }
}