using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PageManager : MonoBehaviour
{
    public GameObject expanded;
    public GameObject expandedRed;
    public GameObject expandedBlue;
    public GameObject logo;
    [System.Serializable]
    public class Page {
        public GameObject gameObject;
        public string title;
        public bool choose;
        public bool hasLogo = false;
    }
    public Transform tile;
    public int page = 0;
    public TextMeshProUGUI title;
    public List<Page> fakeScene = new List<Page>();

    void Start() {
        foreach (var page in fakeScene){
            page.gameObject.SetActive(false);
        }
        Goto(0);
    }

    public void expander(Page page) {
        if (page.choose){
            expanded.SetActive(true);
        }
        else {
            bool random = Random.Range(0, 2) == 0 ? false : true;
            expandedBlue.gameObject.SetActive(random);
            expandedRed.gameObject.SetActive(!random);
        }
        logo.SetActive(page.hasLogo);
    }
     
    public void Goto(int newPage) {
        fakeScene[page].gameObject.SetActive(false);
        fakeScene[newPage].gameObject.SetActive(true);
        page = newPage;
        title.text = fakeScene[page].title;
        expander(fakeScene[page]);
        expanded.gameObject.SetActive(false);
        expanded.SetActive(false);
    }
}