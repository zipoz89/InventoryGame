using System;
using System.Collections.Generic;
using _Scripts._Items;
using UnityEngine;

namespace _Scripts._Ui
{
    public class CraftingRecipeDisplay : MonoBehaviour
    {
        [SerializeField] private Transform recpieContent;
        [SerializeField] private Transform resultArrow;
        [SerializeField] private ItemDisplayCompact itemDisplayCompactPrefab;

        private CraftingRecipe recipie;

        public Action<CraftingRecipe> OnCraft;

        private List<ItemDisplayCompact> displays;
        
        public void SetUp(CraftingRecipe recipie)
        {
            Clear();
            
            this.recipie = recipie;

            foreach (var item in recipie.Ingredients)
            {
                var display = GenericObjectPooler.SpawnObject(itemDisplayCompactPrefab.gameObject, Vector3.zero, Quaternion.identity, GenericObjectPooler.PoolType.ItemDisplay).GetComponent<ItemDisplayCompact>();
                display.transform.SetParent(recpieContent);
                display.SetUp(item);
                displays.Add(display);
            }
            resultArrow.transform.SetParent(recpieContent);
            foreach (var item in recipie.Result)
            {
                var display = GenericObjectPooler.SpawnObject(itemDisplayCompactPrefab.gameObject, Vector3.zero, Quaternion.identity, GenericObjectPooler.PoolType.ItemDisplay).GetComponent<ItemDisplayCompact>();
                display.transform.SetParent(recpieContent);
                display.SetUp(item);
                displays.Add(display);
            }
        }

        public void Clear()
        {
            if (displays == null)
            {
                displays = new();
            }
            else
            {
                for (int i = 0; i < displays.Count; i++)
                {

                    GenericObjectPooler.ReturnObjectToPool(displays[i].gameObject);
                }
                displays = new();
            }
        }

        public void Craft()
        {
            OnCraft?.Invoke(recipie);
        }
    }
}
