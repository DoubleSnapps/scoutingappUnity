using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PageManager : MonoBehaviour
{
    [System.Serializable]
    public class Page {
        public GameObject gameObject;
        public string title;
        public bool expanded;
    }
    public bool color = true;
    public GameObject chooser;
    public Transform tile;
    public int page = 0;
    public TextMeshProUGUI title;
    public List<Page> fakeScene = new List<Page>();

    void Start() {
        foreach (var page in fakeScene)
        {
            page.gameObject.SetActive(false);
        }
        Goto(0);
    }

    public void expander(Page page) {
        chooser.SetActive(!page.expanded);
        if(page.expanded) {
            tile.GetChild(color ? 1 : 0).gameObject.SetActive(true);
        }else{
            tile.GetChild(0).gameObject.SetActive(false);
            tile.GetChild(1).gameObject.SetActive(false);
        }
    }
    
    public void Goto(int newPage) {
        fakeScene[page].gameObject.SetActive(false);
        fakeScene[newPage].gameObject.SetActive(true);
        page = newPage;
        expander(fakeScene[page]);
        title.text = fakeScene[page].title;
    }   
}