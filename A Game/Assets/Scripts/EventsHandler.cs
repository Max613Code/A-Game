using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EventsHandler : MonoBehaviour
{
    public bool level1 = false;

    public GameObject Shooter;
    public GameObject ShooterClump;
    public GameObject Bullet;
    public GameObject BulletExploding;
    
    // Start is called before the first frame update
    void Start()
    {
        if (level1)
        {
            StartCoroutine(Level1());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Level1()
    {
        List<GameObject> listShooter = new List<GameObject>(5);
        List<GameObject> listShooterClump = new List<GameObject>(5);

        var player = GameObject.Find("Player");
        
        yield return new WaitForSeconds(2);

        listShooter.Add((GameObject) Instantiate(Shooter, new Vector3(1, 1, 0), Quaternion.identity));
        listShooter[0].GetComponent<Shooter>().player = player;
        listShooter[0].GetComponent<Shooter>().waitTime = 3;

        yield return new WaitForSeconds(5);
        
        listShooter.Add((GameObject) Instantiate(Shooter, new Vector3(2, 2, 0), Quaternion.identity));
        listShooter[1].GetComponent<Shooter>().player = player;
        listShooter[1].GetComponent<Shooter>().waitTime = 2;

        yield return new WaitForSeconds(5);
        
        listShooterClump.Add((GameObject) Instantiate(ShooterClump, new Vector3(2, 3, 0), Quaternion.identity));
        listShooterClump[0].GetComponent<ShooterClump>().player = player;
        listShooterClump[0].GetComponent<ShooterClump>().clumpWaitTime = 0.5f;
        listShooterClump[0].GetComponent<ShooterClump>().bullet = BulletExploding;
        listShooterClump[0].GetComponent<ShooterClump>().explosionWaitTime = 1;

        yield return new WaitForSeconds(10);
        
        foreach (var thing in listShooter.Concat(listShooterClump).ToList())
        {
             Destroy(thing);
        }

    }

}
