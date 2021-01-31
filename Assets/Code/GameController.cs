using System;
using Code.View;
using UnityEngine;
using UnityEngine.UI;


namespace Code
{
    [Serializable]
    public class Player
    {
        public Button Button;
        public Image Panel;
        public Text Text;
    }

    [Serializable]
    public class PlayerColor
    {
        public Color PanelColor;
        public Color TextColor;
    }
    
    public sealed class GameController : MonoBehaviour
    {
        [SerializeField] private GameObject _startInfo;
        [SerializeField] private Player _playerX;
        [SerializeField] private Player _playerO;
        [SerializeField] private PlayerColor _activePlayerColor;
        [SerializeField] private PlayerColor _inactivePlayerColor;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Text[] _buttonList;
        [SerializeField] private GameObject _gameOverPanel;
        [SerializeField] private Text _gameOverText;

        private string _playerSide;
        private int _moveCount;

        // private void Awake()
        // {
        //     SetGameControllerReferenceOnButtons();
        //     _gameOverPanel.SetActive(false);
        //     _moveCount = 0;
        //     _restartButton.gameObject.SetActive(false);
        // }

        // void SetGameControllerReferenceOnButtons()
        // {
        //     for (int i = 0; i < _buttonList.Length; i++)
        //     {
        //         _buttonList[i].GetComponentInParent<GridSpace>().InjectGameViewModel(this);
        //     }
        // }

        public string GetPlayerSide()
        {
            return _playerSide;
        }

        public void RestartGame()
        {
            _moveCount = 0;
            _gameOverPanel.SetActive(false);
            _restartButton.gameObject.SetActive(false);
            SetPlayerButtons(true);
            SetPlayerColorInactive();
            _startInfo.SetActive(true);

            for (int i = 0; i < _buttonList.Length; i++)
            {
                _buttonList[i].text = string.Empty;
            }
        }

        public void EndTurn()
        {
            _moveCount++;
            
            if (_buttonList[0].text == _playerSide &&
                _buttonList[1].text == _playerSide &&
                _buttonList[2].text == _playerSide)
            {
                GameOver(_playerSide);
            }
            
            else if (_buttonList[3].text == _playerSide &&
                     _buttonList[4].text == _playerSide &&
                _buttonList[5].text == _playerSide)
            {
                GameOver(_playerSide);
            }

            else if (_buttonList[6].text == _playerSide &&
                     _buttonList[7].text == _playerSide &&
                     _buttonList[8].text == _playerSide)
            {
                GameOver(_playerSide);
            }

            else if (_buttonList[0].text == _playerSide &&
                     _buttonList[3].text == _playerSide &&
                     _buttonList[6].text == _playerSide)
            {
                GameOver(_playerSide);
            }

            else if (_buttonList[1].text == _playerSide &&
                     _buttonList[4].text == _playerSide &&
                     _buttonList[7].text == _playerSide)
            {
                GameOver(_playerSide);
            }

            else if (_buttonList[2].text == _playerSide &&
                     _buttonList[5].text == _playerSide &&
                     _buttonList[8].text == _playerSide)
            {
                GameOver(_playerSide);
            }

            else if (_buttonList[0].text == _playerSide &&
                     _buttonList[4].text == _playerSide &&
                     _buttonList[8].text == _playerSide)
            {
                GameOver(_playerSide);
            }

            else if (_buttonList[2].text == _playerSide &&
                     _buttonList[4].text == _playerSide &&
                     _buttonList[6].text == _playerSide)
            {
                GameOver(_playerSide);
            }

            else if (_moveCount >= 9)
            {
                GameOver("draw");
            }

            else
            {
                ChangeSides();
            }
        }

        private void ChangeSides()
        {
            _playerSide = _playerSide == "X" ? "O" : "X";
            if (_playerSide == "X")
            {
                SetPlayerColors(_playerX, _playerO);
            }
            else
            {
                SetPlayerColors(_playerO, _playerX);
            }
        }
        
        private void GameOver(string winningPlayer)
        {
            SetBoardInteractable(false);
            
            if (winningPlayer == "draw")
            {
                SetGameOverText("It's a draw!");
                SetPlayerColorInactive();
            }
            else
            {
                SetGameOverText($"{winningPlayer} wins!");
            }
            
            _restartButton.gameObject.SetActive(true);
        }

        private void SetGameOverText(string value)
        {
            _gameOverPanel.SetActive(true);
            _gameOverText.text = value;
        }

        private void SetBoardInteractable(bool toggle)
        {
            for (int i = 0; i < _buttonList.Length; i++)
            {
                _buttonList[i].GetComponentInParent<Button>().interactable = toggle;
            }
        }

        private void SetPlayerColors(Player newPlayer, Player oldPlayer)
        {
            newPlayer.Panel.color = _activePlayerColor.PanelColor;
            newPlayer.Text.color = _activePlayerColor.TextColor;
            oldPlayer.Panel.color = _inactivePlayerColor.PanelColor;
            oldPlayer.Text.color = _inactivePlayerColor.TextColor;
        }

        public void SetStartingSide(string startingSide)
        {
            _playerSide = startingSide;
            if (_playerSide == "X")
            {
                SetPlayerColors(_playerX, _playerO);
            }
            else
            {
                SetPlayerColors(_playerO, _playerX);
            }

            StartGame();
        }

        private void StartGame()
        {
            SetBoardInteractable(true);
            SetPlayerButtons(false);
            _startInfo.SetActive(false);
        }

        private void SetPlayerButtons(bool toggle)
        {
            _playerX.Button.interactable = toggle;
            _playerO.Button.interactable = toggle;
        }

        private void SetPlayerColorInactive()
        {
            _playerX.Panel.color = _inactivePlayerColor.PanelColor;
            _playerX.Text.color = _inactivePlayerColor.TextColor;
            _playerO.Panel.color = _inactivePlayerColor.PanelColor;
            _playerO.Text.color = _inactivePlayerColor.TextColor;
        }
    }
}
