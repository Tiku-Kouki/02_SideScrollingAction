using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    private AudioSource audioSource;

    private bool isBlock = true;

     



    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        GameManagerScript.score = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "COIN")
        {
            other.gameObject.SetActive(false);

            audioSource.Play();

            GameManagerScript.score += 1;
        }
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 v = rb.velocity;

        float moveSpeed = 3.0f;

        Vector3 rayPosition = transform.position;
        Ray ray = new Ray(rayPosition, Vector3.down);

        float distance = 0.6f;

        

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
        
        if (Input.GetKey(KeyCode.RightArrow) &&
           GoalScript.isGameClear == false)
         
        {   
            v.x = moveSpeed;
        }   
        else  
        if (Input.GetKey(KeyCode.LeftArrow)&&
            GoalScript.isGameClear == false)
        {
            v.x = -moveSpeed;
        } 
        else  
        {      
            v.x = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space)&&
            GoalScript.isGameClear == false &&
            isBlock == true)
        { 
            v.y = 5;
          
        }
            rb.velocity = v;
    }
}
