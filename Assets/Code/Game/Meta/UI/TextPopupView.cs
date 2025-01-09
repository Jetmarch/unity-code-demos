using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Game.UI
{
    public class TextPopupView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private CanvasGroup _container;
        
        [SerializeField] private float _fadeDuration = 0.3f;
        [SerializeField] private float _popupTimeToLive = 5f;

        private Sequence _showSequence;
        
        [Button]
        public void Show(string text)
        {
            _text.text = text;
            _showSequence = DOTween.Sequence();
            _showSequence.Append(_container.DOFade(1f, _fadeDuration))
                         .AppendInterval(_popupTimeToLive)
                         .AppendCallback(Hide);
        }

        [Button]
        public void Hide()
        {
            _container.DOFade(0f, _fadeDuration);
        }
    }
}
