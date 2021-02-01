using Code.Enum;
using Code.Interface;
using Code.Model;
using Code.View;
using UnityEngine;


namespace Code.ViewModel
{
    public class GameViewModel : IGameViewModel
    {
        private readonly PlayerColorModel _inactivePlayerColors;
        private readonly PlayerColorModel _activePlayerColors;
        private readonly StringsModel _strings;
        private readonly TurnModel _turnModel;
        
        private readonly GameOverPanelView _gameOverPanel;
        private readonly RestartButtonView _restartButton;
        private readonly StartInfoView _startInfo;
        private readonly PlayerTurnPanelView _playerOne;
        private readonly PlayerTurnPanelView _playerTwo;
        
        private readonly GridSpaceViewModel _gridSpaceViewModel;

        public GameViewModel(PlayerColorModel inactivePlayerColors, 
            PlayerColorModel activePlayerColors, StringsModel strings,
            MonoBehavioursModel _monoBehavioursModel)
        {
            _turnModel = new TurnModel();
            _gridSpaceViewModel = new GridSpaceViewModel(this, _turnModel,
                _monoBehavioursModel);
            
            _gameOverPanel = _monoBehavioursModel.GameOverPanel;
            _restartButton = _monoBehavioursModel.RestartButton;
            _startInfo = _monoBehavioursModel.StartInfo;
            _playerOne = _monoBehavioursModel.PlayerOne;
            _playerTwo = _monoBehavioursModel.PlayerTwo;
            
            _inactivePlayerColors = inactivePlayerColors;
            _activePlayerColors = activePlayerColors;
            _strings = strings;
        }

        public void Initialize()
        {
            _gridSpaceViewModel.Initialize();
            
            _playerOne.Initialize(this);
            _playerTwo.Initialize(this);
            _restartButton.Initialize(this);

            _gameOverPanel.gameObject.SetActive(false);
            _restartButton.gameObject.SetActive(false);
            _startInfo.Text.text = $"{_strings.PlayerOneName} or {_strings.PlayerTwoName}?\nChoose the side!";
        }

        public void RestartGame()
        {
            _gameOverPanel.gameObject.SetActive(false);
            _restartButton.gameObject.SetActive(false);
            _startInfo.gameObject.SetActive(true);
            SetPlayerButtons(true);
            SetPlayerColorInactive();

            _gridSpaceViewModel.SetPlayerImagesInactive();
            
            _playerOne.Panel.color = _activePlayerColors.PanelColor;
            _playerOne.Image.color = _activePlayerColors.ImageColor;
            _playerTwo.Panel.color = _activePlayerColors.PanelColor;
            _playerTwo.Image.color = _activePlayerColors.ImageColor;
        }

        public void ChangeSides()
        {
            if (_turnModel.PlayerSide == TurnStates.Player1)
            {
                _turnModel.PlayerSide = TurnStates.Player2;
                SetPlayerColors(_playerTwo, _playerOne);
            }
            else
            {
                _turnModel.PlayerSide = TurnStates.Player1;
                SetPlayerColors(_playerOne, _playerTwo);
            }
        }

        public void GameOver(TurnStates winningPlayer)
        {
            _gridSpaceViewModel.SetBoardInteractable(false);

            if (winningPlayer == TurnStates.None)
            {
                SetGameOverText(_strings.DrawText);
                SetPlayerColorInactive();
            }
            else if (winningPlayer == TurnStates.Player1)
            {
                SetGameOverText(_strings.PlayerOneName + _strings.WinningText);
            }
            else
            {
                SetGameOverText(_strings.PlayerTwoName + _strings.WinningText);
            }

            _restartButton.gameObject.SetActive(true);
        }

        private void SetGameOverText(string value)
        {
            _gameOverPanel.gameObject.SetActive(true);
            _gameOverPanel.Text.text = value;
        }

        private void SetPlayerColors(PlayerTurnPanelView newPlayer, 
            PlayerTurnPanelView oldPlayer)
        {
            newPlayer.Panel.color = _activePlayerColors.PanelColor;
            newPlayer.Image.color = _activePlayerColors.ImageColor;
            oldPlayer.Panel.color = _inactivePlayerColors.PanelColor;
            oldPlayer.Image.color = _inactivePlayerColors.ImageColor;
        }
        
        public void SetStartingSide(TurnStates startingSide)
        {
            _turnModel.PlayerSide = startingSide;
            if (_turnModel.PlayerSide == TurnStates.Player1)
            {
                SetPlayerColors(_playerOne, _playerTwo);
            }
            else
            {
                SetPlayerColors(_playerTwo, _playerOne);
            }

            StartGame();
        }

        private void StartGame()
        {
            _gridSpaceViewModel.SetBoardInteractable(true);
            SetPlayerButtons(false);
            _startInfo.gameObject.SetActive(false);
        }

        private void SetPlayerButtons(bool toggle)
        {
            _playerOne.Button.interactable = toggle;
            _playerTwo.Button.interactable = toggle;
        }

        private void SetPlayerColorInactive()
        {
            _playerOne.Panel.color = _inactivePlayerColors.PanelColor;
            _playerOne.Image.color = _inactivePlayerColors.ImageColor;
            _playerTwo.Panel.color = _inactivePlayerColors.PanelColor;
            _playerTwo.Image.color = _inactivePlayerColors.ImageColor;
        }
    }
}