using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public void ShootBullet(Vector3 position, float fixedX)
    {
        StartCoroutine(ShootBulletCoroutine(position, fixedX));
    }

    private IEnumerator ShootBulletCoroutine(Vector3 position, float fixedX)
    {
        while (true)
        {
            GameObject bullet = Instantiate(bulletPrefab, position, Quaternion.identity);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            if (bulletScript != null)
            {
                bulletScript.Initialize(new Vector2(fixedX, 0)); 
            }
            if (bullet.GetComponent<Collider2D>() == null)
            {
                bullet.AddComponent<BoxCollider2D>(); // Add a collider to detect collisions
            }
            yield return new WaitForSeconds(2f); // Wait for 2 seconds before shooting the next bullet
        }
    }
}
