using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalScript : MonoBehaviour
{

    public GameObject GameClearText;

    public static bool isGameClear = false;

    

    // Start is called before the first frame update
    void Start()
    {
        isGameClear = false;
    }

    // Update is called once per frame
    void Update()
    {

       
    }

    private void OnTriggerEnter(Collider other)
    {
       
        GameClearText.SetActive(true);
        isGameClear = true;
    }


}
