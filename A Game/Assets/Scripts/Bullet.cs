using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IBullet
{
    public float speed = 1;
    public Quaternion direction;
    public float size = 0.3f;
    
    //Homing parameters
    public bool homing = false;
    public float turnSpeed = 5;
    public float homingDestroyTime = 5;
    private GameObject player;
    
    private float xrotation, yrotation, zrotation;
    

    // Start is called before the first frame update
    void Start()
    {
        if (homing&& homingDestroyTime != -1)
        {
            StartCoroutine(HomingDestory());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (homing)
        {

            Vector3 dir = player.transform.position - transform.position;
            Quaternion lookRotation;
            
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
            
                    Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
                    if (transform.position.z == player.transform.position.z)
                    {
                        xrotation = rotation.x;
                        yrotation = rotation.y;
                    }
                    else
                    {
                        xrotation = 0f;
                        yrotation = 0f;
                    }

                    zrotation = rotation.z;
                    
                    
                    direction = Quaternion.Euler(xrotation, yrotation, zrotation);
        }
        transform.Translate(direction * Vector3.down * speed, Space.World);

        if (transform.position.x < -10 || transform.position.x > 10 || transform.position.y < -5 ||
            transform.position.y > 7)
        {
            Destroy(gameObject);
        }
        
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<Player>().health -= 1;
            UIHandler.UpdateHealthText(other.GetComponent<Player>().health);
            Destroy(gameObject);
        }
        Debug.Log("qwer");
    }

    public IEnumerator HomingDestory()
    {
        yield return new WaitForSeconds(homingDestroyTime);
        homing = false;
    }
    
    public void SetUp(float Size)
    {
        size = Size;
        transform.localScale = new Vector3(size, size, size);
    }
    
    public void SetUp(float Size, bool Homing, GameObject Player, float TurnSpeed, float HomingDestroyTime)
    {
        size = Size;
        transform.localScale = new Vector3(size, size, size);
        homing = Homing;
        player = Player;
        turnSpeed = TurnSpeed;
        homingDestroyTime = HomingDestroyTime;
    }
}
