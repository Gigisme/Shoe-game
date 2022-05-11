using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth == 0)
        {
            //player dies
            
            
        }
    }

    private void Update()
    {
        //Testing tkaing damage
        if (Input.GetKey(KeyCode.E))
        {
            TakeDamage(1);
        }
    }
}
