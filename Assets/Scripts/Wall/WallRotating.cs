using UnityEngine;
using DG.Tweening;

public class WallRotating : MonoBehaviour
{
    [SerializeField] private float _rotationTime;
    
    void Start()
    {
        RotateWall(_rotationTime);  
    }

    private void RotateWall(float rotationTime)
    {
        transform.DORotate(new Vector3(0, 360, 0), rotationTime, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo);
    }
}
