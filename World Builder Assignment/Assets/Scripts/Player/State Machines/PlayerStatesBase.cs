using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilder
{
    public abstract class PlayerStatesBase 
    {

        public PlayerStateController PSC;


        //we have to pass Player State Controller to each state so that they  can also controll state flow on their own(can change state)
        public void OnStateEnter(PlayerStateController psc)
        {
            PSC = psc;
            OnEnter();
        }

        //its like Start()func for each states
        protected virtual void OnEnter()
        {

        }

        //used to add functionality that  always runs that don't have to defin by child states
        public void OnStateUpdate()
        {
            //functionality above OnUpdate() call will always run do not depend on child
            // Code placed here will always run

            OnUpdate();
        }
        //its like update()func for each states
        protected virtual void OnUpdate()
        {
            // Code placed here can be overridden

        }

        public void OnStateExit()
        {
            // Code placed here will always run
            OnExit();
        }
        protected virtual void OnExit()
        {
            // Code placed here can be overridden
        }
    }
}