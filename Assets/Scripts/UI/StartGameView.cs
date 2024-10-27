using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ShootEmUp.UI
{
    public class StartGameView : MonoBehaviour
    {
        public ButtonView StartGameButton => _startGameButton;
        
        [SerializeField] private ButtonView _startGameButton;

        public void Show()
        {
            _startGameButton.Show();
        }
        public void Hide()
        {
            _startGameButton.Hide();
        }

        public void UpdateStartGameButtonText(string newText)
        {
            _startGameButton.UpdateText(newText);
        }
    }
}