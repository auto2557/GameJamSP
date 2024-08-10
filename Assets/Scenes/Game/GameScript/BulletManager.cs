using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    static List<GameObject> bullets;
    void Start()
    {
        bullets = new List<GameObject>();
    }
    public static GameObject GetBulletFromPool()
    {
        for (int a = 0; a < bullets.Count; a++)
        {
            if(!bullets[a].activeSelf)
            {
                bullets[a].GetComponent<Bullet>().ResetTimer();
                bullets[a].SetActive(true);
                return bullets[a];
            }
        }
        return null;
    }
    
}
