using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;
    void Start()
    {
        totalHealthBar.fillAmount = playerHealth.currentHealth / 10;//10 is max so 1/10 is 1 heart
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 10;//10 is max so 1/10 is 1 heart
    }
}
