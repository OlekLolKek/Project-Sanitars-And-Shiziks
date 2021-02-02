using Code.Enum;
using Code.ViewModel;
using UnityEngine;
using UnityEngine.UI;


namespace Code.View
{
    public sealed class PlayerTurnPanelView : MonoBehaviour
    {
        [SerializeField] private Image _panel;
        [SerializeField] private Button _button;
        [SerializeField] private TurnStates _side;
        private IGameViewModel _gameViewModel;
        
        public Image Panel => _panel;
        public Button Button => _button;

        public void Initialize(IGameViewModel gameViewModel)
        {
            _gameViewModel = gameViewModel;
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(() => _gameViewModel.SetStartingSide(_side));
        }
    }
}