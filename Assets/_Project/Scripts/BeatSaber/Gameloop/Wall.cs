using BeatSaber.Core;
using UnityEngine;

namespace BeatSaber.Gameloop
{
    [System.Serializable]
    public class Wall
    {
        [System.Serializable]
        public struct Element
        {
            [field: SerializeField] public GridPosition Position { get; private set; }
            [field: SerializeField] public CubeColor Color { get; private set; }
            [field: SerializeField] public ArrowDirection Direction { get; private set; }
        }
        [field: SerializeField] public float TimelinePosition { get; private set; }
        [field:SerializeField] public Element[] Elements { get; private set; }
    }
}