using Code.Enum;
using Code.ViewModel;
using UnityEngine;
using UnityEngine.UI;


namespace Code
{
    public sealed class GridSpace : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _playerOneImage;
        [SerializeField] private Image _playerTwoImage;

        public Button Button => _button;
        public Image PlayerOneImage => _playerOneImage;
        public int ID { get; set; }
        public TurnStates TurnState { get; set; }

        private GameViewModel _gameViewModel;

        public void InjectGameViewModel(GameViewModel gameViewModel)
        {
            _gameViewModel = gameViewModel;
            _button.onClick.RemoveAllListeners();
            //_button.onClick.AddListener(() => _gameViewModel.SetSpace());
        }
        
        public void SetSpace()
        {
            //_buttonImage.sprite = _gameViewModel.GetPlayerSide();
            _button.interactable = false;
            //_gameViewModel.EndTurn();
        }

        public void SetPlayerOneImageActive()
        {
            _playerOneImage.gameObject.SetActive(true);
            _playerTwoImage.gameObject.SetActive(false);
            TurnState = TurnStates.Player1;
        }
        
        public void SetPlayerTwoImageActive()
        {
            _playerOneImage.gameObject.SetActive(false);
            _playerTwoImage.gameObject.SetActive(true);
            TurnState = TurnStates.Player2;
        }
        
        public void SetPlayerImagesInactive()
        {
            _playerOneImage.gameObject.SetActive(false);
            _playerTwoImage.gameObject.SetActive(false);
            TurnState = TurnStates.None;
        }
    }
}
