using BeatSaber.Core;
using UnityEngine;
using UnityEngine.Pool;

namespace BeatSaber.Gameloop
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private bool collectionCheck = true;
        [SerializeField] private ushort capacity = 32;
        [SerializeField] private ushort maxSize = 64;
        [SerializeField] private SliceableCube prefab;
        [SerializeField] private ColorsMaterialsDict materials = new ColorsMaterialsDict();
        [SerializeField] private SpawnPoints spawnPoints = new SpawnPoints();
        
        private bool _started;
        private int _currentWallIndex;
        private LevelData _levelData;
        private IObjectPool<SliceableCube> _pool;
        private float _currentTimelinePosition;

        private void Start()
        {
            InitPool();
        }

        private void Update()
        {
            if (!_started)
                return;

            if (_currentWallIndex == _levelData.WallsLength)
                return;
            
            _currentTimelinePosition += Time.deltaTime;
            
            if (_levelData.Walls[_currentWallIndex].TimelinePosition > _currentTimelinePosition)
                return;
            
            foreach (var element in _levelData.Walls[_currentWallIndex].Elements)
                Spawn(element.Color, element.Direction, spawnPoints[element.Position].position);

            _currentWallIndex++;
        }

        public void StartLevel(LevelData level)
        {
            _levelData = level;
            _currentWallIndex = 0;
            _started = true;
        }

        #region Pool

        private void InitPool()
        {
            _pool = new ObjectPool<SliceableCube>(OnCreate, OnGet, OnRelease, OnPoolObjectDestroy, collectionCheck, capacity,
                maxSize);
        }

        private void OnPoolObjectDestroy(SliceableCube obj)
        {
            Destroy(obj.gameObject);
        }

        private void OnRelease(SliceableCube obj)
        {
            obj.gameObject.SetActive(false);
        }

        private void OnGet(SliceableCube obj)
        {
            obj.transform.position = transform.position;
            obj.gameObject.SetActive(true);
        }

        private SliceableCube OnCreate()
        {
            var instance = Instantiate(prefab);
            instance.OnCreate(_pool);
            return instance;
        }

        #endregion

        private void Spawn(CubeColor color, ArrowDirection direction, Vector3 position)
        {
            var cube = _pool.Get();
            cube.OnSpawn(direction, materials[color]);
            cube.transform.position = position;
        }
    }
}