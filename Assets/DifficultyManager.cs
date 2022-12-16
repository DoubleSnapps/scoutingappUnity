using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public float difficulty { get; set; }


    private void Start()
    {
        difficulty = -1;
    }
}
