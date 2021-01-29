using UnityEngine;
using UnityEngine.UI;


namespace Code.View
{
    public sealed class GridSpace : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _buttonImage;

        public Button Button => _button;
        public Image ButtonImage => _buttonImage;
        public int ID { get; set; }

        private GameViewModel _gameViewModel;

        public void SetGameControllerReference(GameViewModel viewModel)
        {
            _gameViewModel = viewModel;
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(() => _gameViewModel.SetSpace());
        }
        
        public void SetSpace()
        {
            _buttonImage.sprite = _gameViewModel.GetPlayerSide();
            _button.interactable = false;
            _gameViewModel.EndTurn();
        }
    }
}
