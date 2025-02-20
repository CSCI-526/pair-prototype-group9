using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 2f;
    private GameObject targetZombie;

    private Vector3 towerPosition;

    public void Initialize(Vector3 towerPosition)
    {
        this.towerPosition = towerPosition;
        print("Tower position: " + towerPosition);
        StartCoroutine(ShootCoroutine());
    }


    private IEnumerator ShootCoroutine()
    {
        while (true)
        {
            Zombie nearestZombie = FindNearestZombie(towerPosition);
            if (nearestZombie != null)
            {
                print("Nearest zombie: " + nearestZombie);
                ShootBullet(nearestZombie.transform.position);
            }
            yield return new WaitForSeconds(fireRate);
        }
    }

    public void ShootBullet(Vector3 targetPosition)
    {
        GameObject bullet = Instantiate(bulletPrefab, towerPosition, Quaternion.identity);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.Initialize(targetPosition);
        }
    }

    private Zombie FindNearestZombie(Vector3 position)
    {
        Zombie[] zombies = FindObjectsOfType<Zombie>();
        Zombie nearestZombie = null;
        float shortestDistance = Mathf.Infinity;

        foreach (Zombie zombie in zombies)
        {
            float distance = Vector3.Distance(position, zombie.transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestZombie = zombie;
            }
        }

        return nearestZombie;
    }
}
