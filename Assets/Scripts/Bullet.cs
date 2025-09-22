//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Bullet : MonoBehaviour
//{
//    [SerializeField] private float lifetime = 5f;
//    [SerializeField] private float damage = 10;

//    public  float getLifetime() 
//    {         
//        return lifetime; 
//    }
//    private void OnCollisionEnter(Collision collision)
//    {
//        if (collision.gameObject.CompareTag("Player"))
//        {
            
//            PlayerController playerHealth = collision.gameObject.GetComponent<PlayerController>();
//            if (playerHealth != null)
//            {
//                //playerHealth.TakeDamage(damage);
//            }
//        }
//        // Destroy the bullet after it hits something
//        Destroy(gameObject);
//    }
//}
