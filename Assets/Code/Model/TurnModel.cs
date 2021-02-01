using Code.Enum;


namespace Code.Model
{
    public class TurnModel
    {
        public TurnStates PlayerSide { get; set; }
        public int TurnCount { get; set; }
    }
}