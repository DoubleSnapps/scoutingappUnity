using UnityEngine;
public class AnimationPlay : MonoBehaviour
{
    public bool is_toggled = false;
    public string toggle1 = "";
    public string toggle2 = "";

    public void PlayAnimaton(string name) {
        print(name);
        GetComponent<Animation>().Play(name);
    }


    public void PlayToggle()
    {
        is_toggled = !is_toggled;
        GetComponent<Animation>().Play(is_toggled ? toggle1 : toggle2);
    }
}
