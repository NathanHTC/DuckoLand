using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MyProjectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;


    // Start is called before the first frame update
    //awake is called when projectile is initialized, before start()
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //if projectile miss, when its certain distance away from origin, destroy it
        if (transform.position.magnitude > 100.0f)
        {
            // Destroy(gameObject);
            PoolManager.Instance.ReleaseProjectile(gameObject);
        }
    }

    //controls how projectiles moves
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //if collides with a enemy, fix it
        EnemyController enemyScript = other.collider.GetComponent<EnemyController>();
        if (enemyScript != null)
        {
            enemyScript.Fix();
        }
        // Destroy(gameObject);
        // Return to pool instead of destroying
        PoolManager.Instance.ReleaseProjectile(gameObject);
    }
}
