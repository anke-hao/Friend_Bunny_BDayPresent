using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;

    Rigidbody2D rigidbody2d;
    float horizontal; 
    float vertical;
    string careType;
    bool hasCare;

    public AudioClip footsteps;
    AudioSource audioSource;

    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);

   // Start is called before the first frame update
   void Start()
   {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        audioSource= GetComponent<AudioSource>();
        hasCare = false;
        
   }

   public void PlaySound(AudioClip clip)
   {
        audioSource.PlayOneShot(clip);
   }

   // Update is called once per frame
   void Update()
   {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
       
   }

   void FixedUpdate()
    {
        Vector2 move = new Vector2(horizontal, vertical);
        
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
            if (!audioSource.isPlaying)
            PlaySound(footsteps);
        }
                
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

    public void setCare(string care) {
        careType = care;
    }

    public string getCare() {
        return careType;
    }

    public bool checkCarrying() {
        return hasCare;
    }

    public void setCarrying(bool carrying) {
        hasCare = carrying;
    }
}
