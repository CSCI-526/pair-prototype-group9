using UnityEngine;
using TMPro;

public class Base : MonoBehaviour
{
    public int maxHP = 100; 
    public int currentHP;
    public TextMeshProUGUI hpText; 

    void Start()
    {
        currentHP = maxHP;
        UpdateHPUI();
    }


    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            currentHP = 0;
            GameOver();
        }
        UpdateHPUI();
    }


    void UpdateHPUI()
    {
        if (hpText != null){
            hpText.text = "HP: " + currentHP;
            Debug.Log("HP Updated: " + hpText.text); 
        }
    }


    void GameOver()
    {
        Debug.Log("Game Over! Base Destroyed.");

    }
}
