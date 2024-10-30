using ShootEmUp.UI;
using System;
using VContainer.Unity;

namespace ShootEmUp
{
    public class StartGameController : IGameStartListener, IInitializable, IDisposable
    {
        private readonly StartGameView _startGameView;

        private readonly GameView _gameView;

        private readonly StartGameTimer _startGameTimer;

        public StartGameController(StartGameView startGameView, GameView gameView, StartGameTimer startGameTimer)
        {
            _startGameTimer = startGameTimer;
            _gameView = gameView;
            _startGameView = startGameView;
        }

        public void Initialize()
        {
            _startGameView.StartGameButton.OnButtonClick += _startGameTimer.StartGame;
            _startGameTimer.OnTimerUpdate += UpdateStartGameTimerText;
        }

        public void Dispose()
        {
            _startGameView.StartGameButton.OnButtonClick -= _startGameTimer.StartGame;
            _startGameTimer.OnTimerUpdate -= UpdateStartGameTimerText;
        }

        private void UpdateStartGameTimerText(int time)
        {
            _startGameView.UpdateStartGameButtonText(time.ToString());
        }

        public void OnStart()
        {
            _startGameView.Hide();
            _gameView.Show();
        }
    }
}