using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private Behaviour[] components;
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
            foreach (Behaviour comp in components)
            {
                comp.enabled = false;
            }
            if (gameObject.CompareTag("Enemy"))// remove after player respawn implemented
                Deactivate();
        }
    }

    public void AddHealth(float _heal)
    {
        currentHealth = Mathf.Clamp(currentHealth + _heal, 0, startingHealth);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
