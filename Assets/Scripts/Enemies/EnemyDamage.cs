using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            foreach(ContactPoint2D contact in collision.contacts)
            {
                //Deal damage NOT from above
                if (contact.normal.y > -0.9f)
                    collision.gameObject.GetComponent<Health>().TakeDamage(1);
            }
        }
    }
}
