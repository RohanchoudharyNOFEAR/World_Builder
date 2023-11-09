using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace WorldBuilder
{
    public class WorldBuilderInterface : MonoBehaviour
    {
        public GameObject[] objects;
        private GameObject pendingObject;

        private Vector3 pos;

        private RaycastHit hit;
        [SerializeField]
        private LayerMask layerMask;
        public float gridSize;
        public float rotateAmount;
        bool gridOn = true;
        [SerializeField] private Toggle gridToggle;

        void Update()
        {
            if (pendingObject != null)
            {
                if (gridOn)
                {
                    pendingObject.transform.position = new Vector3(
                    RoundToNearestGrid(pos.x),
                    RoundToNearestGrid(pos.y),
                    RoundToNearestGrid(pos.z)
                    );
                }
                else
                {
                    pendingObject.transform.position = pos;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    PlaceObject();
                }
                if(Input.GetKeyDown(KeyCode.R))
{
                    RotateObject();
                }
            }
        }

        public void PlaceObject()
        {
            pendingObject = null;
        }

        private void FixedUpdate()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000, layerMask))
            {
                pos = hit.point;
            }
        }
        public void Selectobject(int index)
        {
            pendingObject = Instantiate(objects[index], pos, transform.rotation);
        }

        public void ToggleGrid()
        {
            if (gridToggle.isOn)
            {
                gridOn = true;
            }
            else { gridOn = false; }
        }
        float RoundToNearestGrid(float pos)
        {
            //Changeable grid system
            float xDiff = pos % gridSize;
            pos -= xDiff;
            if (xDiff > (gridSize / 2))
            {
                pos += gridSize;
            }
            return pos;
        }

        void RotateObject()
        {
            pendingObject.transform.Rotate(Vector3.up, rotateAmount);
        }

    }
}