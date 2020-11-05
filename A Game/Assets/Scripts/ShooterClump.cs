using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterClump : ShooterBase, IShooter
{
    public GameObject partToRotate;
    public GameObject bullet;
    public GameObject player;
    public GameObject firepoint;
    public float turnSpeed = 1000;

    public float waitTime = 3;
    public float bulletAmount = 5;
    public float clumpWaitTime = 1;

    public float bulletSpeed = 0.1f;
    public float bulletSize = 0.3f;


    public bool shooting = true;


    private Vector3 targetPoint;
    private Quaternion targetRotation;

    private float xrotation, yrotation, zrotation;
    
    //Exploding Bullet settings
    public float explosionWaitTime = 2;
    public float explosionRadius = 2;
    public bool explodeOnDestroy = true;
    public float explosionTime = 1;
    public Material explosionMaterial;
    public Quaternion direction;

    public bool homing = false;
    public float bulletTurnSpeed = 5;
    public float homingDestroyTime = 5;

    // Start is called before the first frame update
    void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
        StartCoroutine((Shoot()));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = player.transform.position - transform.position;
        Quaternion lookRotation;
        
        //This part is for rotating
        //Handle if on z-axis or not, then do rotation
        if (player.transform.position.z != transform.position.z)
        {
            if (player.transform.position.x < transform.position.x)
            {
                lookRotation = Quaternion.LookRotation(dir) * Quaternion.Euler(0, 90, -90);
            }
            else if (player.transform.position.x == 0)
            {
                lookRotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                lookRotation = Quaternion.LookRotation(dir) * Quaternion.Euler(0, -90, 90);
            }
        }
        else
        {
            if (player.transform.position.x < transform.position.x)
            {
                lookRotation = Quaternion.LookRotation(dir) * Quaternion.Euler(0, 0, -90);
            }
            else if (player.transform.position.x == 0)
            {
                lookRotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                lookRotation = Quaternion.LookRotation(dir) * Quaternion.Euler(0, 0, 90);
            }
        }

        Vector3 rotation = Quaternion.Lerp(partToRotate.transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;

        if (partToRotate.transform.position.z == player.transform.position.z)
        {
            xrotation = 0f;
            yrotation = 0f;
        }
        else
        {
            xrotation = rotation.x;
            yrotation = rotation.y;
        }

        zrotation = rotation.z;
        
        
        partToRotate.transform.rotation = Quaternion.Euler(xrotation, yrotation, zrotation);
    }

    public IEnumerator Shoot()
    {
        while (shooting)
        {
            if (bullet.name == "Bullet")
            {
                yield return new WaitForSeconds(waitTime);
                for (int i = 0; i < bulletAmount; i++)
                {
                    GameObject Bullet = (GameObject) Instantiate(bullet, firepoint.transform.position,
                        partToRotate.transform.rotation);
                    Bullet.GetComponent<Bullet>().direction = partToRotate.transform.rotation;
                    if (bulletSpeed != -1)
                        Bullet.GetComponent<Bullet>().speed = bulletSpeed;

                    Bullet.GetComponent<Bullet>().SetUp(bulletSize);

                    if (i != bulletAmount - 1)
                        yield return new WaitForSeconds(clumpWaitTime);
                    
                    if (!homing)
                    {
                        Bullet.GetComponent<Bullet>().SetUp(bulletSize);
                    }
                    else
                    {
                        Bullet.GetComponent<Bullet>().SetUp(bulletSize, homing, player, bulletTurnSpeed, homingDestroyTime);
                    }
                    
                }
            } 
            else if (bullet.name == "BulletExplosion")
            {
                yield return new WaitForSeconds(waitTime);
                for (int i = 0; i < bulletAmount; i++)
                {
                    GameObject Bullet = (GameObject) Instantiate(bullet, firepoint.transform.position,
                        partToRotate.transform.rotation);
                    var script = Bullet.GetComponent<BulletExploding>();
                    direction = partToRotate.transform.rotation;
                    script.SetUp(bulletSpeed, explosionWaitTime, explosionRadius, explodeOnDestroy, explosionTime, explosionMaterial,
                        direction, bulletSize);

                    if (i != bulletAmount - 1)
                        yield return new WaitForSeconds(clumpWaitTime);
                    
                    if (!homing)
                    {
                        Bullet.GetComponent<BulletExploding>().SetUp(bulletSpeed, explosionWaitTime, explosionRadius,explodeOnDestroy,explosionTime,explosionMaterial,direction, bulletSize);
                    }
                    else
                    {
                        Bullet.GetComponent<BulletExploding>().SetUp(bulletSpeed, explosionWaitTime, explosionRadius,explodeOnDestroy,explosionTime,explosionMaterial,direction, bulletSize, homing, player, bulletTurnSpeed);
                    }
                }
            }

        }
    }
}
