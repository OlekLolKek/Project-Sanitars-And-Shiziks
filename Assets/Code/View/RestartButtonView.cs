using Code.ViewModel;
using UnityEngine;
using UnityEngine.UI;


namespace Code.View
{
    public sealed class RestartButtonView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private IGameViewModel _gameViewModel;

        public void Initialize(IGameViewModel gameViewModel)
        {
            _gameViewModel = gameViewModel;
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(_gameViewModel.RestartGame);
        }
    }
}