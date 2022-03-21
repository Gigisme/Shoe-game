using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrap : MonoBehaviour
{
    
    [Header("Firetrap timers")]
    [SerializeField] private float damage;
    [SerializeField] private float activationDelay;
    [SerializeField] private float activeTime;
    private Animator animate;
    private SpriteRenderer spriteRend;

    private bool triggered;
    private bool active;
    private void Awake()
    {
        animate = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!triggered)
            {
                StartCoroutine(ActivateFiretrap());
            }
            if (active)
                collision.GetComponent<Health>().TakeDamage(damage);

        }
    }
    private IEnumerator ActivateFiretrap()
    {
        //turn trap red when activated to alert payer
        triggered = true;
        spriteRend.color = Color.red;

        //Wait delay time, activate trap, turn on animation, return color back to normal
        yield return new WaitForSeconds(activationDelay);
        spriteRend.color = Color.white;
        active = true;
        animate.SetBool("activated", true);

        //Wait x seconds and turn off trap
        yield return new WaitForSeconds(activeTime);
        active = false;
        triggered = false;
        animate.SetBool("activated", false);
    }
}
