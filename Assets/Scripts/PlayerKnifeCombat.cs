using UnityEngine;

public class PlayerKnifeCombat : MonoBehaviour
{
    //Variables for how the projectiles act when shoot by the player
    [SerializeField] private GameObject _playerProjectilePrefab;
    [SerializeField] private Transform _launchOffSet;
    [SerializeField] private float _shootSpeed = 10f;

    private void Update()
    {
        
        Vector2 shootingDirection = transform.right;

        if (transform.localScale.x < 0) // If the character faces left
        {
            shootingDirection = -transform.right; //change the direction of thrown projectiles to left
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GameObject projectile = Instantiate(_playerProjectilePrefab, _launchOffSet.position, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            
            rb.velocity = shootingDirection * _shootSpeed;
        }
    }
}
