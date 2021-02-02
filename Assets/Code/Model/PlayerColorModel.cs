using UnityEngine;


namespace Code.Model
{
    [CreateAssetMenu(fileName = "PlayerColor", menuName = "Data/PlayerColor")]
    public class PlayerColorModel : ScriptableObject
    {
        [SerializeField] private Color _panelColor;

        public Color PanelColor => _panelColor;
    }
}