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
    public bool trueIsBlue;
    [System.Serializable]
    public class Page {
        public GameObject gameObject;
        public string title;
        public bool choose = true;
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

    // it *supposed* to detect when the chooser is yesed
    public void expander(Page page) {
        if (page.choose){
            expanded.SetActive(false);
        }
        else {
            // i would by lying if I said that I understand what rudy made
            bool random = Random.Range(0, 2) == 0 ? false : true;
            expandedBlue.gameObject.SetActive(random);
            expandedRed.gameObject.SetActive(!random);
        }
        
        if (trueIsBlue){
            expandedBlue.gameObject.SetActive(true);
            expandedRed.gameObject.SetActive(false);
        }
        else {
            expandedBlue.gameObject.SetActive(false);
            expandedRed.gameObject.SetActive(true);
        }
        logo.SetActive(page.hasLogo);
    }   
     
    // using on click, the "page" will change
    public void Goto(int newPage) {
        fakeScene[page].gameObject.SetActive(false);
        fakeScene[newPage].gameObject.SetActive(true);
        page = newPage;
        title.text = fakeScene[page].title;
        expander(fakeScene[page]);
        expanded.gameObject.SetActive(false);
        expanded.SetActive(false);
    }
  
    // sets wide to red when applicable 
    public void choseRed(){
        trueIsBlue = false;
    }
    
    // sets wide to blue when applicable 
    public void choseBlue (){
        trueIsBlue = true;
    }

}