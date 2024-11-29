using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZoneScript : MonoBehaviour
{
    public int healthVar;
    public AudioClip hitClip;
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


            if (controller != null)
            {
                controller.ChangeHealth(healthVar);
                controller.PlaySound(hitClip);
            }

        }
}
