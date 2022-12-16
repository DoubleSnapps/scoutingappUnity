using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PositivitySelector : MonoBehaviour
{
    [SerializeField]
    bool selected;
    public bool Selected
    {
        get
        {
            return selected;
        }

        set
        {
            selected = value;
            transform.GetChild(0).gameObject.SetActive(selected);
        }
    }


    //ONLY FOR EDITOR
    //Please remove before build!
    private void Update(){ if (!Application.isPlaying) { transform.GetChild(0).gameObject.SetActive(selected); } }
}
