using UnityEngine;
using TMPro;

public class Wall : MonoBehaviour
{
    public int health = 1000;  // 城墙初始血量
    public TMP_Text healthText; 
    void Update()
    {
        healthText.text = "HP " + health;

        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        healthText.transform.position = screenPos;

        if (health <= 0)
        {   
            healthText.text = "HP " + 0f;
            GameOver();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    void GameOver()
    {
        // 游戏结束逻辑
        Debug.Log("Game Over");
        Time.timeScale = 0;  // 暂停游戏
    }
}
