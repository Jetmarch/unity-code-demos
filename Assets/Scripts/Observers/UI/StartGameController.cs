using ShootEmUp.UI;
using UnityEngine;

namespace ShootEmUp
{
    public class StartGameController : MonoBehaviour, IGameStartListener
    {
        [SerializeField] private ButtonView _startGameView;

        [SerializeField] private ButtonView _gameView;

        [SerializeField] private StartGameTimer _startGameTimer;

        private void Start()
        {
            IGameListener.Register(this);
        }

        /// <summary>
        /// Использован OnEnable, так как StartGameController запускает игровой цикл
        /// </summary>
        private void OnEnable()
        {
            _startGameView.OnButtonClick += _startGameTimer.StartGame;
            _startGameTimer.OnTimerUpdate += UpdateStartGameTimerText;
        }

        /// <summary>
        /// Использован OnDisable, так как StartGameController запускает игровой цикл
        /// </summary>
        private void OnDisable()
        {
            _startGameView.OnButtonClick -= _startGameTimer.StartGame;
            _startGameTimer.OnTimerUpdate -= UpdateStartGameTimerText;
        }

        private void UpdateStartGameTimerText(int time)
        {
            _startGameView.UpdateText(time.ToString());
        }

        public void OnStart()
        {
            _startGameView.Hide();
            _gameView.Show();
        }
    }
}