using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace TheLongOrbit
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class NavigationModule : MonoBehaviour, IDescribable
    {

        [Header("Nav Stats")]
        [ReadOnly]
        [SerializeField]
        private float speed = 0f;
        public float Speed { get { return speed; } set { speed = value; } }
        [SerializeField]
        private float turnRate;
        public float TurnRate { get { return turnRate; } }
        public float TurnArountTime { get { return 180f / turnRate; } }
        [SerializeField]
        private float acceleration;
        public float Acceleration { get { return acceleration; } }
        [SerializeField]
        private int tooltipPriority = 3;
        public int TooltipPriority { get { return tooltipPriority; } }
        [SerializeField]
        private bool supressTooltip = false;
        public bool IsTooltipSuppressed { get { return supressTooltip; } }

        [Header("Locations")]
        [ReadOnly]
        [SerializeField]
        private NavBeacon currentLocation;
        public NavBeacon CurrentLocation
        {
            get
            {
                if (destination == null)
                    return currentLocation;
                else
                    return null;
            }
            set { currentLocation = value; }
        }
        [ReadOnly]
        [SerializeField]

        private NavBeacon destination;
        public NavBeacon Destination { get { return destination; } set { destination = value; } }

        public Vector2 Position { get { return navRigidbody.position; } }

        //Calculated Course
        private Rigidbody2D navRigidbody;
        public Rigidbody2D NavRigitbody { get { return navRigidbody; } }

        private Vector2 initialPosition;
        public Vector2 InitialPosition { get { return initialPosition; } }

        private Vector2 initiateTurnPosition;
        public Vector2 InitiateTurnPosition { get { return initiateTurnPosition; } }

        private Vector2 halfPosition;
        public Vector2 HalfPosition { get { return halfPosition; } }

        private Vector2 finishTurnPosition;
        public Vector2 FinishTurnPosition { get { return finishTurnPosition; } }

        private Vector2 destinationPosition;
        public Vector2 DestinationPosition { get { return destinationPosition; } }
       
        private float velocityAtTurn; //Not used not but can be used to correct course deviations
        public float VelocityAtTurn { get { return velocityAtTurn; } }

        //Nav State Machine States
        private NavigationState currentState;
        public NavigationState CurrentState { get { return currentState; } }

        private IdleState idleState;
        public IdleState Idle { get { return idleState; } }

        private InitialManeuverState initialManeuverState;
        public InitialManeuverState InitialManeuver { get { return initialManeuverState; } }

        private AccelerationBurnState accelerationBurnState;
        public AccelerationBurnState AccelerationBurn { get { return accelerationBurnState; } }

        private DecelerationManeuverState decelerationManeuverState;
        public DecelerationManeuverState DecelerationManeuver { get { return decelerationManeuverState; } }

        private DecelerationBurnState decelerationBurnState;
        public DecelerationBurnState DecelerationBurn { get { return decelerationBurnState; } }


        void Awake()
        {
            idleState = new IdleState(this);
            initialManeuverState = new InitialManeuverState(this);
            accelerationBurnState = new AccelerationBurnState(this);
            decelerationManeuverState = new DecelerationManeuverState(this);
            decelerationBurnState = new DecelerationBurnState(this);
            navRigidbody = gameObject.GetRequiredComponent<Rigidbody2D>();
            
        }

        #region StateMachine

        // Use this for initialization
        void Start()
        {
            currentState = idleState;
        }

        void FixedUpdate()
        {
            currentState.Navigate();
            MoveTowardsDestination();
        }

        public void StartStateMachine()
        {
            currentState.Exit();
        }

        public void ChangeState(NavigationState newState)
        {
            currentState = newState;
            currentState.Enter();
        }

        #endregion
        #region MovementPhysics

        public void Accelerate()
        {
            speed += acceleration * Time.deltaTime;
        }

        public void Decelerate()
        {
            speed -= acceleration * Time.deltaTime;
        }

        public void MoveTowardsDestination()
        {
            navRigidbody.MovePosition(navRigidbody.position + (destinationPosition - navRigidbody.position).normalized * speed * Time.fixedDeltaTime);
        }

        public bool HasNotPassedPoint(Vector2 point)
        {
            if (Vector2.Dot(point - navRigidbody.position, destinationPosition - navRigidbody.position) > GameManager.Instance.CurrentSettings.PositionErrorTollerance)
            {
                return true;
            }
            else
                return false;
        }

        public bool RotateShipTowards(Vector3 target)
        {
            Vector2 head = transform.right;

            float angle = Vector2.Angle(head, target);
            float sign = Mathf.Sign(head.x * target.y - head.y * target.x);
            angle *= sign;

            if (angle > GameManager.Instance.CurrentSettings.HeadingErrorTolerance)
            {
                navRigidbody.MoveRotation(navRigidbody.rotation + turnRate * Time.fixedDeltaTime);
                return true;
            }
            else if (angle < -GameManager.Instance.CurrentSettings.HeadingErrorTolerance)
            {
                navRigidbody.MoveRotation(navRigidbody.rotation - turnRate * Time.fixedDeltaTime);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CalculateTrajectory()
        {

            Vector2 movementVector = destinationPosition - navRigidbody.position;
            halfPosition = destinationPosition - movementVector * 0.5f;
            float totalMoveDistance = Vector2.Distance(initialPosition, destinationPosition);

            float[] roots = MathExtensions.QuadraticSolver(1f / (TurnArountTime * TurnArountTime * acceleration), 1f, -totalMoveDistance);
            float turnDistance = roots.Max();

            float accelDistance = (totalMoveDistance - turnDistance) * 0.5f;

            velocityAtTurn = Mathf.Sqrt(2f * acceleration * accelDistance);
            initiateTurnPosition = halfPosition - movementVector.normalized * turnDistance * 0.5f;
            finishTurnPosition = halfPosition + movementVector.normalized * turnDistance * 0.5f;
            //PrintCourse();

        }

        #endregion

        #region MovementCommands

        public void TeleportToLocation (NavBeacon loc)
        {

            if (loc != null)
            {
                Debug.Log("Teleporting to: " + loc.Name);
                navRigidbody.position = loc.GetOrbitPosition();
                currentLocation = loc;
                destination = null;
            }
            else
                Debug.Log("ERROR: Teleport location set to null");

        }

        public void TeleportToVector(Vector3 pos)
        {
            navRigidbody.position = pos;
        }

        public void Move (NavBeacon loc)
        {
            if (destination == null)
            {
                if(loc != currentLocation)
                {
                    destination = loc;
                    currentLocation = null;
                    initialPosition = navRigidbody.position;
                    destinationPosition = destination.GetOrbitPosition();
                    CalculateTrajectory();
                    StartStateMachine();
                }
                else
                    Debug.Log("ERROR: Cannot move to current location.");

            }
            else
                Debug.Log("ERROR: Movement command sent when destination already set.");
            
        }

        #endregion

        #region Accessors
        public string GetRichTextBasicInfo()
        {
            string header = UIManager.Instance.Style.Subheading.ApplyTextSyle("Navigation");
            string state = UIManager.Instance.Style.Body.ApplyTextSyle(currentState.GetStateDescription());
            string spd = UIManager.Instance.Style.Body.ApplyTextSyle("Speed: " + speed.ToString() + " m/s");
            string accel;

            if (speed > 0)
                accel = UIManager.Instance.Style.Body.ApplyTextSyle("Acceleration: " + acceleration.ToString() + " m/s^2");
            else
                accel = UIManager.Instance.Style.Body.ApplyTextSyle("Acceleration: 0 m/s^2");

            string tspd = UIManager.Instance.Style.Body.ApplyTextSyle("Turning: " + turnRate.ToString() + " deg/s");

            return header + Environment.NewLine + state + Environment.NewLine + spd + Environment.NewLine + accel + Environment.NewLine + tspd;
        }

        public void PrintCourse()
        {
            Debug.Log("Initial: " + initialPosition);
            Debug.Log("Start Turn: " + initiateTurnPosition);
            Debug.Log("Half: " + halfPosition);
            Debug.Log("Finish Turn: " + finishTurnPosition);
            Debug.Log("Final: " + destinationPosition);
        }

        /*
        public bool IsMoving()
        {
            if (currentState is IdleState)
                return false;
            else
                return true;
        }
        */
        #endregion

    }
}