using Code.Enum;
using Code.Interface;
using Code.Model;
using Code.View;


namespace Code.ViewModel
{
    public class GameViewModel : IGameViewModel
    {
        private readonly GridSpaceView[] _gridSpaces;

        private readonly PlayerColorModel _inactivePlayerColors;
        private readonly PlayerColorModel _activePlayerColors;
        private readonly StringsModel _strings;
        private readonly GameOverPanelView _gameOverPanel;
        private readonly RestartButtonView _restartButton;
        private readonly StartInfoView _startInfo;
        private readonly PlayerTurnPanelView _playerOne;
        private readonly PlayerTurnPanelView _playerTwo;
        

        private TurnStates _playerSide;
        private int _turnCount;

        public GameViewModel(GridSpaceView[] gridSpaces, GameOverPanelView gameOverPanel,
            RestartButtonView restartButton, StartInfoView startInfo,
            PlayerColorModel inactivePlayerColors, PlayerColorModel activePlayerColors,
            StringsModel strings, PlayerTurnPanelView playerOne,
            PlayerTurnPanelView playerTwo)
        {
            _gridSpaces = gridSpaces;
            _gameOverPanel = gameOverPanel;
            _restartButton = restartButton;
            _startInfo = startInfo;
            _inactivePlayerColors = inactivePlayerColors;
            _activePlayerColors = activePlayerColors;
            _strings = strings;
            _playerOne = playerOne;
            _playerTwo = playerTwo;
            
            _playerOne.Initialize(this);
            _playerTwo.Initialize(this);
            _restartButton.Initialize(this);
        }

        public void Initialize()
        {
            foreach (var gridSpace in _gridSpaces)
            {
                gridSpace.Initialize(this);
            }

            _gameOverPanel.gameObject.SetActive(false);
            _restartButton.gameObject.SetActive(false);
        }

        public void SetSpace(GridSpaceView gridSpace)
        {
            if (_playerSide == TurnStates.Player1)
            {
                gridSpace.SetPlayerOneImageActive();
            }
            else
            {
                gridSpace.SetPlayerTwoImageActive();
            }
            
            gridSpace.Button.interactable = false;
            EndTurn();
        }

        public void RestartGame()
        {
            _turnCount = 0;
            _gameOverPanel.gameObject.SetActive(false);
            _restartButton.gameObject.SetActive(false);
            _startInfo.gameObject.SetActive(true);
            SetPlayerButtons(true);
            SetPlayerColorInactive();

            foreach (var gridSpace in _gridSpaces)
            {
                gridSpace.SetPlayerImagesInactive();
            }
        }

        public void EndTurn()
        {
            _turnCount++;
            
            if (_gridSpaces[0].TurnState == _playerSide &&
                _gridSpaces[1].TurnState == _playerSide &&
                _gridSpaces[2].TurnState == _playerSide)
            {
                GameOver(_playerSide);
            }
            
            else if (_gridSpaces[3].TurnState == _playerSide &&
                     _gridSpaces[4].TurnState == _playerSide &&
                     _gridSpaces[5].TurnState == _playerSide)
            {
                GameOver(_playerSide);
            }

            else if (_gridSpaces[6].TurnState == _playerSide &&
                     _gridSpaces[7].TurnState == _playerSide &&
                     _gridSpaces[8].TurnState == _playerSide)
            {
                GameOver(_playerSide);
            }

            else if (_gridSpaces[0].TurnState == _playerSide &&
                     _gridSpaces[3].TurnState == _playerSide &&
                     _gridSpaces[6].TurnState == _playerSide)
            {
                GameOver(_playerSide);
            }

            else if (_gridSpaces[1].TurnState == _playerSide &&
                     _gridSpaces[4].TurnState == _playerSide &&
                     _gridSpaces[7].TurnState == _playerSide)
            {
                GameOver(_playerSide);
            }

            else if (_gridSpaces[2].TurnState == _playerSide &&
                     _gridSpaces[5].TurnState == _playerSide &&
                     _gridSpaces[8].TurnState == _playerSide)
            {
                GameOver(_playerSide);
            }

            else if (_gridSpaces[0].TurnState == _playerSide &&
                     _gridSpaces[4].TurnState == _playerSide &&
                     _gridSpaces[8].TurnState == _playerSide)
            {
                GameOver(_playerSide);
            }

            else if (_gridSpaces[2].TurnState == _playerSide &&
                     _gridSpaces[4].TurnState == _playerSide &&
                     _gridSpaces[6].TurnState == _playerSide)
            {
                GameOver(_playerSide);
            }

            else if (_turnCount >= 9)
            {
                GameOver(TurnStates.None);
            }

            else
            {
                ChangeSides();
            }
        }

        private void ChangeSides()
        {
            if (_playerSide == TurnStates.Player1)
            {
                _playerSide = TurnStates.Player2;
                SetPlayerColors(_playerTwo, _playerOne);
            }
            else
            {
                _playerSide = TurnStates.Player1;
                SetPlayerColors(_playerOne, _playerTwo);
            }
        }

        private void GameOver(TurnStates winningPlayer)
        {
            SetBoardInteractable(false);

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

        private void SetBoardInteractable(bool toggle)
        {
            foreach (var gridSpace in _gridSpaces)
            {
                gridSpace.Button.interactable = toggle;
            }
        }

        private void SetPlayerColors(PlayerTurnPanelView newPlayer, 
            PlayerTurnPanelView oldPlayer)
        {
            newPlayer.Panel.color = _activePlayerColors.PanelColor;
            newPlayer.Image.color = _activePlayerColors.ImageColor;
            oldPlayer.Panel.color = _inactivePlayerColors.PanelColor;
            newPlayer.Image.color = _activePlayerColors.ImageColor;
        }
        
        public void SetStartingSide(TurnStates startingSide)
        {
            _playerSide = startingSide;
            if (_playerSide == TurnStates.Player1)
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
            SetBoardInteractable(true);
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