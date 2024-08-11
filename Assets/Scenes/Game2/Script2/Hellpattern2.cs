using UnityEngine;

public class Hellpattern2 : MonoBehaviour
{
    public GameObject bulletPrefab; // Bullet prefab
    public int numberOfBullets = 5; // Number of bullets to fire
    public float bulletSpeed = 10f; // Speed of the bullets
    public float spreadAngle = 30f; // Spread angle of the bullets
    public float fireInterval = 3f; // Interval between each shot

    void Start()
    {
        InvokeRepeating("FireShotgun", 0f, fireInterval);
    }

    void FireShotgun()
    {
        float angleStep = spreadAngle / (numberOfBullets - 1);
        float startAngle = -spreadAngle / 2;

        for (int i = 0; i < numberOfBullets; i++)
        {
            float currentAngle = startAngle + (i * angleStep);
            float bulletDirX = Mathf.Cos(currentAngle * Mathf.Deg2Rad);
            float bulletDirY = Mathf.Sin(currentAngle * Mathf.Deg2Rad);

            Vector3 bulletDirection = new Vector3(bulletDirX, bulletDirY, 0f).normalized;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            AudioManager.instance.PlaySFX("bullet");
            bullet.GetComponent<Rigidbody2D>().linearVelocity = bulletDirection * bulletSpeed;
        }
    }
}
