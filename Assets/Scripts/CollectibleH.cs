using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleH : MonoBehaviour
{
    public int healthVar;
    public AudioClip collectedClip;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();


        if (controller != null && controller.health < controller.maxHealth)
        {
            controller.ChangeHealth(healthVar);
            controller.PlaySound(collectedClip);
            Destroy(gameObject);
            

            
        }

    }
}
