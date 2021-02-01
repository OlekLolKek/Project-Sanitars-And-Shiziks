using Code.Model;
using Code.View;
using Code.ViewModel;
using UnityEngine;


namespace Code
{
    public class Starter : MonoBehaviour
    {
        [SerializeField] private PlayerColorModel _inactivePlayerColors;
        [SerializeField] private PlayerColorModel _activePlayerColors;
        [SerializeField] private StringsModel _stringsModel;
        [SerializeField] private PlayerTurnPanelView _playerOne;
        [SerializeField] private PlayerTurnPanelView _playerTwo;
        [SerializeField] private GameOverPanelView _gameOverPanel;
        [SerializeField] private RestartButtonView _restartButton;
        [SerializeField] private StartInfoView _startInfo;
        [SerializeField] private GridSpaceView[] _gridSpaces;
        private IGameViewModel _gameViewModel;

        private void Start()
        {
            var monoBehavioursModel = new MonoBehavioursModel(_gridSpaces, _gameOverPanel,
                _restartButton, _startInfo,
                _playerOne, _playerTwo);
            
            _gameViewModel = new GameViewModel(_inactivePlayerColors,
                _activePlayerColors, _stringsModel,
                monoBehavioursModel);

            _gameViewModel.Initialize();
        }
    }
}