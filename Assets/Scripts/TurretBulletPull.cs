using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletPull : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    private Queue<GameObject> bulletPool = new Queue<GameObject>();

    public GameObject GetBullet()
    {
        if (bulletPool.Count > 0)
        {
            GameObject bullet = bulletPool.Dequeue();
            bullet.SetActive(true);
            return bullet;
        }
            return Instantiate(bulletPrefab);
    }
    public void ReturnBullet(GameObject bullet)
    {
        bullet.SetActive(false);
        bulletPool.Enqueue(bullet);
    }
}
