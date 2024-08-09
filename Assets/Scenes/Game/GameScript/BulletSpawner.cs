using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletspawn;
    public GameObject bullet;
    public float spawnrate = 0.1f;

    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnrate)
        {
            SpawnBullet();
            timer = 0f;
        }
    }

    void SpawnBullet()
    {
        Instantiate(bulletspawn, transform.position, Quaternion.identity);
    }
}
