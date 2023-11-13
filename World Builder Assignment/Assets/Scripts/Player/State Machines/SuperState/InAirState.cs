using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace WorldBuilder
{
    public class InAirState : PlayerStatesBase
    {
        protected override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("entered inair state");

        }

        protected override void OnExit()
        {
            base.OnExit();
            PSC.PlayerAnimations.SetJumpBool(false);
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            PSC.PlayerJump.Jump(PSC.PlayerMovement.Cc, PSC.PlayerMovement.PlayerVelocityVector, PSC.playerInputs.InputJump);
            if (PSC.PlayerMovement.Cc.isGrounded)
            {
                PSC.ChangeState(PSC.IdleState);
            }

        }
    }
}