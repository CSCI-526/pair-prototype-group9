// using UnityEngine;

// public class Zombie : MonoBehaviour
// {
//     public float speed = 2f;
//     public int health = 100;
//     private Vector2 targetPosition;

//     void Start()
//     {
//         targetPosition = new Vector2(transform.position.x, -10f); // 目标位置（基地位置）
//     }

//     void Update()
//     {
//         transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
//     }

//     public void TakeDamage(int damage)
//     {
//         health -= damage;
//         if (health <= 0)
//         {
//             Destroy(gameObject); // 敌人死亡
//         }
//     }
// }

using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f; // 敌人移动速度
    public float stopDistance = 5f;
    public int damage = 10;  // 敌人对基地造成的伤害

    private Transform baseTransform; // 存储基地的位置

    void Start()
    {
        // 找到场景中的 Base 物体
        baseTransform = GameObject.FindGameObjectWithTag("Base").transform;
        // baseTransform = new Vector2(transform.position.x, -10f);
    }

    void Update()
    {
        // 移动敌人朝向基地
        // transform.position = Vector2.MoveTowards(transform.position, baseTransform.position, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, baseTransform.position) > stopDistance)
        {
            // 只有距离目标点大于 stopDistance 时，敌人才移动
            transform.position = Vector2.MoveTowards(transform.position, baseTransform.position, speed * Time.deltaTime);
        }
        else
        {
            // 敌人到达目标点后停止移动
            speed = 0f;
        }
    }

    // 当敌人碰到基地时
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Base"))
        {
            collision.GetComponent<Base>().TakeDamage(damage);
             Debug.Log("Zombie: 碰到Base" ); 
            // Destroy(gameObject);
        }
    }
}
