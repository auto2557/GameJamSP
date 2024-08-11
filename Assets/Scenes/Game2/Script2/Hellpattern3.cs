using UnityEngine;

public class Hellpattern3 : MonoBehaviour
{
    public GameObject bulletPrefab; // ???????????????
    public float bulletSpeed = 5f; // ?????????????????
    public float fireRate = 0.1f; // ??????????? (?????????????????????????)
    public int numberOfBullets = 12; // ??????????????????????????????

    private float timeSinceLastShot;

    void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && timeSinceLastShot >= fireRate)
        {
            Shoot();
            timeSinceLastShot = 0f;
        }
    }

    void Shoot()
    {
        float angleStep = 360f / numberOfBullets; // ????????????????????????
        float angle = 0f;

        for (int i = 0; i < numberOfBullets; i++)
        {
            float bulletDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180);
            float bulletDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180);

            Vector3 bulletMoveVector = new Vector3(bulletDirX, bulletDirY, 0f);
            Vector2 bulletDir = (bulletMoveVector - transform.position).normalized;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            AudioManager.instance.PlaySFX("bullet");
            bullet.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(bulletDir.x, bulletDir.y) * bulletSpeed;

            angle += angleStep;
        }
    }
}
