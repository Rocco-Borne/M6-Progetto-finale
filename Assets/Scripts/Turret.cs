//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Turret : MonoBehaviour
//{
//    [SerializeField] TurretBulletPull bulletPull;
//    [SerializeField] int range = 20;
//    [SerializeField] float bulletSpeed = 20f;
//    [SerializeField] LayerMask targetMask;
//    [SerializeField] GameObject shootingPoint;
//    float timer;
//    float fireRate = 0.5f;
//    // Start is called before the first frame update
//    public void OnDrawGizmos()
//    {
//        Gizmos.color = Color.red;
//        Gizmos.DrawWireSphere(transform.position, range);
//    }

//    void FixedUpdate()
//    {
        
//        Collider[] colliders=Physics.OverlapSphere(transform.position, range, targetMask);
//        foreach (Collider collider in colliders)
//            if (collider.CompareTag("Player"))
//            {
//                Vector3 direction = (collider.transform.position - transform.position).normalized;

//                if (direction != Vector3.zero)
//                {
//                    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 0.2f);

//                }
//                while ( timer <0.5f)
//                {
//                    Shoot();
//                    timer -= 0.5f;
//                }
//                timer += Time.deltaTime;

//            }
//    }

//    void Shoot()
//    {
//        GameObject bullet = bulletPull.GetBullet();
//        bullet.transform.position = shootingPoint.transform.position;
//        bullet.transform.rotation = shootingPoint.transform.rotation;
//        Rigidbody rb = bullet.GetComponent<Rigidbody>();
//        if (rb != null)
//        {
//            rb.velocity = shootingPoint.transform.forward * bulletSpeed;
//        }
//        StartCoroutine(Reload());
//    }

//    IEnumerator Reload()
//    { 
//        yield return new WaitForSeconds(5); // Simulate reload time
//        bulletPull.ReturnBullet(bulletPull.GetBullet());
//    }
//}
