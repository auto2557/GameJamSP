using System.Collections;
using UnityEngine;

public class BulletSpawnerEz : GameSystem
{   
    public GameObject bulletprefep;



    int rotationSpeed = 50;
    bool db = false;
    void Update (){
        if (HellBulletPhase == true){
            

            if (db == false){
                StartCoroutine(BulletFireNormal());
            }
            transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
        }
    }


    IEnumerator BulletFireNormal (){
        db = true;
        yield return new WaitForSeconds(.2f);
        var bullet = Instantiate(bulletprefep, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().velocity.y = -1;
        bullet.transform.rotation = transform.rotation;
        
        var bulletBack = Instantiate(bulletprefep, transform.position, Quaternion.identity);
        bulletBack.GetComponent<Bullet>().velocity.y = 1;
        bulletBack.transform.rotation = transform.rotation;

        var bulletLeft = Instantiate(bulletprefep, transform.position, Quaternion.identity);
        bulletLeft.GetComponent<Bullet>().velocity.x = -1;
        bulletLeft.transform.rotation = transform.rotation;

        var bulletRight = Instantiate(bulletprefep, transform.position, Quaternion.identity);
        bulletRight.GetComponent<Bullet>().velocity.x = 1;
        bulletRight.transform.rotation = transform.rotation;
        db = false;
    }
}
