using UnityEngine;
using System.Collections;

public class Hellpattern : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab ของกระสุน
    public int numberOfBullets = 12; // จำนวนกระสุนที่จะยิงออก
    public float bulletSpeed = 5f; // ความเร็วของกระสุน
    public float fireInterval = 3f; // ระยะเวลาระหว่างการยิงแต่ละครั้ง

    void Start()
    {
        StartCoroutine(FireBulletsRoutine());
    }

    IEnumerator FireBulletsRoutine()
    {
        while (true)
        {
            FireBullets();
            yield return new WaitForSeconds(fireInterval);
        }
    }

    void FireBullets()
    {
        float angleStep = 360f / numberOfBullets;
        float angle = 0f;

        for (int i = 0; i < numberOfBullets; i++)
        {
            float bulletDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulletDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulletVector = new Vector3(bulletDirX, bulletDirY, 0f);
            Vector2 bulletMoveDirection = (bulletVector - transform.position).normalized * bulletSpeed;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            AudioManager.instance.PlaySFX("bullet");
            bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(bulletMoveDirection.x, bulletMoveDirection.y);

            angle += angleStep;
        }
    }
}
