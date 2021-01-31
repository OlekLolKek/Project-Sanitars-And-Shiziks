using Code.Enum;
using Code.View;


namespace Code.ViewModel
{
    public interface IGameViewModel
    {
        void Initialize();
        void RestartGame();
        void SetStartingSide(TurnStates player);
        void SetSpace(GridSpaceView gridSpace);
    }
}