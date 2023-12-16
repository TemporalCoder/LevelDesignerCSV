using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//[ExecuteInEditMode]

public class CSV2Level : MonoBehaviour
{
    public TextAsset mapCSV;        //drag the CSV file here
    int[,] maze;                    //convert csv to array
    public GameObject cube; 
    public int scale = 1;

    public bool cleanup = false;
    // Start is called before the first frame update
    void Start()
    {
        
        string[] lines = mapCSV.text.Split('\n'); //split file at new line
        int levelSize = lines.Length - 1; //set level size

        maze = new int[levelSize, levelSize]; // create array based on how many characters

        //create map array
        for (int i = 0; i < levelSize; i++)
        {
            string[] mapRow = lines[i].Split(",");
            
            for (int j = 0; j < levelSize; j++)
            {
                if(!int.TryParse(mapRow[j], out maze[i,j]))
                {
                    maze[i,j] = 0;
                }

            }
        }


        //create 3d maze from array - 0 for ground, 1 for wall (same cube, just change height) 
        for (int row = 0; row < levelSize; row++)
        {
            for (int col = 0; col < levelSize; col++)
            {
                GameObject clone = Instantiate(cube, 
                    new Vector3(row*scale, maze[row, col]*scale, col*scale), 
                    Quaternion.identity);
                clone.transform.localScale = new Vector3(scale, scale, scale);
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        if(cleanup == true)
        {
            foreach (var gameObj in GameObject.FindGameObjectsWithTag("Wall"))
            {
                Destroy(gameObj);
            }
        }
        
    }
}
