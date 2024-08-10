using UnityEngine;

public class BulletPatternSpiral : MonoBehaviour
{
    private float angle = 0f;
    void Start()
    {
        InvokeRepeating("Fire", 0f , 0.1f);
    }

    private void Fire()
    {
        float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
        float bulDirY = transform.position.y + Mathf.Sin((angle * Mathf.PI) / 180f);

        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
        Vector2 bulDir = (bulMoveVector - transform.position).normalized;

        GameObject bul = BulletSpawnData.bulletspawn;
        bul.SetActive(true);
        bul.transform.position = transform.position;
        bul.transform.rotation = transform.rotation;
        bul.SetActive(true);
        bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

        angle += 10f;

    }
}
