using System;
using UnityEngine;

public class BlockView : MonoBehaviour
{
    public Vector3 OriginPosition { get; private set; }
    public int CubesCount { get; private set; }

    public event Action Dropped;
    public event Action<BlockView, Vector3> OnPlatformPut;
    public event Action PlatformIsFull;
    public void Init(int cubesCount, Vector3 originPosition)
    {
        CubesCount = cubesCount;
        OriginPosition = originPosition;
    }

    public void Drop()
    {
        Dropped?.Invoke();
        OnPlatformPut?.Invoke(this, OriginPosition);
    }     

    public void DropToOriginPosition() => transform.position = OriginPosition;

    public void RemoveFromPlatform() => PlatformIsFull?.Invoke();
    
    public void Destroy() => Destroy(gameObject);

}
