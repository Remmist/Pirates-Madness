using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class CollectibleItem : MonoBehaviour
{

    protected abstract void CollectBehaviour();

    public abstract void UseItem();

    private void OnTriggerEnter2D(Collider2D other)
    {
        CollectBehaviour();
    }
}
