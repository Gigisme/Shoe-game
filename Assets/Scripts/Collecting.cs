using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Collecting : MonoBehaviour
{
    private int currency = 0;

    [SerializeField] private TextMeshProUGUI currencyText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Currency"))
        {
            Destroy(collision.gameObject);
            currency++;
            currencyText.text = currency.ToString();
        }
    }
}
