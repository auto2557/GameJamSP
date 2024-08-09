using System.Numerics;
using UnityEngine;

public class Circular : MonoBehaviour
{
    public GameObject bulletspawn;
    public int bulletcount = 8;
    public float radius = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnBulletsinCircle();
    }

    // Update is called once per frame
    void SpawnBulletsinCircle()
    {
        for (int i = 0; i < bulletcount; i++)
        {
            float angle = i * Mathf.PI * 2 / bulletcount;
             UnityEngine.Vector2 bulletDirection = new UnityEngine.Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            UnityEngine.Vector2 bulletPosition = (UnityEngine.Vector2)transform.position + bulletDirection * radius;

            GameObject bullet = Instantiate(bulletspawn, bulletPosition, UnityEngine.Quaternion.identity);
            bullet.GetComponent<Bullet>().SetDirection(bulletDirection);
        }
    }   
}
