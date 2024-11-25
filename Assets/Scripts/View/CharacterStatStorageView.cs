using System.Collections.Generic;
using OtusUnityHomework.Presenter;
using UnityEngine;
using VContainer;

namespace OtusUnityHomework.View
{
    public sealed class CharacterStatStorageView : MonoBehaviour
    {
        private ICharacterStatStoragePresenter _presenter;
        
        private readonly List<CharacterStatView> _playerStatViews = new();
        
        private CharacterStatViewFactory _characterStatViewFactory;

        [Inject]
        private void Construct(CharacterStatViewFactory characterStatViewFactory)
        {
            _characterStatViewFactory = characterStatViewFactory;
        }

        public void Show(ICharacterStatStoragePresenter presenter)
        {
            _presenter = presenter;
            gameObject.SetActive(true);
            _presenter.OnStatsUpdated += ShowStats;
            ShowStats();
        }

        private void ShowStats()
        {
            foreach (var playerStatView in _playerStatViews)
            {
                Destroy(playerStatView.gameObject);
            }
            _playerStatViews.Clear();
            
            foreach (var characterStatPresenter in _presenter.GetStats())
            {
                var newStatView = _characterStatViewFactory.Create();
                newStatView.Show(characterStatPresenter);
                _playerStatViews.Add(newStatView);
            }
        }

        public void Hide()
        {
            foreach (var playerStatView in _playerStatViews)
            {
                playerStatView.Hide();
                Destroy(playerStatView.gameObject);
            }
            _playerStatViews.Clear();
            _presenter.OnStatsUpdated -= ShowStats;
            gameObject.SetActive(false);
        }
    }
}