using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilder
{
    public class PlayerManager : MonoBehaviour
    {
        PlayerInputs _playerInputs;
        PlayerMovement _playerMovement;


        // Start is called before the first frame update
        void Start()
        {
            _playerInputs = GetComponent<PlayerInputs>();
            _playerMovement = GetComponent<PlayerMovement>();
        }

        // Update is called once per frame
        void Update()
        {
            movePlayer();
        }

        void movePlayer()
        {
            _playerMovement.Move(_playerInputs.InputMovementVector);
        }
    }
}
