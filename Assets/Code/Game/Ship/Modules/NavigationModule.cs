using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TheLongOrbit
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class NavigationModule : MonoBehaviour {

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

        [Header("Locations")]
        [SerializeField]
        private Location currentLocation;
        [SerializeField]
        private Location destination;
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

        private NavigationState currentState;
        private IdleState idleState;
        private InitialManeuverState initialManeuverState;
        private AccelerationBurnState accelerationBurnState;
        private DecelerationManeuverState decelerationManeuverState;
        private DecelerationBurnState decelerationBurnState;

        void Awake()
        {
            navRigidBody = gameObject.GetRequiredComponent<Rigidbody2D>();

            idleState = new IdleState(this);
            initialManeuverState = new InitialManeuverState(this);
            accelerationBurnState = new AccelerationBurnState(this);
            decelerationManeuverState = new DecelerationManeuverState(this);
            decelerationBurnState = new DecelerationBurnState(this);
            
        }

        // Use this for initialization
        void Start()
        {
            currentState = idleState;
        }

        void FixedUpdate()
        {
            distanceToDestination = DistanceToLocation(destination);
            currentState.Navigate();
        }


        #region MovementPhysics

        public float CalculateNewSpeed()
        {
            return speed + acceleration;
        }

        public bool CheckIfAtLocation (Location loc)
        {
            if (DistanceToLocation(loc) > positionErrorTolerance)
                return false;
            else
                return true;
        }

        public void RotateShipTowards (Vector3 facingVector)
        {
            float angle = Mathf.Atan2(facingVector.y, facingVector.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * turningSpeed);
        }

        public void TranslateObject (Vector3 movementV, float movementSpeed)
        {
            transform.position += movementV * movementSpeed;
        }

        Vector3 VectorToLocation(Location loc)
        {
            return transform.position - loc.GetOrbitPosition();
        }

        float DistanceToLocation(Location loc)
        {
            return VectorToLocation(loc).magnitude;
        }

        #endregion

        #region MovementCommands

        public void Teleport (Location loc)
        {
            transform.position = loc.GetOrbitPosition();
        }

        public void Move (Location loc)
        {
            movementVector = VectorToLocation(loc).normalized;
            destination = loc;
        }

        #endregion

        #region Accessors
        public Location GetCurrentLocation()
        {
            if (destination == null)
                return currentLocation;
            else
                return null;
        }

        public Location GetDestination()
        {
            return destination;
        }

        public string GetStateDescription ()
        {
            return currentState.GetStateDescription();
        }

        public float GetDistanceToDestination ()
        {
            return distanceToDestination;
        }

        #endregion

    }
}