using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

//public sealed class Screen
//{
//    public static void SetResolution(int width, int height, bool fullscreen);
//}

public class GameManagerScript : MonoBehaviour
{
    public GameObject block;

    public GameObject block2;

    public GameObject coin;

    public GameObject goal;

    public TextMeshProUGUI scoreText;

    public static int score = 0;
  

    public static bool isGameOver = false;

    public GameObject goalParticle;

    

    int[,] map;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = Vector3.zero;

        GameObject instance;

        Screen.SetResolution(1920, 1080, false);

        map = new int[,]
        {
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,2,2,0,0,0,0,0,0,0,0,3,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,1,0,0,0,2,2,0,1,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1 },
            { 1,0,0,0,2,2,0,0,0,1,0,0,0,0,1,1,0,0,1,0,0,0,0,0,1,0,1,1,0,2,2,0,0,0,1,0,0,0,0,1 },
            { 1,0,0,0,1,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1 },
            { 1,0,0,1,1,1,1,0,0,0,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1 },
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
        
        };

        for (int y = 0; y < map.GetLength(0); y++)
        {
            position.y = -y + 5;
            for (int x = 0; x < map.GetLength(1); x++)
            {
                position.x = x;
                if (map[y, x] == 1)
                {
                    instance = Instantiate(
                    block,
                    position,
                    Quaternion.identity
                   );

                }

                if (map[y, x] == 2)
                {
                    instance = Instantiate(
                    coin,
                    position,
                    Quaternion.identity
                   );




                }

                if (map[y, x] == 3)
                {
                    instance = Instantiate(
                    goal,
                    position,
                    Quaternion.identity
                   );

                    goalParticle.transform.position = position;

                    // instance = Instantiate(
                    // goalParticle,
                    // position,
                    // Quaternion.identity
                    //);

                }


            }
        }

        for (int y = 0; y < map.GetLength(0); y++)
        {
            position.y = -y + 5;
            for (int x = 0; x < map.GetLength(1); x++)
            {
                position.x = x;
                position.z = 2;

                Instantiate(block2, position, Quaternion.identity);

            }
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (GoalScript.isGameClear == true)
        {
            if (Input.GetKeyDown(KeyCode.Space)|| 
                Input.GetButtonDown("Jump"))
            {
                SceneManager.LoadScene("TitleScene");
            }

        }

        scoreText.text = "SCORE " + score;


    }
}
