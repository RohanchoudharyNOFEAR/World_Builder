using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

namespace WorldBuilder
{
    public class JumpState : AbilityState
    {
        protected override void OnEnter()
        {
            base.OnEnter();
            Debug.Log("entered jump state");

            PSC.PlayerJump.enabled = true;
            PSC.PlayerAnimations.SetJumpBool(true);
            PSC.PlayerJump.verticalVelocity = PSC.PlayerJump.JumpForce;
            PSC.PlayerJump.Jump(PSC.PlayerMovement.Cc, PSC.PlayerMovement.PlayerVelocityVector, PSC.playerInputs.InputJump);
            IsAbilityDone = true;
        }
        protected override void OnExit()
        {
            base.OnExit();
        }

        protected override void OnUpdate()
        {
            base.OnUpdate();
            PSC.PlayerJump.Jump(PSC.PlayerMovement.Cc, PSC.PlayerMovement.PlayerVelocityVector, PSC.playerInputs.InputJump);
        }
    }
}