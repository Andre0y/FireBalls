using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    private TowerBuilder _towerBuilder;
    private List<Block> _blocks;

    private Vector3 _rotateVector;

    private void Start()
    {
        _rotateVector = new Vector3(0, Random.Range(-2, 2), 0);

        _towerBuilder = GetComponent<TowerBuilder>();

        _blocks = _towerBuilder.Build();

        foreach (Block block in _blocks)
        {
            block.BulletHit += OnBulletHit;
        }
    }

    private void Update()
    {
        RotateBlocks(_rotateVector);
    }

    private void OnBulletHit(Block hittedBlock)
    {
        hittedBlock.BulletHit -= OnBulletHit;

        _blocks.Remove(hittedBlock);
        Destroy(hittedBlock.gameObject);

        foreach (Block block in _blocks)
        {
            block.transform.position = new Vector3(block.transform.position.x,
                block.transform.position.y - block.transform.localScale.y,
                block.transform.position.z);
        }
    }

    private void RotateBlocks(Vector3 rotateVector)
    {
        foreach (Block block in _blocks)
        {
            block.transform.Rotate(rotateVector, 0.3f);
        }
    }
}