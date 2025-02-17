using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float speed = 1.0f;
    private float BaseLine = -10;
    public int hp = 100;

    void Update()
    {
        if (transform.position.y > BaseLine)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        // Check if hp is zero or below
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ReceiveAttack(int damage)
    {
        hp -= damage;
    }
}
