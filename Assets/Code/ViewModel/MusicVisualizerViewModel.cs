using Code.Interface;
using UnityEngine;


namespace Code.ViewModel
{
    public class MusicVisualizerViewModel : IExecute
    {
        private readonly AudioSource _musicAudioSource;
        private readonly RectTransform[] _lines;
        private readonly float[] _spectrum;
        private readonly float _powerMultiplier = 1.25f;
        private readonly float _lerpMultiplier = 0.75f;
        private readonly float _defaultSize = 1.0f;
        private readonly int _multiplier = 200;

        public MusicVisualizerViewModel(AudioSource musicAudioSource, RectTransform[] lines)
        {
            _musicAudioSource = musicAudioSource;
            _lines = lines;
            _spectrum = new float[_lines.Length];
        }

        public void Execute(float deltaTime)
        {
            _musicAudioSource.GetSpectrumData(_spectrum, 0, FFTWindow.BlackmanHarris);

            for (int i = 0; i < _spectrum.Length; i++)
            {
                var newSize = _defaultSize + 
                              Mathf.Lerp(_lines[i].localScale.x, 
                                  _spectrum[i] * _multiplier * Mathf.Pow(i, _powerMultiplier), _lerpMultiplier);
                _lines[i].SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, newSize);
            }
        }
    }
}