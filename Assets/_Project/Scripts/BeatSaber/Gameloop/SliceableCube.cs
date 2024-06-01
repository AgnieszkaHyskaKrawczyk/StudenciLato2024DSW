using BeatSaber.Core;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Pool;

namespace BeatSaber.Gameloop
{
    public class SliceableCube : MonoBehaviour, IPooledObject
    {
        [SerializeField] private ArrowPositions positions = new ArrowPositions();
        
        [ShowNonSerializedField] private CubeColor _cubeColor;
        [ShowNonSerializedField] private ArrowDirection _type;

        private ArrowDirection _currentDirection;
        private MeshRenderer _renderer;
        private IObjectPool<SliceableCube> _pool;

        private void Awake() => _renderer = GetComponent<MeshRenderer>();
        
        private void OnDisable() => positions[_currentDirection].SetActive(false);
        
        public void OnCreate(IObjectPool<SliceableCube> pool) => _pool = pool;
        
        public void Release() => _pool.Release(this);

        public void OnSpawn(ArrowDirection direction, Material material)
        {
            _renderer.material = material;
            positions[direction].SetActive(true);
            _currentDirection = direction;
        }
    }
}