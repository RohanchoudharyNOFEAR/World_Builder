using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilder
{
    public class PlayerJump : MonoBehaviour
    {
        [SerializeField] private float _jumpForce = 20f;
        public float JumpForce { get { return _jumpForce; } private set { _jumpForce = value; } }
        private float _gravity = 14.0f;
        public float Gravity { get { return _gravity; } }
        public float verticalVelocity;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Jump(CharacterController Cc, Vector3 PlayerVelocityVector, bool JumpInput)
        {
            if (Cc.isGrounded)
            {
                verticalVelocity = -_gravity * Time.deltaTime;
                if (/*Input.GetKeyDown(KeyCode.Space)*/JumpInput)
                {
                    verticalVelocity = _jumpForce;
                }
            }
            else
            {
                verticalVelocity -= Gravity * Time.deltaTime;
            }

            PlayerVelocityVector.y = verticalVelocity * Time.deltaTime;
            Cc.Move(PlayerVelocityVector);

        }
    }
}
