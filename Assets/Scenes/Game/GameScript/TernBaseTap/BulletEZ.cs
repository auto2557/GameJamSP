using System;
using System.Collections;
using UnityEngine;

public class BulletSpawnerEz : GameSystem
{   
    public GameObject bulletprefep;

    public GameObject bulletprefepLarge;



    int rotationSpeed = 50;
    bool db = false;
    bool BulletNormal = false;
    bool BulletNormaled = false;


    bool BulletLazer = false;
    bool BulletLazered = false;
    void Update (){
        if (HellBulletPhase == true){

            if (BulletNormal == false && BulletNormaled == false){
                if (db == false){
                    StartCoroutine(BulletFireNormal());
                }
                transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);
            }
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

    IEnumerator CooldownSkill (){
        BulletNormal = true;
        yield return new WaitForSeconds(15f);
        BulletNormal = false;
        BulletNormaled = true;
        db = false;
    }

    IEnumerator BulletFireLaser (){
        db = true;
        yield return new WaitForSeconds(.05f);
        var bullet = Instantiate(bulletprefepLarge, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().velocity.y = 5;
        db = false;

    }
}
