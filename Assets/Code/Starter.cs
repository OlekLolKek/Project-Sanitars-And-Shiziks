using System;
using Code.Model;
using Code.View;
using Code.ViewModel;
using Mirror;
using UnityEngine;


namespace Code
{
    public class Starter : NetworkManager
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
        private NetworkViewModel _networkViewModel;

        public override void Start()
        {
            var monoBehavioursModel = new MonoBehavioursModel(_gridSpaces, _gameOverPanel,
                _restartButton, _startInfo,
                _playerOne, _playerTwo);
            
            _gameViewModel = new GameViewModel(_inactivePlayerColors,
                _activePlayerColors, _stringsModel,
                monoBehavioursModel);

            _musicVisualizerViewModel = new MusicVisualizerViewModel(_musicAudioSource, _lines);

            _networkViewModel = new NetworkViewModel(_gridSpaces);

            _gameViewModel.Initialize();
            
            //CmdDebugLog();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _musicVisualizerViewModel.Execute(deltaTime);
        }

        public override void OnClientConnect(NetworkConnection conn)
        {
            //base.OnClientConnect(conn);
            //CmdDebugLog();
            //_networkViewModel.OnClientConnect(conn);
        }

        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            
        }

        // [Command]
        // private void CmdDebugLog()
        // {
        //     RpcDebugLog();
        // }
        //
        // [ClientRpc]
        // private void RpcDebugLog()
        // {
        //     Debug.Log("test");
        // }
    }
}