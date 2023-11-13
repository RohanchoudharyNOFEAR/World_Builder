using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine.EventSystems;

namespace WorldBuilder
{
    public class Selection : MonoBehaviour
    {     
        public TextMeshProUGUI objNameTxt;
        [HideInInspector] public GameObject selectedObject;
        private WorldBuilderInterface buildingManager;

        private void Start()
        {
            buildingManager = GameObject.Find("BuildingManager").GetComponent<WorldBuilderInterface>();
        }//START

        void Update()
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, 1000))
                    {
                        if (hit.collider.gameObject.CompareTag("Object"))
                        {
                            //buildingManager.selectionPanel.SetActive(true);
                         GameManager.instance.SelectionPanel.SetActive(true);
                            GameManager.instance.InventoryPanel.SetActive(false);
                            Select(hit.collider.gameObject);
                        }
                    }
                }
            }



            //FOR MOUSE INPUT
            //if (Input.GetMouseButtonDown(0))
            //{
            //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //    RaycastHit hit;
            //    if (Physics.Raycast(ray, out hit, 1000))
            //    {
            //        if (hit.collider.gameObject.CompareTag("Object"))
            //        {   
            //            buildingManager.selectionPanel.SetActive(true) ;
            //            buildingManager.inventoryPanel.SetActive(false);
            //            Select(hit.collider.gameObject);
            //        }
            //    }
            //}
            //FOR MOUSE INPUT
            //if (Input.GetMouseButtonDown(1) && selectedObject != null)
            //{
            //    buildingManager.inventoryPanel.SetActive(false);
            //    Deselect();
            //}
        }//UPDATE

        private void Select(GameObject obj)
        {
            if (obj == selectedObject) return;

            if (selectedObject != null) Deselect();
            Outline outline = obj.GetComponent<Outline>();
            if (outline == null) obj.AddComponent<Outline>();
            else outline.enabled = true;
            objNameTxt.text = obj.name;
            selectedObject = obj;
        }//SELECT

        public void Delete()
        {
            GameManager.instance.SelectionPanel.SetActive(false);
            GameObject objToDestroy = selectedObject;
            Deselect();
            Destroy(objToDestroy);
        }//DELETE

        public void Deselect()
        {
            if (selectedObject != null)
            {
                selectedObject.GetComponent<Outline>().enabled = false;
                selectedObject = null;
                GameManager.instance.SelectionPanel.SetActive(false);
            }
        }//DESELECT

        public void Move()
        {
            buildingManager.pendingObject = selectedObject;
        }//MOVE
    }
}