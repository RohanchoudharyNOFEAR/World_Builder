using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilder
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerChecks : MonoBehaviour
    {
        public CharacterController _cc;

        private void Update()
        {
            GroundCheck();
        }



        public bool GroundCheck()
        {
            if (_cc.isGrounded)
            {
                return true;
            }
            else { return false; }
        }

    }
}
