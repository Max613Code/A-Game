using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IBullet
{
    public float speed = 1;
    public Quaternion direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
            Destroy(gameObject);
        }
        Debug.Log("qwer");
    }
}
