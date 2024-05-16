using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//public sealed class Screen
//{
//    public static void SetResolution(int width, int height, bool fullscreen);
//}

public class GameManagerScript : MonoBehaviour
{
    public GameObject block;

    public GameObject goal;

    public static bool isGameOver = false;


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
            { 1,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,1,0,0,0,2,2,0,1,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,1 },
            { 1,0,0,0,2,2,0,0,0,1,0,0,0,0,1,1,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1 },
            { 1,0,0,0,1,1,0,0,1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,1,1,1,1,0,0,0,2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,2,2,0,0,0,1 },
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

                if (map[y, x] == 3)
                {
                    instance = Instantiate(
                    goal,
                    position,
                    Quaternion.identity
                   );

                }


            }
        }



    }

    // Update is called once per frame
    void Update()
    {

        if (GoalScript.isGameClear == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene("TitleScene");
            }

        }




    }
}
