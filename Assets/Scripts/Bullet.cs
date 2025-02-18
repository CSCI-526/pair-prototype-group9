using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;

    private Vector2 direction;

    public void Initialize(Vector2 direction)
    {
        this.direction = direction;
    }

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        // Move the bullet based on the direction
        transform.Translate(direction * speed * Time.deltaTime);

        // Check if the bullet is out of the specified boundary
        
    }

}
