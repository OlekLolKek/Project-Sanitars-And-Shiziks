using UnityEngine;
using UnityEngine.UI;


namespace Code.View
{
    public sealed class StartInfoView : MonoBehaviour
    {
        [SerializeField] private Text _text;

        public Text Text => _text;
    }
}