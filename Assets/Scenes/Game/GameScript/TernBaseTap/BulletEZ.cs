using System;
using System.Collections;
using UnityEngine;

public class BulletSpawnerEz : GameSystem
{   
    public GameObject bulletprefep;

    public GameObject bulletprefepLarge;


    bool NormalBulleting = false;

    bool NormalBulleting2 = false;


    int rotationSpeed = 50;
    bool db = false;
    void Update (){
        if (HellBulletPhase == true){

            if (db == false){
                StartCoroutine(BulletHellMain());
            }

            if (NormalBulleting == true){
                transform.Rotate(new Vector3(0,0,rotationSpeed) * Time.deltaTime);
            }

            if (NormalBulleting2 == true){
                transform.Rotate(new Vector3(0,0,-rotationSpeed) * Time.deltaTime);
            }
        }
    }

    IEnumerator BulletHellMain (){
        db = true;
        NormalBulleting = true;
        for(int i = 0; i < 30; i++){
            BulletFireNormal();
            yield return new WaitForSeconds(.25f);
        }

        yield return new WaitForSeconds(1f);

        NormalBulleting = false;

        transform.rotation = Quaternion.Euler(0, 0, 0);
        for(int i = 0; i < 15; i++){
            BulletFireLazer();
            yield return new WaitForSeconds(.1f);
        }


        yield return new WaitForSeconds(1f);

        NormalBulleting2 = true;

        transform.rotation = Quaternion.Euler(0, 0, 0);
        for(int i = 0; i < 3; i++){
            BulletFireSpin();
            yield return new WaitForSeconds(.15f);
        }
        NormalBulleting2 = false;
        db = false;
    }
    void BulletFireNormal (){
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

        transform.Rotate(new Vector3(0,0,10) * Time.deltaTime);
    }

    void BulletFireSpin (){
        var bullet = Instantiate(bulletprefepLarge, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().velocity.y = -1;
        bullet.transform.rotation = transform.rotation;
        
        var bulletBack = Instantiate(bulletprefepLarge, transform.position, Quaternion.identity);
        bulletBack.GetComponent<Bullet>().velocity.y = 1;
        bulletBack.transform.rotation = transform.rotation;

        var bulletLeft = Instantiate(bulletprefepLarge, transform.position, Quaternion.identity);
        bulletLeft.GetComponent<Bullet>().velocity.x = -1;
        bulletLeft.transform.rotation = transform.rotation;

        var bulletRight = Instantiate(bulletprefepLarge, transform.position, Quaternion.identity);
        bulletRight.GetComponent<Bullet>().velocity.x = 1;
        bulletRight.transform.rotation = transform.rotation;
    }

    void BulletFireLazer (){
        var bullet = Instantiate(bulletprefepLarge, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().velocity.x = 5;
        bullet.transform.rotation = transform.rotation;
    }

}
