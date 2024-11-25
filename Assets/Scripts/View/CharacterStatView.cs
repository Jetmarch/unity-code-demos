using OtusUnityHomework.Presenter;
using TMPro;
using UnityEngine;

namespace OtusUnityHomework.View
{
    public sealed class CharacterStatView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _statText;

        private ICharacterStatPresenter _presenter;
        public void Show(ICharacterStatPresenter presenter)
        {
            _presenter = presenter;
            _presenter.OnValueChanged += UpdateView;
            gameObject.SetActive(true);
            UpdateView();
        }

        public void Hide()
        {
            _presenter.OnValueChanged -= UpdateView;
            gameObject.SetActive(false);
        }

        private void UpdateView()
        {
            _statText.text = _presenter.CharacterStat;
        }
    }
}