using Unity.VisualScripting;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletspawn;
    public float minRotation;
    public float maxRotation;
    public int numberOfBullets;
    public bool isRandom;
    public float cooldown;
    float timer;
    public float bulletSpeed;
    public Vector2 BulletVelocity;

    float[] rotations;
    void Start()
    {
        timer = cooldown;
        rotations = new float[numberOfBullets];
        if(!isRandom)
        {
            DistributedRotations();
        }
    }
    void Update()
    {
        if (timer <= 0)
        {
            SpawnBullet();
            timer = cooldown;
        }
        timer -= Time.deltaTime;
    }

    public float[] RandomRotations()
    {
        for (int a = 0; a < numberOfBullets; a++)
        {
            rotations[a] = Random.Range(minRotation, maxRotation);
        }
        return rotations;
    }

    public float[] DistributedRotations()
    {
        for (int a = 0; a < numberOfBullets; a++)
        {
            var fraction = (float)a / ((float)numberOfBullets - 1);
            var difference = maxRotation - minRotation;
            var fractionOfDifference = fraction * difference;
            rotations[a] = fractionOfDifference + minRotation;
        }
        foreach (var r in rotations) print(r);
        return rotations;
    }

    public GameObject[] SpawnBullet()
    {
        if(isRandom)
        {
            RandomRotations();
        }

        GameObject[] spawnedBullets = new GameObject[numberOfBullets];
        for (int a = 0; a < numberOfBullets; a++)
        {
            spawnedBullets[a] = BulletManager.GetBulletFromPool();
            if (spawnedBullets[a] == null)
            {
                spawnedBullets[a] = Instantiate(bulletspawn, transform);
            } else
            {
                spawnedBullets[a].transform.SetParent(transform);
                spawnedBullets[a].transform.localPosition = Vector2.zero;
            }
            spawnedBullets[a] = Instantiate(bulletspawn, transform);
            var b = spawnedBullets[a].GetComponent<Bullet>();
            b.Rotation = rotations[a];
            b.Speed = bulletSpeed;
            b.velocity = BulletVelocity;
        }
        return spawnedBullets;
    }
    

}
