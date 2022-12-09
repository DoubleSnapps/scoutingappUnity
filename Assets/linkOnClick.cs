using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linkOnClick : MonoBehaviour
{
    public void Open(string URLname){
        Application.OpenURL(URLname);
    }
}
