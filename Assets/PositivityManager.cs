using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositivityManager : MonoBehaviour
{
    bool positive;
    public bool Positive
    {
        get
        {
            return positive;
        }
        
        set
        {
            positive = value;
            unset = false;
        }
    }

    public bool unset = true;
}
