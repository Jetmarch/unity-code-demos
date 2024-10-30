using ShootEmUp.UI;
using VContainer;

namespace ShootEmUp
{
    public class GameUIController : IGameStartListener, IGameFinishListener
    {
        private readonly GameView _gameView;

        private readonly GameManager _gameManager;

        private const string PauseText = "PAUSE";

        private const string ResumeText = "RESUME";

        [Inject]
        public GameUIController(GameView gameView, GameManager gameManager)
        {
            _gameView = gameView;
            _gameManager = gameManager;
        }

        public void OnStart()
        {
            _gameView.Show();
            _gameView.TogglePauseButton.OnButtonClick += TogglePause;
        }

        public void OnFinish()
        {
            _gameView.TogglePauseButton.OnButtonClick -= TogglePause;
            _gameView.Hide();
        }

        private void TogglePause()
        {
            if (_gameManager.CurrentState == GameState.Running)
            {
                _gameManager.PauseGame();
                _gameView.UpdateTogglePauseButtonText(ResumeText);
            }
            else if (_gameManager.CurrentState == GameState.Paused)
            {
                _gameManager.ResumeGame();
                _gameView.UpdateTogglePauseButtonText(PauseText);
            }
        }
    }
}