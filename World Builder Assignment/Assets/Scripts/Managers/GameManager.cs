using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilder
{
    public class GameManager : MonoBehaviour
    {
        public GameObject player;
        public void Explore()
        {
            player.SetActive(true);
        }

    }
}
