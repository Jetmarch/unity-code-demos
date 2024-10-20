using System;
using System.Collections;
using UnityEngine;


namespace ShootEmUp
{
    public class StartGameTimer : MonoBehaviour
    {
        public event Action<int> OnTimerUpdate;

        [SerializeField] private int _delayInSec = 3;

        [SerializeField] private GameManager _gameManager;

        public void StartGame()
        {
            StartCoroutine(DelayedStartGame());
        }

        private IEnumerator DelayedStartGame()
        {
            int remainingSeconds = _delayInSec;
            while(remainingSeconds > 0)
            {
                OnTimerUpdate?.Invoke(remainingSeconds);
                yield return new WaitForSeconds(1f);
                remainingSeconds--;
            }
            _gameManager.StartGame();
        }
    }
}