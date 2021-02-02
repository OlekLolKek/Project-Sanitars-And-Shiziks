using System;
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
        [SerializeField] private AudioSource _musicAudioSource;
        [SerializeField] private RectTransform[] _lines;
        
        private IGameViewModel _gameViewModel;
        private MusicVisualizerViewModel _musicVisualizerViewModel;

        private void Start()
        {
            var monoBehavioursModel = new MonoBehavioursModel(_gridSpaces, _gameOverPanel,
                _restartButton, _startInfo,
                _playerOne, _playerTwo);
            
            _gameViewModel = new GameViewModel(_inactivePlayerColors,
                _activePlayerColors, _stringsModel,
                monoBehavioursModel);

            _musicVisualizerViewModel = new MusicVisualizerViewModel(_musicAudioSource, _lines);

            _gameViewModel.Initialize();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _musicVisualizerViewModel.Execute(deltaTime);
        }
    }
}