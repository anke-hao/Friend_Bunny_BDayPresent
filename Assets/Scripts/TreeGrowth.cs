using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrowth : MonoBehaviour
{
    int stage = 0;
    public AudioClip tada;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();
        Transform player = other.gameObject.transform;
        if (controller != null)
        {
            string careType = controller.getCare();
            Animator animator = controller.GetComponent<Animator>();
            if(careType == "seed") {
                animator.SetTrigger("Till");
                transform.GetChild(stage).gameObject.SetActive(true);
                player.GetChild(stage).gameObject.SetActive(true);
                controller.setCare("None");
                controller.setCarrying(false);
                stage++;
            } else if (careType == "pickaxe"){
                animator.SetTrigger("Till");
                transform.GetChild(stage - 1).gameObject.SetActive(false); 
                transform.GetChild(stage).gameObject.SetActive(true);
                controller.setCare("None");
                controller.setCarrying(false);
                stage++;
                // controller.setCare("pickaxe");
            } else if (careType == "waterpot"){
                animator.SetTrigger("Water");
                transform.GetChild(stage - 1).gameObject.SetActive(false);
                transform.GetChild(stage).gameObject.SetActive(true);
                controller.setCare("None");
                controller.setCarrying(false);
                stage++;
            } 
            if (stage == 5) {
                    audioSource.PlayOneShot(tada);
                    player.GetChild(5).gameObject.SetActive(true);
            }
        }
    }
}
