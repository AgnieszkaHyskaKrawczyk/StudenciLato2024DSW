using System;
using NaughtyAttributes;
using UnityEngine;

namespace BeatSaber.Gameloop
{
    public class ScoreManager : MonoBehaviour
    {
        /// <summary>
        /// bool - is correct hit?
        /// </summary>
        public static Action<bool> onCubeHit;

        public static event Action<ushort> scoreChanged; 
        public static event Action<ushort> comboChanged;

        [ShowNonSerializedField] private ushort _score;
        [ShowNonSerializedField] private ushort _currentCombo;

        private void OnEnable()
        {
            onCubeHit += OnCubeHit;
        }

        private void OnDisable()
        {
            onCubeHit -= OnCubeHit;
        }

        private void OnCubeHit(bool isCorrect)
        {
            if (isCorrect)
            {
                _currentCombo++;
                _score++;
                scoreChanged?.Invoke(_score);
                comboChanged?.Invoke(_currentCombo);
            }
            else
            {
                _currentCombo = 0;
                comboChanged?.Invoke(_currentCombo);
            }
        }
    }
}