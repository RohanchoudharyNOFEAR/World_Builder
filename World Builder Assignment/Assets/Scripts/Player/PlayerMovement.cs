using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilder
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        public Transform target;
        [SerializeField] private float _rotationSpeed = 5f;
        [SerializeField] private float _speed = 5f;

        public float RotationSpeed { get { return _rotationSpeed; } private set { _rotationSpeed = value; } }
        public float Speed { get { return _speed; } private set { _speed = value; } }
        public Vector3 PlayerVelocityVector;
        public CharacterController Cc;

        // Start is called before the first frame update
        void Start()
        {
            Cc = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {




        }


        public void Move(Vector3 InputMovementVector)
        {
            if (InputMovementVector.magnitude != 0)
            {
                Vector3 movementVector = new Vector3(_speed * Time.deltaTime * InputMovementVector.x, 0, _speed * Time.deltaTime * InputMovementVector.z);

                Vector3 targetRight = target.right;
                Vector3 targetforward = Vector3.Cross(targetRight, Vector3.up);     // same as Vector3 targetforward = target.forward;

                //vector v = target forward * speed + target right * speed        [math for game development cross product]
                // transform.position += targetforward * movementVector.z + targetRight * movementVector.x;
                PlayerVelocityVector = targetforward * movementVector.z + targetRight * movementVector.x;



                Quaternion requiredRotation = Quaternion.LookRotation(targetforward * movementVector.z + targetRight * movementVector.x);
                transform.rotation = Quaternion.Slerp(transform.rotation, requiredRotation, Time.deltaTime * _rotationSpeed);


                Cc.Move(PlayerVelocityVector);
            }

        }

    }
}