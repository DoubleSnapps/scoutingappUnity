using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightSelector : MonoBehaviour
{
    public int height = -1;
    public Sprite deselected;
    public Sprite selected;
    public Sprite wowSelected;

    public void SetHeight(int h) {
        transform.GetChild(h).GetComponent<Image>().sprite = selected;
        if(height != -1)
            transform.GetChild(height).GetComponent<Image>().sprite = deselected;
        if(h == height) {
            height = -1;
            return;
        }
        height = h;
    }
}
