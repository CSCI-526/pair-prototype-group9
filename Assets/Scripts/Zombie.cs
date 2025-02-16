using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float speed = 2f;
    public int health = 100;
    private Vector2 targetPosition;

    void Start()
    {
        targetPosition = new Vector2(transform.position.x, -10f); // 目标位置（基地位置）
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    // public void TakeDamage(int damage)
    // {
    //     health -= damage;
    //     if (health <= 0)
    //     {
    //         Destroy(gameObject); // 敌人死亡
    //     }
    // }
}
