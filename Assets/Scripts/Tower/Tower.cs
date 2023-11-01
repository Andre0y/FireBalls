using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    [SerializeField] private float _rotateAngle;
    [SerializeField] private ParticleSystem _blockDestroyEffect;
    
    private TowerBuilder _towerBuilder;
    private List<Block> _blocks;
    private Vector3 _rotateVector;

    public UnityAction<int> towerSizeUpdated;

    private void Start()
    {
        _rotateVector = new Vector3(0, Random.Range(-2, 2), 0);

        _towerBuilder = GetComponent<TowerBuilder>();

        _blocks = _towerBuilder.Build();

        foreach (Block block in _blocks)
        {
            block.BulletHit += OnBulletHit;
        }

        towerSizeUpdated?.Invoke(_blocks.Count);
    }

    private void Update()
    {
        RotateBlocks(_rotateVector, _rotateAngle);
    }

    private void OnBulletHit(Block hittedBlock)
    {
        hittedBlock.BulletHit -= OnBulletHit;
        SpawnBlockDestroyEffect(hittedBlock);

        _blocks.Remove(hittedBlock);
        Destroy(hittedBlock.gameObject);

        foreach (Block block in _blocks)
        {
            block.transform.position = new Vector3(block.transform.position.x,
                block.transform.position.y - block.transform.localScale.y,
                block.transform.position.z);
        }

        towerSizeUpdated?.Invoke(_blocks.Count);
    }

    private void RotateBlocks(Vector3 rotateVector, float rotateAngle) 
    {
        foreach (Block block in _blocks)
        {
            block.transform.Rotate(rotateVector, rotateAngle);
        }
    }

    private void SpawnBlockDestroyEffect(Block destroyedBlock)
    {
        ParticleSystemRenderer particleSystemRenderer = Instantiate(_blockDestroyEffect, destroyedBlock.transform.position, _blockDestroyEffect.transform.rotation).GetComponent<ParticleSystemRenderer>();
        particleSystemRenderer.material.color = destroyedBlock.GetComponent<MeshRenderer>().material.color;
    }
}