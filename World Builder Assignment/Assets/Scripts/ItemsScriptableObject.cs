using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldBuilder
{
    [CreateAssetMenu(menuName = "Innventory/ItemsCategorySO")]
    public class ItemsScriptableObject : ScriptableObject
    {

        public GameObject[] items;
    }
}
