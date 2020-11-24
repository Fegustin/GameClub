using UnityEngine;

namespace ScriptableObject.Source {
    [CreateAssetMenu(fileName = "ItemDate", menuName = "ScriptableObject/Item", order = 0)]
    public class Item : UnityEngine.ScriptableObject {
        public new string name = "Item";
        public Sprite icon;
        public int count;
    }
}