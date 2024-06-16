using BeatSaber.Core;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Pool;
using Vector3 = UnityEngine.Vector3;

namespace BeatSaber.Gameloop
{
    public class SliceableCube : MonoBehaviour, IPooledObject
    {
        [SerializeField] private ArrowPositions positions = new ArrowPositions();
        
        [ShowNonSerializedField] private CubeColor _cubeColor;
        [ShowNonSerializedField] private ArrowDirection _type;

        private bool _isMoving;
        private Vector3 _start;
        private Vector3 _end;
        private ArrowDirection _currentDirection;
        private MeshRenderer _renderer;
        private IObjectPool<SliceableCube> _pool;
        private AnimationCurve _curve;
        private float _speed;

        private void Awake() => _renderer = GetComponent<MeshRenderer>();
        
        private void OnDisable() => positions[_currentDirection].SetActive(false);

        private void Update()
        {
            if (_isMoving)
                Move();
        }

        public void OnCreate(IObjectPool<SliceableCube> pool, AnimationCurve curve, float speed, Vector3 start, Vector3 end)
        {
            _pool = pool;
            _curve = curve;
            _speed = speed;
            _start = start;
            _end = end;
        }

        public void Release(CubeColor color)
        {
            _isMoving = false;
            ScoreManager.onCubeHit?.Invoke(color == _cubeColor);
            _pool.Release(this);
        }

        public void OnSpawn(ArrowDirection direction, Material material)
        {
            _renderer.material = material;
            positions[direction].SetActive(true);
            _currentDirection = direction;
            _isMoving = true;
        }
        
        private void Move()
        {
            var pos = transform.position;
            var speed = _end.z < pos.z ? _speed : _curve.Evaluate(pos.z / _end.z) * _speed;
            transform.position = new Vector3(pos.x, pos.y, pos.z + speed * Time.deltaTime);
        }
    }
}