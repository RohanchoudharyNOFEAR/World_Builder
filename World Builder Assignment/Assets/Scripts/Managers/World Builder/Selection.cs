using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace WorldBuilder
{
    public class Selection : MonoBehaviour
    {
        public GameObject selectedObject;
        
        public TextMeshProUGUI objNameTxt;
        private WorldBuilderInterface buildingManager;

        private void Start()
        {
            buildingManager = GameObject.Find("BuildingManager").GetComponent<WorldBuilderInterface>();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1000))
                {
                    if (hit.collider.gameObject.CompareTag("Object"))
                    {   
                        buildingManager.selectionPanel.SetActive(true) ;
                        buildingManager.inventoryPanel.SetActive(false);
                        Select(hit.collider.gameObject);
                    }
                }
            }

            if (Input.GetMouseButtonDown(1) && selectedObject!=null)
            {
                buildingManager.inventoryPanel.SetActive(false);
                Deselect();
            }
        }

        private void Select(GameObject obj)
        {
            if (obj == selectedObject) return;
           
            if (selectedObject != null) Deselect();
            Outline outline = obj.GetComponent<Outline>();
            if (outline == null) obj.AddComponent<Outline>();
            else outline.enabled = true;
            objNameTxt.text = obj.name;
            selectedObject = obj;
        }

        public void Delete()
        {
            buildingManager.selectionPanel.SetActive(false) ;
            GameObject objToDestroy = selectedObject;
            Deselect();
            Destroy(objToDestroy);
        }

        private void Deselect()
        {
            selectedObject.GetComponent<Outline>().enabled = false;
            selectedObject = null;

        }
        public void Move()
        {
            buildingManager.pendingObject = selectedObject;
        }
    }
}