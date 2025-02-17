using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;  // 子弹速度
    public int damage = 1;     // 子弹伤害
    public float boundaryX = 10f;  // X 轴边界
    public float boundaryY = 5f;   // Y 轴边界

    private Transform target; // 目标（敌人）

    // 设置目标
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    void Update()
    {
        // 1. 如果有目标，向目标移动
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
        // 2. 没有目标时，沿着初始方向前进
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }

        // 3. 超出边界后销毁
        if (Mathf.Abs(transform.position.x) > boundaryX || Mathf.Abs(transform.position.y) > boundaryY)
        {
            Destroy(gameObject);
        }
    }

    // 子弹命中敌人时销毁
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {
            Destroy(gameObject);
        }
    }
}
