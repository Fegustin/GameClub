﻿using Main;
using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObject.Source.UI
{
    public class SideBarUpUI : MonoBehaviour
    {
        public Item item;

        public Image icon;
        public Text count;
        private Computer _computer;

        private void Start()
        {
            icon.sprite = item.icon;
            count.text = item.count.ToString();
            _computer.GetMoneyEvent += SetCoins;
        }

        private void SetCoins(int coins) => item.count += coins;
    }
}