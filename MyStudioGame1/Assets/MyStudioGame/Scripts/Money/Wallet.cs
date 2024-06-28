using Player;
using System;
using UnityEngine;

namespace Money
{
    public class Wallet
    {
        private int _coins;

        public event Action<int> CoinChanged;
        public int Coins => _coins;

        public Wallet(Data data)
        {
            _coins = data.Coins;
        }

        public void AddCoin(int value)
        {
            if(value < 0)
            {
                Debug.Log("Value < 0");
            }

            _coins += value;
            CoinChanged?.Invoke(_coins);
        }

        public void SpendCoin(int value)
        {
            if (value < 0)
            {
                Debug.Log("Value < 0");
            }

            _coins -= value;
            CoinChanged?.Invoke(_coins);
        }
    }
}
