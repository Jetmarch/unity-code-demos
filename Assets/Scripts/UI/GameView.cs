using System;
using UnityEngine;

namespace ShootEmUp.UI
{
    public class GameView : MonoBehaviour
    {
        public ButtonView TogglePauseButton => _togglePauseButton;
        
        [SerializeField] private ButtonView _togglePauseButton;

        public void Show()
        {
            _togglePauseButton.Show();
        }
        public void Hide()
        {
            _togglePauseButton.Hide();
        }

        public void UpdateTogglePauseButtonText(string newText)
        {
            _togglePauseButton.UpdateText(newText);
        }
    }
}