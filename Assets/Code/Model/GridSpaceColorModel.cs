using UnityEngine;


namespace Code.Model
{
    [CreateAssetMenu(fileName = "GridSpaceColors", menuName = "Data/GridSpaceColors")]
    public class GridSpaceColorModel : ScriptableObject
    {
        [SerializeField] private Color _inactiveMaskColor;
        [SerializeField] private Color _activeMaskColor;

        public Color InactiveMaskColor => _inactiveMaskColor;
        public Color ActiveMaskColor => _activeMaskColor;
    }
}