using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;

    AttackerSpawner myLaneSpawner;

    private void Start()
    {
        SetLaneSpawner();
    }
    private void Update()
    {
      
        /*if (IsAttackerInLane())
        {
            Debug.Log("shoot pew pew");
        }
        else
        {
            Debug.Log("sit and wait");
        } */
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough =
                (spawner.transform.position.y - transform.position.y <= Mathf.Epsilon);
            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        if(myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        return true;
    }

    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, transform.rotation);
    }

   
}
