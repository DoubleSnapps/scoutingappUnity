using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageColor : MonoBehaviour
{
    public Color[] colors;
    public void SetColor(int color)
    {
        GetComponent<Image>().color = colors[color];
    }
}
