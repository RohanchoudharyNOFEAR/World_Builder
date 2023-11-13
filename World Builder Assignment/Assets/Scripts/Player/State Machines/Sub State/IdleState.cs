using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldBuilder;


namespace WorldBuilder
{
    public class IdleState : GroundedState
    {
        protected override void OnEnter()
        {
            //  PSC.PlayerMovement.enabled = false;
            Debug.Log("Entered Into IdleState");
            base.OnEnter();
        }
        protected override void OnUpdate()
        {

            base.OnUpdate();

            if (Input.x != 0 || Input.z != 0)
            {

                PSC.ChangeState(PSC.MoveState);
            }

            //   Debug.Log("update call Into IdleState");
        }
        protected override void OnExit()
        {
            Debug.Log(" Exit From IdleState");
            base.OnExit();
        }
    }
}