using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace WorldBuilder
{
    public class GroundedState : PlayerStatesBase
    {
        protected Vector3 Input;

        protected override void OnEnter()
        {
            PSC.PlayerMovement.enabled = true;
            setGravityvalue();
            Debug.Log("Entered Into GroundedState");
            // PSC.playerInputs.UsedJumpInput();
            // PSC.PlayerAnimations.SetJumpBool(false);
            base.OnEnter();
        }
        protected override void OnUpdate()
        {
            base.OnUpdate();

            PSC.CameraController.CameraMove(PSC.playerInputs.InputMouseVector);
            PSC.PlayerAnimations.SetGroundedBool(true);
            PSC.PlayerAnimations.SetAnimMovementSpeed(Mathf.Clamp01(Input.magnitude));

            handleJump();

            // Debug.Log("update call Into GroundedState");
        }
        protected override void OnExit()
        {
            Debug.Log(" Exit From GroundedState");
            base.OnExit();
        }
        void handleJump()
        {

            Input = PSC.playerInputs.InputMovementVector;

            if (PSC.playerInputs.InputJump)
            {

                PSC.ChangeState(PSC.JumpState);
                PSC.playerInputs.UsedJumpInput();
            }

        }

        void setGravityvalue()
        {
            PSC.PlayerJump.verticalVelocity = -PSC.PlayerJump.Gravity * Time.deltaTime;
        }
    }
}