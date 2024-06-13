using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.TextCore;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    private AudioSource audioSource;

    private bool isBlock = true;

    public GameObject bombParticle;

    public Animator animator;


    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        GameManagerScript.score = 0;
        transform.rotation = Quaternion.Euler(0, 90, 0);

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "COIN")
        {
            other.gameObject.SetActive(false);

            audioSource.Play();

            GameManagerScript.score += 1;

            Instantiate(bombParticle, transform.position, Quaternion.identity);

            Debug.Log("ƒRƒCƒ“‚ð‚Æ‚Á‚½");

        }
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 v = rb.velocity;

        float moveSpeed = 3.0f;

        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.8f, 0.0f);

        Ray ray = new Ray(rayPosition, Vector3.down);
       
        float distance = 0.9f;

        float stick = Input.GetAxis("Horizontal");




        //Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);

        isBlock = Physics.Raycast(ray, distance);

        if (isBlock == true)
        {
            Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);
        }
        else
        {
            Debug.DrawRay(rayPosition, Vector3.down * distance, Color.yellow);
        }
        
        

        if ((Input.GetKeyDown(KeyCode.Space)||
            Input.GetButtonDown("Jump"))&&
            GoalScript.isGameClear == false &&
            isBlock == true)
        {
            v.y = 5;

        }

       

       
        if ((Input.GetKey(KeyCode.RightArrow) || stick > 0) &&
           
            GoalScript.isGameClear == false)

           
        {
            
            animator.SetBool("walk", true);
            transform.rotation = Quaternion.Euler(0, 90, 0);
            v.x = moveSpeed;
           
        }
            else
            if ((Input.GetKey(KeyCode.LeftArrow) || stick < 0) &&
                GoalScript.isGameClear == false)
            {
                animator.SetBool("walk", true);
                transform.rotation = Quaternion.Euler(0, -90, 0);
                v.x = -moveSpeed;
            }
            else
            {
                animator.SetBool("walk", false);
                v.x = 0;
            }
        
        if (Input.GetKeyDown(KeyCode.Space) &&
            GoalScript.isGameClear == false &&
            isBlock == true)
        {

            v.y = 5;

           

        }


        if (isBlock == true)
        {
            animator.SetBool("jump", false);
            Debug.Log("’…’n");
        }
        else
        {
            animator.SetBool("jump", true);
        }

            rb.velocity = v;
    }
}
