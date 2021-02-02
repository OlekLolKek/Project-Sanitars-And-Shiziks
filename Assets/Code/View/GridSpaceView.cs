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

        public void SetPlayerImagesActive(TurnStates states)
        {
            TurnState = states;
            if (states == TurnStates.None)
            {
                _playerOneImage.gameObject.SetActive(false);
                _playerTwoImage.gameObject.SetActive(false);
            }
            else if (states == TurnStates.Player1)
            {
                _playerOneImage.gameObject.SetActive(true);
                _playerTwoImage.gameObject.SetActive(false);
            }
            else
            {
                _playerOneImage.gameObject.SetActive(false);
                _playerTwoImage.gameObject.SetActive(true);
            }
        }
    }
}