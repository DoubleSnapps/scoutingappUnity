using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PageManager : MonoBehaviour
{
    public GameObject expandedRed;
    public GameObject chooserRed;
    public GameObject expandedBlue;
    public GameObject chooserBlue;
    public GameObject notes;
    public GameObject logo;
    public bool trueIsBlue;
    [System.Serializable]
    public class Page {
        public GameObject gameObject;
        public string title;
        public bool hasChoose = false;
        public bool hasLogo = false;
        public bool hasExpanded = false;
        public bool hasNotes = false;
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
    public void pageAttributes(Page page) {
        // if notes on page then exist 
        if (page.hasNotes){
           notes.gameObject.SetActive(true); 
        } else {
            notes.gameObject.SetActive(false);
        }

        // if title then existance (futile and SAD)
        if (page.hasLogo) {
            logo.gameObject.SetActive(true);
        } else {
            logo.gameObject.SetActive(false);
        }

        // if chooser then existance (hey if any lesbians are reading my code comments my number is 425553920-
        if (page.hasChoose) {
            chooserBlue.gameObject.SetActive(true);
            chooserRed.gameObject.SetActive(true);  
        } else {
            logo.gameObject.SetActive(false);
        }

        // the wide if red or is blue or isnt??? Huwooga.
        if(page.hasExpanded && trueIsBlue){
            expandedBlue.gameObject.SetActive(true);
            expandedRed.gameObject.SetActive(false);
        } else if (page.hasExpanded && !trueIsBlue) {
            expandedRed.gameObject.SetActive(true);
            expandedBlue.gameObject.SetActive(false);
        } else {
            expandedBlue.gameObject.SetActive(false);
            expandedRed .gameObject.SetActive(false);
        }




    }

    // using on click, the "page" will change
    public void Goto(int newPage)
    {
        fakeScene[page].gameObject.SetActive(false);
        fakeScene[newPage].gameObject.SetActive(true);
        page = newPage;
        title.text = fakeScene[page].title;
        pageAttributes(fakeScene[page]);

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