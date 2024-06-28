using System;
using TMPro;

namespace Money
{
    public class CoinDisplay : IDisposable
    {
        private TextMeshProUGUI _text;
        private Wallet _wallet;

        public CoinDisplay(Wallet wallet, TextMeshProUGUI text)
        {
            _text = text;
            _wallet = wallet;
            DisplayCoin(wallet.Coins);

            _wallet.CoinChanged += DisplayCoin;
        }

        public void Dispose()
        {
            _wallet.CoinChanged -= DisplayCoin;
        }

        private void DisplayCoin(int value)
        {
            _text.text = "Money: " + value;
        }
    }
}
