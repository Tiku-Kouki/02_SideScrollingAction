using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    
    // Update is called once per frame
    void Update()
    {
        Vector3 v = rb.velocity;

        float moveSpeed = 3.0f;

        

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
            GoalScript.isGameClear == false)
            {
                v.y = 5;
            }

        

            rb.velocity = v;
    }
}
