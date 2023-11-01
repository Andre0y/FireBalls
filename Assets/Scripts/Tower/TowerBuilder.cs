using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private Color[] _colors;
    
    [SerializeField] private Block _block;
    [SerializeField] private Transform _startSpawnPoint;
    [SerializeField] private ushort _maxBlocksCount;
    [SerializeField] private ushort _minBlocksCount;

    private int _countOfBlocks;

    private Vector3 _spawnPosition;

    private void Awake()
    {
        _countOfBlocks = Random.Range(_minBlocksCount, _maxBlocksCount);
    }

    private void Start()
    {
        _spawnPosition = _startSpawnPoint.transform.position;
    }

    public List<Block> Build()
    {
        List<Block> blocks = new List<Block>();

        for (int i = 0; i < _countOfBlocks; i++)
        {
            Block newBlock = BuildBlock();
            newBlock.GetComponent<MeshRenderer>().material.color = _colors[Random.Range(0, _colors.Length)];
            
            blocks.Add(newBlock);
            _startSpawnPoint = newBlock.transform;
        }

        return blocks;
    }

    private Block BuildBlock()
    {
        _spawnPosition.y += _block.transform.localScale.y / 2f + _startSpawnPoint.transform.localScale.y / 2f;        

        Block newBlock = Instantiate(_block, _spawnPosition, Quaternion.identity, transform);
        
        return newBlock;
    }
}
