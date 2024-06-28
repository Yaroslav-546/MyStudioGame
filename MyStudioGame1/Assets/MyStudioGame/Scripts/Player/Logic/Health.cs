using UnityEngine;

namespace Player
{
    public class Health
    {
        private Data _playerData;
        private IDataSaver _saver;

        public Health(Data playerData, IDataSaver saver)
        {
            _playerData = playerData;
            _saver = saver;
        }

        public void AddHealth(int count)
        {
            if (count < 0)
            {
                Debug.Log("Count меньше нуля");
                return;
            }

            _playerData.Health += count;
            _saver.Save();
        }

        public void SpendHealth(int count)
        {
            if (count < 0)
            {
                Debug.Log("Count меньше нуля");
                return;
            }

            _playerData.Health -= count;
            _saver.Save();
        }
    }
}
