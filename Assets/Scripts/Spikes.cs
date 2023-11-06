using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spikes : MonoBehaviour
{


    [SerializeField] private float _damageTime = 0.2f;
    private List<Collision2D> objects = new List<Collision2D>();

    private bool _canDamage = true;
    [SerializeField] private float _damage = 20;


    private void Update()
    {
        if (!objects.Any())
        {
            return;
        }
        foreach (var obj in objects)
        {
            if (_canDamage)
            {
                StartCoroutine(Damage(obj));
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player") || other.collider.CompareTag("Enemy"))
        {
            objects.Add(other);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        objects.Remove(other);
    }

    private IEnumerator Damage(Collision2D obj)
    {
        _canDamage = false;
        if (obj.otherCollider.CompareTag("Player"))
        {
           obj.otherCollider.GetComponent<PlayerCharacteristics>().TakeDamage(_damage); 
        } 
        else if (obj.otherCollider.CompareTag("Enemy"))
        {
            obj.otherCollider.GetComponent<TestEnemyCharacteristics>().TakeDamage(_damage); 
        }
        yield return new WaitForSeconds(_damageTime);
        _canDamage = true;
    }
}
