using Unity.VisualScripting;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public BulletSpawnData[] spawnDatas;
    public int index = 0;
    public bool isSequenceRandom;
    public bool spawningAutomatically;
    BulletSpawnData GetSpawnData()
    {
        if (index < 0 || index >= spawnDatas.Length)
        {
            Debug.LogError("Index is out of bounds: " + index);
            return null;
        }
        return spawnDatas[index];
    }
    float timer;

    float[] rotations;
    void Start()
    {
        var spawnData = GetSpawnData();
        if (spawnData == null) return;

        timer = GetSpawnData().cooldown;
        rotations = new float[GetSpawnData().numberOfBullets];
        if(!GetSpawnData().isRandom)
        {
            DistributedRotations();
        }
    }
    void Update()
    {

        if (spawningAutomatically)
        {
            if (timer <= 0)
            SpawnBullet();
            timer = GetSpawnData().cooldown;
            index += 1;
            if (isSequenceRandom)
            {
                index = Random.Range(0, spawnDatas.Length);
            }
            else
            {
                index += 1;
                if (index >= spawnDatas.Length) index = 0;
            }
            rotations = new float[GetSpawnData().numberOfBullets];
        }
        timer -= Time.deltaTime;

    }

    public float[] RandomRotations()
    {
        for (int a = 0; a < GetSpawnData().numberOfBullets; a++)
        {
            rotations[a] = Random.Range(GetSpawnData().minRotation, GetSpawnData().maxRotation);
        }
        return rotations;
    }

    public float[] DistributedRotations()
    {
        for (int a = 0; a < GetSpawnData().numberOfBullets; a++)
        {
            var fraction = (float)a / ((float)GetSpawnData().numberOfBullets - 1);
            var difference = GetSpawnData().maxRotation - GetSpawnData().minRotation;
            var fractionOfDifference = fraction * difference;
            rotations[a] = fractionOfDifference + GetSpawnData().minRotation;
        }
        foreach (var r in rotations) print(r);
        return rotations;
    }

    public GameObject[] SpawnBullet()
    {
        var spawnData = GetSpawnData();
        if (spawnData == null) return new GameObject[0];

        rotations = new float[GetSpawnData().numberOfBullets];
        if(GetSpawnData().isRandom)
        {
            RandomRotations();
        }

        GameObject[] spawnedBullets = new GameObject[GetSpawnData().numberOfBullets];
        for (int a = 0; a < GetSpawnData().numberOfBullets; a++)
        {
            if (a>= rotations.Length) break;
            
            spawnedBullets[a] = BulletManager.GetBulletFromPool();
            if (spawnedBullets[a] == null)
            {
                spawnedBullets[a] = Instantiate(GetSpawnData().bulletspawn, transform);
            } else
            {
                spawnedBullets[a].transform.SetParent(transform.parent);
                spawnedBullets[a].transform.localPosition = Vector2.zero;
            }
            spawnedBullets[a] = Instantiate(GetSpawnData().bulletspawn, transform);
            var b = spawnedBullets[a].GetComponent<Bullet>();
            b.Rotation = rotations[a];
            b.Speed = GetSpawnData().bulletSpeed;
            b.velocity = GetSpawnData().BulletVelocity;
            if (GetSpawnData().isNotParent) spawnedBullets[a].transform.SetParent(null);
        }
        return spawnedBullets;
    }
    

}
