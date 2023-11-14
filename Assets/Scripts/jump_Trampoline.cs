using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private float bounceForce = 25f;
    [SerializeField] private float trampolineRadius = 2.5f; 

    private Animator trampolineAnimator;

    private void Start()
    {
        // Получаем компонент Animator у трамплина
        trampolineAnimator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 trampolineCenter = transform.position;
            Vector2 playerPosition = collision.transform.position;

          //czy znajduje sie player w radius
            if (Vector2.Distance(playerPosition, trampolineCenter) <= trampolineRadius)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
                
                trampolineAnimator.SetTrigger("BounceTrigger");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Рисуем гизмос для отображения радиуса трамплина в редакторе
        Gizmos.DrawWireSphere(transform.position, trampolineRadius);
    }
}