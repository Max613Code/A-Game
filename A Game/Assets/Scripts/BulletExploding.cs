using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExploding : MonoBehaviour, IBullet
{
    public float speed = 1;
    public float explosionWaitTime = 2;
    public float explosionRadius = 2;
    public bool explodeOnDestroy = true;
    public float explosionTime = 1;
    public Material explosionMaterial;
    public Quaternion direction;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitExplosion());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Vector3.down * speed, Space.World);

        if (transform.position.x < -10 || transform.position.x > 10 || transform.position.y < -5 ||
            transform.position.y > 7)
        {
            if (explodeOnDestroy)
            {
                StartCoroutine(Explode());
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            other.GetComponent<Player>().health -= 1;
            if (explodeOnDestroy)
            {
                StartCoroutine(Explode());
            }
            else
            {
                Destroy(gameObject);
            }
        }
        Debug.Log("qwer");
    }

    public IEnumerator Explode()
    {
        speed = 0;
        gameObject.GetComponent<MeshRenderer>().material = explosionMaterial;
        gameObject.transform.localScale = new Vector3(explosionRadius, explosionRadius, explosionRadius);
        yield return new WaitForSeconds(explosionTime);
        Destroy(gameObject);
    }

    public IEnumerator WaitExplosion()
    {
        yield return new WaitForSeconds(explosionWaitTime);
        StartCoroutine(Explode());
    }

    public void SetUp(float Speed, float ExplosionWaitTime, float ExplosionRadius, bool ExplodeOnDestroy,
        float ExplosionTime, Material ExplosionMaterial, Quaternion Direction)
    {
        speed = Speed;
        explosionWaitTime = ExplosionWaitTime;
        explosionRadius = ExplosionRadius;
        explodeOnDestroy = ExplodeOnDestroy;
        explosionTime = ExplosionTime;
        if (ExplosionMaterial != null)
            explosionMaterial = ExplosionMaterial;
        direction = Direction;
    }
}
