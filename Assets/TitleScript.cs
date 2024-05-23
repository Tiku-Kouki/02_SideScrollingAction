using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour
{
    public string nextScreneName;
    public GameObject hitKey;

    private int timer = 0;


    // Update is called once per frame
    void Update()
    {

        timer++;
        if (timer % 100 > 70)
        {
            hitKey.SetActive(false);
        }
        else
        {
            hitKey.SetActive(true);
        }
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("SampleScene");
        }


    }
}
