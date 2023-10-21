using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private Block _block;
    [SerializeField] private int _countOfTowers;
    [SerializeField] private Transform _startSpawnPoint;

    private Vector3 _spawnPosition;

    private void Start()
    {
        _spawnPosition = _startSpawnPoint.transform.position;
    }

    public List<Block> Build()
    {
        List<Block> blocks = new List<Block>();

        for (int i = 0; i < _countOfTowers; i++)
        {
            Block newBlock = BuildBlock();
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
