using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilder
{
    public class PlayerAnimations : MonoBehaviour
    {
        private Animator _playerAnimator;
        // Start is called before the first frame update
        void Start()
        {
            _playerAnimator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SetAnimMovementSpeed(float Speed)
        {
            _playerAnimator.SetFloat("Speed", Speed, 0.0f, Time.deltaTime);
        }
        public void SetJumpBool(bool Jump)
        {
            _playerAnimator.SetBool("Jump", Jump);
        }
        public void SetGroundedBool(bool Grounded)
        {
            _playerAnimator.SetBool("Grounded", Grounded);
        }
    }
}