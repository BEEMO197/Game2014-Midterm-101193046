/*
 * BulletManager.cs
 * Matthew Pereira
 * 101193046
 * 10/24/2020
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    // Variables, Bullet factory to control the bullet that comes out, Max number of bullets, and a queue of gameobjects for our bullets
    public BulletFactory bulletFactory;
    public int MaxBullets;

    private Queue<GameObject> m_bulletPool;


    // Start is called before the first frame update
    void Start()
    {
        _BuildBulletPool();
    }

    // On start builds our bullet pool
    private void _BuildBulletPool()
    {
        // create empty Queue structure
        m_bulletPool = new Queue<GameObject>();

        for (int count = 0; count < MaxBullets; count++)
        {
            var tempBullet = bulletFactory.createBullet();
            m_bulletPool.Enqueue(tempBullet);
        }
    }

    // Gets our bullet, and spawns it to be used
    public GameObject GetBullet(Vector3 position)
    {
        var newBullet = m_bulletPool.Dequeue();
        newBullet.SetActive(true);
        newBullet.transform.position = position;
        return newBullet;
    }

    // Check to see if the bulletpool has bullets still and isn't empty
    public bool HasBullets()
    {
        return m_bulletPool.Count > 0;
    }

    // Returns the bullet to the bullet pool
    public void ReturnBullet(GameObject returnedBullet)
    {
        returnedBullet.SetActive(false);
        m_bulletPool.Enqueue(returnedBullet);
    }
}
