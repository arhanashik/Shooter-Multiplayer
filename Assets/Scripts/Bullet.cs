using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public int damage;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Player" && other.tag != "Enemy")
        {
            Debug.Log("Handle Tag: " + other.tag);
            return;
        }

        Destroy(gameObject);

        Health health = other.GetComponent<Health>();
        if (health  != null)
        {
            health.TakeDamage(damage);

            // if(health.GetCurrentHealth() == 0)
            // {
            //     Destroy(other.gameObject);
            // }
        }
        else
        {
            Debug.Log("Health Script Not Found!");
        }
    }
}
