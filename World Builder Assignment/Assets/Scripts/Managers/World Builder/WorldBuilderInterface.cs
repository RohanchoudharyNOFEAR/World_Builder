using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace WorldBuilder
{
    public class WorldBuilderInterface : MonoBehaviour
    {
       
        private GameObject inventoryPanel;
        private GameObject selectionPanel;
        private GameObject PlacementPanel;
        public ItemsScriptableObject[] itemsCategories;
        public float gridSize;
        public float rotateAmount;
        public bool canPlace = true;

        [SerializeField] private LayerMask layerMask;
        [SerializeField] private Toggle gridToggle;
        [SerializeField] private Material[] materials;
        [SerializeField] private GameObject[] objects;
        [HideInInspector] public GameObject pendingObject;      
        private Vector3 pos;
        private ItemsScriptableObject currentItemCategory;
       
        [HideInInspector]
        private RaycastHit hit;
        bool gridOn = true;
        [Header("Touch")]
        private bool toPlace = false;

        private void Start()
        {
            inventoryPanel = GameManager.instance.InventoryPanel;
            PlacementPanel = GameManager.instance.PlacementPanel;
            selectionPanel = GameManager.instance.SelectionPanel;
        }

        void Update()
        {
            //test fixed update
            if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Began|| Input.GetTouch(0).phase == TouchPhase.Moved))
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
                            pos = hit.point;
                            Debug.Log("Raycast hit: " + hit.collider.name);
                        }
                    }

                }

                //For MouseInput
                // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                //if (Physics.Raycast(ray, out hit, 1000, layerMask))
                //{
                //    pos = hit.point;
                //}
            }//test fixed update


            if (currentItemCategory != null)
            {
                objects = currentItemCategory.items;
            }

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

                //OnMouseInput();
                UpdateMaterials();
                PlacementPanel.SetActive(true);
            }
            else
            {
                PlacementPanel.SetActive(false);
            }



        }//UPDATE

        //void MouseInput()
        //{

        //    //if (Input.GetMouseButtonDown(0) && canPlace)
        //    //{
        //    //    PlaceObject();
        //    //}
        //    //if (Input.GetKeyDown(KeyCode.R))
        //    //{
        //    //    RotateObject();
        //    //}
        //}

        public void PlaceObject()
        {
            if (!canPlace) { return; }
            pendingObject.GetComponent<MeshRenderer>().material = materials[2];
            pendingObject = null;
        }//PLACEOBJECT
      
        //private void FixedUpdate()
        //{

        //    if (Input.touchCount > 0)
        //    {
        //        Touch touch = Input.GetTouch(0);

        //        // Check if the touch hits a UI element
        //        if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
        //        {
        //            // Perform raycast only if not over a UI element
        //            Ray ray = Camera.main.ScreenPointToRay(touch.position);
        //            {
        //                if (Physics.Raycast(ray, out hit, 1000, layerMask))
        //                {
        //                    pos = hit.point;
        //                    Debug.Log("Raycast hit: " + hit.collider.name);
        //                }
        //            }

        //        }

        //        //For MouseInput
        //        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //        //if (Physics.Raycast(ray, out hit, 1000, layerMask))
        //        //{
        //        //    pos = hit.point;
        //        //}
        //    }
        //}//FIXED UPDATE

        public void SelectItemsCategory(int index)
        {
            GameManager.instance.InventoryItemsPanel.SetActive(true);
            currentItemCategory = itemsCategories[index];
        }//Select Items Category

        public void Selectobject(int index)
        {
            pendingObject = Instantiate(objects[index], pos, transform.rotation);
        }//SELECTOBJECT

        public void ToggleGrid()
        {
            if (gridToggle.isOn)
            {
                gridOn = true;
            }
            else { gridOn = false; }
        }//TOGGLEGRID

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
        }//ROUND TO NEARESTGRID

        public void RotateObject()
        {
            pendingObject.transform.Rotate(Vector3.up, rotateAmount);
        }//ROTATE

        public void OpenInventory()
        {
            if (selectionPanel.activeInHierarchy) { selectionPanel.SetActive(false); }
            if (inventoryPanel.activeInHierarchy == false)
            { inventoryPanel.SetActive(true); }
            else
            {
                inventoryPanel.SetActive(false);
            }

        }//OPENINVENTORY

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
        }//UPDATEMATERIALS

    }
}
