using System;
using System.Collections;
using UnityEngine;


namespace ShootEmUp
{
    public class StartGameTimer
    {
        public event Action<int> OnTimerUpdate;
        
        private readonly GameManager _gameManager;
        private readonly int _delayInSec = 3;

        public StartGameTimer(GameManager gameManager, int delayInSec)
        {
            _gameManager = gameManager;
            _delayInSec = delayInSec;
        }
        
        public void StartGame()
        {
            _gameManager.StartCoroutine(DelayedStartGame());
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