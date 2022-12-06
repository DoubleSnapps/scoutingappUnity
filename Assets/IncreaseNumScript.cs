using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IncreaseNumScript : MonoBehaviour
{
    public int value = 0;
    public TextMeshProUGUI display;


    public void reevualuate(){
        display.text = value.ToString(); 
    }

    public void increase(){
        value ++;
        reevualuate();
    }

    public void decrease(){
        if(value -1 < 0){
            return;
        }
        value --;
        reevualuate();
        
    }



}
