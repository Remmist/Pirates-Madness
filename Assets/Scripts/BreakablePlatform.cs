using System.Collections;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    [SerializeField] private float _breakTime = 1f;


    private void OnCollisionEnter2D(Collision2D other)
    {
        StartCoroutine(Break());
    }

    private IEnumerator Break()
    {
        yield return new WaitForSeconds(_breakTime);
        Destroy(gameObject);
    }
}
