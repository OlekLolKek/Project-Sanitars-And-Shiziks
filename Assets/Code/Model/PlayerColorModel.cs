using UnityEngine;


namespace Code.Model
{
    [CreateAssetMenu(fileName = "PlayerColor", menuName = "Data/PlayerColor")]
    public class PlayerColorModel : ScriptableObject
    {
        [SerializeField] private Color _panelColor;
        [SerializeField] private Color _imageColor;

        public Color PanelColor => _panelColor;
        public Color ImageColor => _imageColor;
    }
}