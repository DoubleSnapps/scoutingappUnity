using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class darkenCanvas : MonoBehaviour
{
    public GameObject darkBlock;
    public void darken(){darkBlock.SetActive(true);}
    public void lighten(){darkBlock.SetActive(false);}

}
