using System;
using System.Collections.Generic;
using _Scripts._Items;
using UnityEngine;

namespace _Scripts._Ui
{
    public class CraftingViewController : MonoBehaviour
    {
        [SerializeField] private Transform recpiesContentParent;
        [SerializeField] private CraftingRecipeDisplay craftingRecipeDisplayPrefab;
        [SerializeField] private CraftingRecipeTable craftingRecipeTable;
        
        private List<CraftingRecipeDisplay> recpiesDisplay;
        
        public Action<CraftingRecipe> OnRecipeCraft;
        
        
        
        public void RebuildCraftingView(Inventory inventory)
        {
            ClearInventoryView();
            for (int i = 0; i < craftingRecipeTable.Recpies.Length; i++)
            {
                CraftingRecipe recipe = craftingRecipeTable.Recpies[i];

                if (inventory.ContainsAllIngredients(recipe.Ingredients))
                {
                    var display = GenericObjectPooler.SpawnObject(craftingRecipeDisplayPrefab.gameObject, Vector3.zero, Quaternion.identity, GenericObjectPooler.PoolType.ItemDisplay).GetComponent<CraftingRecipeDisplay>();
                    display.transform.SetParent(recpiesContentParent);
                    display.SetUp(recipe);
                    display.OnCraft += OnCraft;
                    recpiesDisplay.Add(display);
                }
            }
        }
        
        private void ClearInventoryView()
        {
            if (recpiesDisplay == null)
            {
                recpiesDisplay = new();
            }
            else
            {
                for (int i = 0; i < recpiesDisplay.Count; i++)
                {
                    recpiesDisplay[i].OnCraft -= OnCraft;
                    GenericObjectPooler.ReturnObjectToPool(recpiesDisplay[i].gameObject);
                }
                recpiesDisplay = new();
            }


        }

        private void OnCraft(CraftingRecipe recpie)
        {
            OnRecipeCraft?.Invoke(recpie);
        }
    }
}
