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
        }
    }   
}
