using ShootEmUp.UI;
using UnityEngine;

namespace ShootEmUp
{
    public class GameUIController : MonoBehaviour, IGameStartListener, IGameFinishListener
    {
        [SerializeField] private ButtonView _gameView;

        [SerializeField] private GameManager _gameManager;

        [SerializeField] private string _pauseText;

        [SerializeField] private string _resumeText;

        private void Start()
        {
            IGameListener.Register(this);
        }

        public void OnStart()
        {
            _gameView.Show();
            _gameView.OnButtonClick += TogglePause;
        }

        public void OnFinish()
        {
            _gameView.OnButtonClick -= TogglePause;
            _gameView.Hide();
        }

        private void TogglePause()
        {
            if (_gameManager.CurrentState == GameState.Running)
            {
                _gameManager.PauseGame();
                _gameView.UpdateText(_resumeText);
            }
            else if (_gameManager.CurrentState == GameState.Paused)
            {
                _gameManager.ResumeGame();
                _gameView.UpdateText(_pauseText);
            }
        }
    }
}