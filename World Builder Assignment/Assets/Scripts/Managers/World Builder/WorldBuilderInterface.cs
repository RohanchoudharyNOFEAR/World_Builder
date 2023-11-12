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
        public GameObject pendingObject;

        private Vector3 pos;

        private RaycastHit hit;
        [SerializeField]
        private LayerMask layerMask;
        public float gridSize;
        public float rotateAmount;
        bool gridOn = true;

        public bool canPlace = true;

        public GameObject inventoryPanel;
        public GameObject selectionPanel;
        public GameObject PlacementPanel;
        [SerializeField] private Toggle gridToggle;
        [SerializeField] private Material[] materials;

        [Header("Touch")]
        private bool toPlace = false;


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
                //if (Input.GetMouseButtonDown(0) && canPlace)
                //{
                //    PlaceObject();
                //}
                //if (Input.GetKeyDown(KeyCode.R))
                //{
                //    RotateObject();
                //}
                UpdateMaterials();
                PlacementPanel.SetActive(true);
            }
            else
            {
                PlacementPanel.SetActive(false);
            }

            

        }



        public void PlaceObject()
        {
            if (!canPlace) { return; }
            pendingObject.GetComponent<MeshRenderer>().material = materials[2];
            pendingObject = null;
        }
        Ray ray;
        private void FixedUpdate()
        {

            //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            //{

            //    Vector3 fingerPos = Input.GetTouch(0).position;
            //    Vector3 position = fingerPos;
            //    position.z = 8;
            //    Debug.Log("touch");
            //    Vector3 realWorldPos = Camera.main.ScreenToWorldPoint(position);
            //    ray = Camera.main.ScreenPointToRay(realWorldPos);
            //    if (Physics.Raycast(ray, out hit, 1000, layerMask))
            //    {
            //        pos = hit.point;
            //    }
            //}


            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                // Check if the touch hits a UI element
                if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                {
                    // Perform raycast only if not over a UI element
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    {
                        if (Physics.Raycast(ray, out hit, 1000, layerMask))
                        {


                            // Debug.Log(IsPointerOverGameObject());
                            pos = hit.point;
                            Debug.Log("Raycast hit: " + hit.collider.name);
                        }
                    }

                }

                // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //if (Physics.Raycast(ray, out hit, 1000, layerMask))
                //{
                //    pos = hit.point;
                //}
            }
        }

        //public bool IsPointerOverGameObject()
        //{
        //    // Check mouse
        //    //if (EventSystem.current.IsPointerOverGameObject())
        //    //{
        //    //    return true;
        //    //}

        //    // Check touches
        //    for (int i = 0; i < Input.touchCount; i++)
        //    {
        //        var touch = Input.GetTouch(i);
        //        if (touch.phase == TouchPhase.Began)
        //        {
        //            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        //            {
        //                return true;
        //            }
        //        }
        //    }

        //    return false;
        //}

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

        public void RotateObject()
        {
            pendingObject.transform.Rotate(Vector3.up, rotateAmount);
        }

        public void OpenInventory()
        {
            if (selectionPanel.activeInHierarchy) { selectionPanel.SetActive(false); }
            if (inventoryPanel.activeInHierarchy == false)
            { inventoryPanel.SetActive(true); }
            else
            {
                inventoryPanel.SetActive(false);
            }

        }

        void UpdateMaterials()
        {
            if (canPlace)
            {
                pendingObject.GetComponent<MeshRenderer>().material = materials[0];
            }
            else
            {
                pendingObject.GetComponent<MeshRenderer>().material = materials[1];
            }
        }

    }
}
