using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldBuilder;
using static UnityEditor.PlayerSettings;

namespace WorldBuilder
{
    public class AbilityState : PlayerStatesBase
    {
        protected bool IsAbilityDone;

        protected override void OnEnter()
        {
            base.OnEnter();
            IsAbilityDone = false;
        }

        protected override void OnExit()
        {
            base.OnExit();
            PSC.PlayerAnimations.SetJumpBool(false);
            PSC.playerInputs.UsedJumpInput();
        }

        protected override void OnUpdate()
        {

            base.OnUpdate();
            if (IsAbilityDone)
            {
                if (PSC.PlayerMovement.Cc.isGrounded)
                {
                    PSC.ChangeState(PSC.IdleState);
                }
                else
                {
                    PSC.ChangeState(PSC.InAirState);
                }
            }
        }
    }
}