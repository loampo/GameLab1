//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class VehicleController : MonoBehaviour
//{
//    public class VehicleController : MonoBehaviour
//    {
//        public bool proceduralTrack;
//        private Transform vehicleTransform;
//        private Rigidbody vehicleRigidbody;
//        private CapsuleCollider vehicleCollider;
//        private Vector3 averageSurfaceRight = Vector3.right;
//        private Vector3 averageSurfaceUp = Vector3.up;
//        private Vector3 averageSurfaceForward = Vector3.forward;
//        private float averageSurfaceDistance = float.PositiveInfinity;
//        private bool isGrounded;
//        private float queuedAccelerationSum;
//        private float queuedBrakingSum;
//        private float queuedSteeringSum;
//        private int framesSincePhysicsIteration;
//        private float averageSteeringInput;
//        private float averageAccelerationInput;
//        private float averageBrakingInput;

//        public float planarSpeed
//        {
//            get
//            {
//                Vector3 vector3 = Vector3.ProjectOnPlane(this.vehicleRigidbody.velocity, this.averageSurfaceUp);
//                return ((Vector3)ref vector3).magnitude;
//            }
//        }

//        public float absoluteSpeed
//        {
//            get
//            {
//                Vector3 velocity = this.vehicleRigidbody.velocity;
//                return ((Vector3)ref velocity).magnitude;
//            }
//        }

//        public float speedPercent => Mathf.Clamp01(this.planarSpeed / this.topSpeed);

//        public Vector3 velocity => this.vehicleRigidbody.velocity;

//        public Vector3 angularVelocity => this.vehicleRigidbody.angularVelocity;

//        public float angularSpeed
//        {
//            get
//            {
//                Vector3 angularVelocity = this.angularVelocity;
//                return ((Vector3)ref angularVelocity).magnitude;
//            }
//        }

//        public float maxSpeed => this.topSpeed;

//        public float accelerationInput { get; private set; }

//        private void Start()
//        {
//            this.vehicleTransform = ((Component)this).GetComponent<Transform>();
//            this.vehicleRigidbody = ((Component)this).GetComponent<Rigidbody>();
//            this.vehicleCollider = ((Component)this).GetComponent<CapsuleCollider>();
//            if (!this.proceduralTrack)
//                return;
//        }

//        private void FixedUpdate()
//        {
           

//        public void Steer(float amount)
//        {
//            amount = Mathf.Clamp(amount, -1f, 1f);
//            this.queuedSteeringSum += amount;
//        }

//        public void Accelerate(float amount)
//        {
//            amount = Mathf.Clamp(amount, 0.0f, 1f);
//            this.queuedAccelerationSum += amount;
//            this.accelerationInput = this.queuedAccelerationSum;
//        }

//        public void Brake(float amount)
//        {
//            amount = Mathf.Clamp(amount, 0.0f, 1f);
//            this.queuedBrakingSum += amount;
//        }

//        public void SetPoweredState(bool value) => this.vehiclePoweredOn = value;

//        public void ResetVelocity()
//        {
//            this.vehicleRigidbody.AddForce(Vector3.op_UnaryNegation(this.vehicleRigidbody.velocity), (ForceMode)2);
//            this.vehicleRigidbody.AddTorque(Vector3.op_UnaryNegation(this.vehicleRigidbody.angularVelocity), (ForceMode)2);
//        }
//    }
//}
