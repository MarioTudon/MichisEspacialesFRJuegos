using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : MonoBehaviour
{
    [SerializeField] private GameObject frontalBullet;
    [SerializeField] private GameObject downBullet;
    [SerializeField] private GameObject upBullet;
    [SerializeField] private Transform shotSpawn;
    [SerializeField] private PlayerMovement playerMovement;

    public void FrontalBullet()
    {
        Bullet newBullet = frontalBullet.GetComponent<Bullet>();
        newBullet.direction = playerMovement.direction;
        Instantiate(frontalBullet, shotSpawn.position, shotSpawn.rotation);
    }

    public void DownBullet()
    {
        Bullet newBullet = downBullet.GetComponent<Bullet>();
        newBullet.direction = playerMovement.direction;
        Instantiate(downBullet, shotSpawn.position, shotSpawn.rotation);
    }

    public void UpBullet()
    {
        Bullet newBullet = upBullet.GetComponent<Bullet>();
        newBullet.direction = playerMovement.direction;
        Instantiate(upBullet, shotSpawn.position, shotSpawn.rotation);
    }
}
