using UnityEngine;

namespace _Scripts._Items
{
    //ten scriptable jest wraperem dla zwykłej klasy aby uniknąć tworzenia instancji scriptabli, z odynem dalo by się to jeszcze lepiej zrobić tak aby dało się w edytorze wstawiać ten scriptable w serializowane pola typu Item
    [CreateAssetMenu(menuName = "InventoryGame/Items/Item")]
    public class ItemScriptableObject : ScriptableObject
    {
        public Item Item;
    }

}