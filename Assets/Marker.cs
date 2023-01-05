using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Marker : MonoBehaviour
{
    public enum MarkerType
    {
        startpos,
        shotmarker
    }
    MarkerType Type;
    public MarkerType type
    {
        get { return Type; }
        set { 
            Type = value;
            marker.type = value;
        }
    }
    float Difficulty;
    public float difficulty
    {
        get { return Difficulty; }
        set
        {
            Difficulty = value;
            marker.difficulty = value;
        }
    }
    bool Positive;
    public bool positive
    {
        get { return Positive; }
        set
        {
            Positive = value;
            marker.positive = value;
        }
    }
    public S_Marker marker = new S_Marker();

    [System.Serializable]
    public class S_Marker
    {
        public MarkerType type;
        public float difficulty;
        public bool positive;
        public Vector2 pos;
    }
}
