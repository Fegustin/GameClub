using System;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObject.Source.UI {
    public class SideBarUpUI : MonoBehaviour {

        public Item item;
        public Image icon;
        
        public Text count;

        private void Start() {
            icon.sprite = item.icon;
            count.text = item.count.ToString();
        }
    }
}