using UnityEngine;

namespace BeatSaber.Gameloop
{
    [CreateAssetMenu(fileName = "New Level Data", menuName = "xDSW/BeatSaber", order = 0)]
    public class LevelData : ScriptableObject
    {
        [field:SerializeField] public AudioClip Clip { get; private set; }
        [field: SerializeField] public AnimationCurve MovementCurve { get; private set; }
        [field: SerializeField] public float Speed { get; private set; }
        [field: SerializeField] public Wall[] Walls { get; private set; }

        public int WallsLength { get; private set; }
        
        private void OnEnable()
        {
            WallsLength = Walls.Length;
        }
    }
}