using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{

    public SerializationData<string, string> GameInfo;

    public SerializationData<string, float> CubePosition;
    public SerializationData<string, float> ForceCube;

    public SerializationData<string, float> ColorWallUp;
    public SerializationData<string, float> ColorWallDown;
    public SerializationData<string, float> ColorWallLeft;
    public SerializationData<string, float> ColorWallRight;
    public SerializationData<string, float> ColorSphere;

    public SerializationData<string, SerializationData<string, float>> SpheresPositions;
    public SerializationData<string, SerializationData<string, float>> SpheresForces;

    public GameData() {
        GameInfo = new SerializationData<string, string>();

        CubePosition = new SerializationData<string, float>();
        ForceCube = new SerializationData<string, float>();

        ColorWallUp = new SerializationData<string, float>();
        ColorWallDown = new SerializationData<string, float>();
        ColorWallLeft = new SerializationData<string, float>();
        ColorWallRight = new SerializationData<string, float>();
        ColorSphere = new SerializationData<string, float>();

        SpheresPositions = new SerializationData<string, SerializationData<string, float>>();
        SpheresForces = new SerializationData<string, SerializationData<string, float>>();
    }

    public void DeafultSetting() {
        GameInfo.Clear();
        GameInfo.Add("Version Game", Application.version);

        AddVectorToDictionary(CubePosition, Vector3.up);
        AddVectorToDictionary(ForceCube, Vector3.zero);

        Color Deafult = new Color(0.453f, 0.382f, 0.382f);
        ColorToDictionary(ColorWallUp, Deafult);
        ColorToDictionary(ColorWallDown, Deafult);
        ColorToDictionary(ColorWallLeft, Deafult);
        ColorToDictionary(ColorWallRight, Deafult);
        ColorToDictionary(ColorSphere, Deafult);

        float PositionX = -8f;

        RotationSphere[] keys = GameObject.FindObjectsOfType<RotationSphere>();
        foreach (RotationSphere key in keys) {
            MultipleVectorsToDictionary(SpheresPositions, key.id, Vector3.right * PositionX + Vector3.up * 2 + Vector3.forward * 5);
            MultipleVectorsToDictionary(SpheresForces, key.id, Vector3.zero);
            PositionX += 4f;
        }
    }



    public void AddVectorToDictionary(SerializationData<string, float> dictionary, Vector3 position) {
        dictionary.Clear();
        dictionary.Add("x" , position.x);
        dictionary.Add("y" , position.y);
        dictionary.Add("z" , position.z);
    }

    public Vector3 DictionaryToVector(SerializationData<string, float> dictionary) {
        float x, y, z;
        dictionary.TryGetValue("x" , out x);
        dictionary.TryGetValue("y" , out y);
        dictionary.TryGetValue("z" , out z);
        return new Vector3(x, y, z);
    }

    public void ColorToDictionary(SerializationData<string, float> dictionary, Color color) {
        dictionary.Clear();
        dictionary.Add("r", color.r);
        dictionary.Add("g", color.g);
        dictionary.Add("b", color.b);
    }

    public Color DictionaryToColor(SerializationData<string, float> dictionary) {
        float r, g, b;
        dictionary.TryGetValue("r" , out r);
        dictionary.TryGetValue("g" , out g);
        dictionary.TryGetValue("b" , out b);
        return new Color(r, g, b);
    }

    public void WallsColorToDicitonary(List<Color> ListColor) {
        ColorToDictionary(ColorWallUp, ListColor[0]);
        ColorToDictionary(ColorWallDown, ListColor[1]);
        ColorToDictionary(ColorWallLeft, ListColor[2]);
        ColorToDictionary(ColorWallRight, ListColor[3]);
    }

    public List<Color> DicitionaryToWallsColor() {
        List<Color> WallsColor = new List<Color>
        {
            DictionaryToColor(ColorWallUp),
            DictionaryToColor(ColorWallDown),
            DictionaryToColor(ColorWallLeft),
            DictionaryToColor(ColorWallRight)
        };
        return WallsColor;
    }

    public void MultipleVectorsToDictionary(SerializationData<string, SerializationData<string, float>> dictionary, string key, Vector3 vector)
    {
        SerializationData<string, float> TempSerializationData;
        dictionary.Add(key, new SerializationData<string, float>());
        dictionary.TryGetValue(key, out TempSerializationData);
        AddVectorToDictionary(TempSerializationData, vector);
    }

    public Vector3 MultipleDictionaryToVector(SerializationData<string, SerializationData<string, float>> dictionary, string key) {
        SerializationData<string, float> TempLoadSerializationData;
        dictionary.TryGetValue(key, out TempLoadSerializationData);
        return DictionaryToVector(TempLoadSerializationData);
    }
}