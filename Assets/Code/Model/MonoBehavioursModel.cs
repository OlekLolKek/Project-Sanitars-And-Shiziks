using Code.View;


namespace Code.Model
{
    public class MonoBehavioursModel
    {
        public GridSpaceView[] GridSpaces { get; }
        public GameOverPanelView GameOverPanel { get; }
        public RestartButtonView RestartButton { get; }
        public StartInfoView StartInfo { get; }
        public PlayerTurnPanelView PlayerOne { get; }
        public PlayerTurnPanelView PlayerTwo { get; }

        public MonoBehavioursModel(GridSpaceView[] gridSpaces, GameOverPanelView gameOverPanel, 
            RestartButtonView restartButton, StartInfoView startInfo,
            PlayerTurnPanelView playerOne, PlayerTurnPanelView playerTwo)
        {
            GridSpaces = gridSpaces;
            GameOverPanel = gameOverPanel;
            RestartButton = restartButton;
            StartInfo = startInfo;
            PlayerOne = playerOne;
            PlayerTwo = playerTwo;
        }
    }
}