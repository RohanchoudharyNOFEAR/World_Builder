using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WorldBuilder;

namespace WorldBuilder
{
    public class CheckPlacement : MonoBehaviour
    {
        WorldBuilderInterface buildingManager;

        void Start()
        {
            buildingManager = GameObject.Find("BuildingManager").GetComponent<WorldBuilderInterface>();
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Object"))
            {
                buildingManager.canPlace = false;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Object"))
            {
                buildingManager.canPlace = true;
            }
        }
    }
}