using System;
using _Scripts.Manager;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.GamePlay.Obstacles
{
    public class PipeObjectPool : MonoBehaviour
    {

        #region Pool

        [SerializeField] private byte pipeSize = 10;
        [SerializeField] private GameObject[] pipePrefab;
        private Vector2 _objectPoolPosition;
        private GameObject[] _pipes;

        #endregion

        #region Spawn

        [SerializeField] private float spawnRate = 4.0f;

        [SerializeField] private float minimumYPosition = -1.0f;
        [SerializeField] private float maximumYPosition = 3.0f;
        
        private float _spawnPipeXPosition;
        public static float SpawnPipeYPosition;
        private float _timeSinceLastSpawned = 0;
        
        private byte _currentPipe = 0;

        #endregion

        private void OnEnable()
        {
            InstantiatePool();
        }
        /*private void Start()
        {
            InstantiatePool();
        }*/

        private void InstantiatePool()
        {
            _pipes = new GameObject[pipeSize];
            for (byte i = 0; i < pipeSize;i++)
            {
                _spawnPipeXPosition += Random.Range(4.5f, 5.0f); 
                SpawnPipeYPosition = Random.Range(minimumYPosition, maximumYPosition);
                _objectPoolPosition = new Vector2(_spawnPipeXPosition, SpawnPipeYPosition);
                _pipes[i] = Instantiate(pipePrefab[i % 2], _objectPoolPosition, Quaternion.identity);
            }
        }

        private void Update()
        {
            if(GameManager.Instance.gameOver)
                return;
            SpawnItems();
        }

        private void SpawnItems()
        {
            _timeSinceLastSpawned += Time.deltaTime;
            if (GameManager.Instance.gameOver || !(_timeSinceLastSpawned >= spawnRate)) return;
            _timeSinceLastSpawned = 0;
            _spawnPipeXPosition = Random.Range(4.5f, 5.0f);
            SpawnPipeYPosition = Random.Range(minimumYPosition, maximumYPosition);
            _pipes[_currentPipe].transform.position = new Vector2(_spawnPipeXPosition, SpawnPipeYPosition);
            _currentPipe++;

            if (_currentPipe >= pipeSize)
            {
                _currentPipe = 0;
            }
        }
    }
}
