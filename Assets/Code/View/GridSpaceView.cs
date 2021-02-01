using Code.Enum;
using Code.ViewModel;
using UnityEngine;
using UnityEngine.UI;


namespace Code.View
{
    public sealed class GridSpaceView : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Image _playerOneImage;
        [SerializeField] private Image _playerTwoImage;

        public TurnStates TurnState { get; private set; }
        public Button Button => _button;

        private GridSpaceViewModel _gridSpaceViewModel;

        public void Initialize(GridSpaceViewModel gridSpaceViewModel)
        {
            _gridSpaceViewModel = gridSpaceViewModel;
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(() => _gridSpaceViewModel.SetSpace(this));
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