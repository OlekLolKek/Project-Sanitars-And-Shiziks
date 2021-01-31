using UnityEngine;


namespace Code.Model
{
    [CreateAssetMenu(fileName = "Strings", menuName = "Data/Strings", order = 0)]
    public class StringsModel : ScriptableObject
    {
        [SerializeField] private string _playerOneName;
        [SerializeField] private string _playerTwoName;
        [SerializeField] private string _winningText;
        [SerializeField] private string _drawText;

        public string PlayerOneName => _playerOneName;
        public string PlayerTwoName => _playerTwoName;
        public string WinningText => _winningText;
        public string DrawText => _drawText;
    }
}