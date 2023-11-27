using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" || other.tag == "Enemy")
        {
            if (other.tag == "Player")
            {
                other.GetComponent<PlayerCharacteristics>().TakeDamage(1000000);
            }
            else
            {
                other.GetComponent<TestEnemyCharacteristics>().TakeDamage(1000000);
            }
        }
    }
}
