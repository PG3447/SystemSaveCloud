using System.Collections.Generic;
using UnityEngine;

public class ManagerWallsAndColors : MonoBehaviour, IManagerSave
{
    public static ManagerWallsAndColors instance { get; private set; }

    private int direction;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        direction = 1;
    }

    public void ChangeColor() {
        direction = Random.Range(0, 4);
        List<Color> Colors = RandomFourColors();
        foreach (GameObject objects in GameObject.FindObjectsOfType<GameObject>()) {
            if (objects.name == "Sphere") {
                objects.GetComponent<Renderer>().material.color = Colors[0];
            }

            if (objects.name == "Walls") {
                //Roznie moze byc
                int y = 1;
                for (int i = 0; i < 4; i++)
                {
                    if (direction == i)
                    {
                        objects.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color = Colors[0];
                        y--;
                        continue;
                    }
                    objects.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color = Colors[i+y];
                }
            }
        }
    }

    private List<Color> RandomFourColors() {
        List <Color> colors = new List<Color>();
        for (int i = 0; i < 4; i++) {
            colors.Add(new Color((float)Random.Range(0f,1f), (float)Random.Range(0f, 1f), (float)Random.Range(0f, 1f)));
        }
        return colors;
    }

    public int ReadDirection() {
        return direction;
    }

    public void DataSave(ref GameData gameData)
    {
        foreach (GameObject objects in GameObject.FindObjectsOfType<GameObject>())
        {
            if (objects.name == "Sphere")
            {
                gameData.ColorToDictionary(gameData.ColorSphere, objects.GetComponent<Renderer>().material.color);
            }

            if (objects.name == "Walls")
            {
                List<Color> WallsColor = new List<Color>();
                for (int i = 0; i < 4; i++)
                {
                     WallsColor.Add(objects.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color);
                }
                gameData.WallsColorToDicitonary(WallsColor);

            }
        }
    }

    public void DataLoad(GameData gameData)
    {
        foreach (GameObject objects in GameObject.FindObjectsOfType<GameObject>())
        {
            if (objects.name == "Sphere")
            {
                objects.GetComponent<Renderer>().material.color = gameData.DictionaryToColor(gameData.ColorSphere);
            }

            if (objects.name == "Walls")
            {
                List<Color> WallsColor = gameData.DicitionaryToWallsColor();
                for (int i = 0; i < 4; i++)
                {
                    objects.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color = WallsColor[i];
                }

            }
        }
    }

}
