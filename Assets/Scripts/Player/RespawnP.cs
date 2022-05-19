using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnP : MonoBehaviour
{
    [SerializeField] private AudioClip CheckpointSound;
    private Transform currentCheckpoint;
    private Health playerHealth;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
    }
    public void RespawnPlayer()
    {
        transform.position = currentCheckpoint.position;
        playerHealth.Respawn();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Checkpoint")
        {
            currentCheckpoint = collision.transform;
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("Appear");
            
        }
    }
}
