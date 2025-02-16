using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f; // 子弹存在时间

    private void Start()
    {
        Destroy(gameObject, lifetime); // 设定子弹销毁时间
    }

    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
