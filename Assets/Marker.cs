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
    public MarkerType type;
    public float difficulty;
    public bool positive;
}
