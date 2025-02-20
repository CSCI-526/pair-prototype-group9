using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 60f; 
    public int damage = 30;  
    private Vector3 targetPosition;  

    public void Initialize(Vector3 target)
    {
        this.targetPosition = target;
        print("Bullet target: " + target);
        print("Bullet position: " + transform.position);
        Vector3 direction = (this.targetPosition - transform.position).normalized+new Vector3(0,0.5f,0);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction * speed;
            rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous; 
        }
    }

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {
            Zombie zombie = other.GetComponent<Zombie>();
            if (zombie != null)
            {
                zombie.TakeDamage(damage);
            }
            Destroy(gameObject); 
        }
    }

}
