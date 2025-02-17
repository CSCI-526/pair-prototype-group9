using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f; 
    public float stopDistance = 5f;
    public int damage = 10;  

    private Transform baseTransform;

    void Start()
    {
        // 找到场景中的 Base 物体
        baseTransform = GameObject.FindGameObjectWithTag("Base").transform;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, baseTransform.position) > stopDistance)
        {
            // 只有距离目标点大于 stopDistance 时，敌人才移动
            transform.position = Vector2.MoveTowards(transform.position, baseTransform.position, speed * Time.deltaTime);
        }
        else
        {
            speed = 0f;
        }
    }


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
