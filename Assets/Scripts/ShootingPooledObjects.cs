using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPooledObjects : MonoBehaviour
{

    private GameObject bullet;
    [SerializeField]
    private Transform bulletOrigin;
    private float nextFire;
    [SerializeField]
    [Range(0, 1)]
    private float fireRate;

    // Update is called once per frame
    void Update()
    {
        FireBullet();
    }

    void FireBullet()
    {
        //this method will provide basic timing and input checks to call the CreateBullet method when pressing
        // left click
        if (Time.time > nextFire && Input.GetButton("Fire1"))
        {
            nextFire = Time.time + fireRate;
            CreateBullet();
        }
    }

    void CreateBullet()
    {
        //generates a bullet  based off the object pooler and reorients it to the "bullet origin"
        bullet = ObjectPooler.SharedInstance.GetPooledObject();
        if (bullet != null)
        {
            bullet.transform.position = bulletOrigin.position;
            bullet.transform.rotation = bulletOrigin.rotation;
            bullet.SetActive(true);
        }

    }


}
