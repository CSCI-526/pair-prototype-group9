using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;

    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Space)) 
        // {
        //     Shoot();
        // }
    }

    void Shoot()
    {
        // GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // bullet.GetComponent<Rigidbody2D>().linearVelocity = firePoint.right * bulletSpeed;
    }
}
