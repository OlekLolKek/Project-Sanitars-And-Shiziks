using Code.Enum;
using Code.Model;
using Code.View;


namespace Code.ViewModel
{
    public sealed class GridSpaceViewModel
    {
        private readonly TurnModel _turnModel;
        private readonly GameViewModel _gameViewModel;
        private readonly MonoBehavioursModel _monoBehavioursModel;


        public GridSpaceViewModel(GameViewModel gameViewModel, TurnModel turnModel,
            MonoBehavioursModel monoBehavioursModel)
        {
            _gameViewModel = gameViewModel;
            _turnModel = turnModel;
            _monoBehavioursModel = monoBehavioursModel;
        }

        public void Initialize()
        {
            foreach (var gridSpace in _monoBehavioursModel.GridSpaces)
            {
                gridSpace.Initialize(this);
            }
        }

        public void SetPlayerImagesInactive()
        {
            foreach (var gridSpace in _monoBehavioursModel.GridSpaces)
            {
                gridSpace.SetPlayerImagesInactive();
            }
        }

        public void SetBoardInteractable(bool toggle)
        {
            foreach (var gridSpace in _monoBehavioursModel.GridSpaces)
            {
                gridSpace.Button.interactable = toggle;
            }
        }

        private void CheckGridSpacesForWins()
        {
            _turnModel.TurnCount++;
            var gridSpaces = _monoBehavioursModel.GridSpaces;
            var playerSide = _turnModel.PlayerSide;
            
            if (gridSpaces[0].TurnState == playerSide &&
                gridSpaces[1].TurnState == playerSide &&
                gridSpaces[2].TurnState == playerSide)
            {
                _gameViewModel.GameOver(playerSide);
            }
            
            else if (gridSpaces[3].TurnState == playerSide &&
                     gridSpaces[4].TurnState == playerSide &&
                     gridSpaces[5].TurnState == playerSide)
            {
                _gameViewModel.GameOver(playerSide);
            }

            else if (gridSpaces[6].TurnState == playerSide &&
                     gridSpaces[7].TurnState == playerSide &&
                     gridSpaces[8].TurnState == playerSide)
            {
                _gameViewModel.GameOver(playerSide);
            }

            else if (gridSpaces[0].TurnState == playerSide &&
                     gridSpaces[3].TurnState == playerSide &&
                     gridSpaces[6].TurnState == playerSide)
            {
                _gameViewModel.GameOver(playerSide);
            }

            else if (gridSpaces[1].TurnState == playerSide &&
                     gridSpaces[4].TurnState == playerSide &&
                     gridSpaces[7].TurnState == playerSide)
            {
                _gameViewModel.GameOver(playerSide);
            }

            else if (gridSpaces[2].TurnState == playerSide &&
                     gridSpaces[5].TurnState == playerSide &&
                     gridSpaces[8].TurnState == playerSide)
            {
                _gameViewModel.GameOver(playerSide);
            }

            else if (gridSpaces[0].TurnState == playerSide &&
                     gridSpaces[4].TurnState == playerSide &&
                     gridSpaces[8].TurnState == playerSide)
            {
                _gameViewModel.GameOver(playerSide);
            }

            else if (gridSpaces[2].TurnState == playerSide &&
                     gridSpaces[4].TurnState == playerSide &&
                     gridSpaces[6].TurnState == playerSide)
            {
                _gameViewModel.GameOver(playerSide);
            }

            else if (_turnModel.TurnCount >= 9)
            {
                _gameViewModel.GameOver(TurnStates.None);
            }

            else
            {
                _gameViewModel.ChangeSides();
            }
        }
        
        public void SetSpace(GridSpaceView gridSpace)
        {
            if (_turnModel.PlayerSide == TurnStates.Player1)
            {
                gridSpace.SetPlayerOneImageActive();
            }
            else
            {
                gridSpace.SetPlayerTwoImageActive();
            }

            gridSpace.Button.interactable = false;
            CheckGridSpacesForWins();
        }
    }
}