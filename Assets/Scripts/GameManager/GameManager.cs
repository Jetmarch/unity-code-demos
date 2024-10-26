using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class GameManager : MonoBehaviour
    {
        public GameState CurrentState => _state;

        private readonly List<IGameListener> _gameListeners = new();
        private readonly List<IGameUpdateListener> _gameUpdateListeners = new();
        private readonly List<IGameFixedUpdateListener> _gameFixedUpdateListeners = new();

        private GameState _state;

        private void Awake()
        {
            IGameListener.OnRegister += RegisterListener;
        }

        private void RegisterListener(IGameListener obj)
        {
            _gameListeners.Add(obj);
            
            if (obj is IGameUpdateListener updateListener)
            {
                _gameUpdateListeners.Add(updateListener);
            }

            if (obj is IGameFixedUpdateListener fixedUpdateListener)
            {
                _gameFixedUpdateListeners.Add(fixedUpdateListener);
            }
        }

        private void RemoveListener(IGameListener obj)
        {
            _gameListeners.Remove(obj);
            
            if (obj is IGameUpdateListener updateListener)
            {
                _gameUpdateListeners.Remove(updateListener);
            }

            if (obj is IGameFixedUpdateListener fixedUpdateListener)
            {
                _gameFixedUpdateListeners.Remove(fixedUpdateListener);
            }
        }

        private void Update()
        {
            if (_state != GameState.Running) return;

            var delta = Time.deltaTime;
            foreach(var listener in _gameUpdateListeners)
            {
                listener.OnUpdate(delta);
            }
        }

        private void FixedUpdate()
        {
            if (_state != GameState.Running) return;

            var delta = Time.fixedDeltaTime;
            foreach (var listener in _gameFixedUpdateListeners)
            {
                listener.OnFixedUpdate(delta);
            }
        }

        [ContextMenu("Start game")]
        public void StartGame()
        {
            _state = GameState.Starting;
            foreach (var listener in _gameListeners)
            {
                if (listener is IGameStartListener startListener)
                {
                    startListener.OnStart();
                }
            }
            _state = GameState.Running;
        }

        [ContextMenu("Finish game")]
        public void FinishGame()
        {
            _state = GameState.Finished;
            foreach (var listener in _gameListeners)
            {
                if (listener is IGameFinishListener finishListener)
                {
                    finishListener.OnFinish();
                }
            }
            
            Debug.Log("Finish game");
        }

        [ContextMenu("Pause game")]
        public void PauseGame()
        {
            _state = GameState.Paused;
            foreach (var listener in _gameListeners)
            {
                if (listener is IGamePauseListener pauseListener)
                {
                    pauseListener.OnPause();
                }
            }
        }

        [ContextMenu("Resume game")]
        public void ResumeGame()
        {
            _state = GameState.Running;
            foreach (var listener in _gameListeners)
            {
                if(listener is IGameResumeListener resumeListener)
                {
                    resumeListener.OnResume();
                }
            }
        }

    }
}