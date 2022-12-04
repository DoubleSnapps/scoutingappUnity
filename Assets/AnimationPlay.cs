using UnityEngine;
public class AnimationPlay : MonoBehaviour
{
    public void PlayAnimaton(string name) {
        GetComponent<Animation>().Play(name);
    }
}
