using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace WorldBuilder
{
    public class PlayerInputs : MonoBehaviour
    {
        public Vector3 InputMovementVector { get; private set; }
        public Vector2 InputMouseVector { get; private set; }
        public bool InputJump { get; private set; }

        public Joystick movementJoystick;
        public Joystick cameraMovementJoystick;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            getJoystickInputs();
            getCameraJoysticInputs();
            //getInputs();
            //getCameraInputs();
            //getJumpInput();
        }

       

        void getJoystickInputs()
        {
            InputMovementVector = new Vector3(movementJoystick.Horizontal, 0,movementJoystick.Vertical);
        }
        void getCameraJoysticInputs()
        {
          InputMouseVector =  new Vector2( cameraMovementJoystick.Vertical, cameraMovementJoystick.Horizontal);
        }

        //COMPUTER INPUTS
        //void getInputs()
        //{
        //    float horizontal = Input.GetAxis("Horizontal");
        //    float Verical = Input.GetAxis("Vertical");

        //    InputMovementVector = new Vector3(horizontal, 0, Verical);
        //}

        //void getCameraInputs()
        //{
        //    float _mouseX, _mouseY;
        //    _mouseX = Input.GetAxis("Mouse Y");
        //    _mouseY = Input.GetAxis("Mouse X");
        //    InputMouseVector = new Vector2(_mouseX, _mouseY);
        //    // Debug.Log(InputMouseVector);
        //}
        void getJumpInput()
        {
            InputJump = Input.GetKeyDown(KeyCode.Space);
            //  Debug.Log("Input Jump="+InputJump);
        }

        public void UsedJumpInput() => InputJump = false;

    }
}