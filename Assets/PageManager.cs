using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PageManager : MonoBehaviour
{
    // GameObjects for the expanded red, blue, and chooser versions of both colors
    public GameObject expandedRed;
    public GameObject chooserRed;
    public GameObject expandedBlue;
    public GameObject chooserBlue;
    // GameObject for the notes section
    public GameObject notes;
    // GameObject for the logo
    public GameObject logo;
    // Boolean indicating whether the "wide" version is currently set to blue or not
    public bool trueIsBlue;

    // Page class to store information about each page in the fakeScene list
    [System.Serializable]
    public class Page
    {
        // GameObject for the page
        public GameObject gameObject;
        // Title of the page
        public string title;
        // Boolean indicating whether the page has a chooser
        public bool hasChoose = false;
        // Boolean indicating whether the page has a logo
        public bool hasLogo = false;
        // Boolean indicating whether the page has an expanded version
        public bool hasExpanded = false;
        // Boolean indicating whether the page has notes
        public bool hasNotes = false;
    }

    // Transform for the tile
    public Transform tile;
    // Integer to store the current page
    public int page = 0;
    // TextMeshProUGUI for the title of the page
    public TextMeshProUGUI title;
    // List of Page objects representing the fake scene
    public List<Page> fakeScene = new List<Page>();

    void Start()
    {
        // Set all pages in the fakeScene list to inactive
        foreach (var page in fakeScene)
        {
            page.gameObject.SetActive(false);
        }
        // Go to the first page
        Goto(0);
    }

    // Method to apply page attributes, such as whether the page has notes, a logo, a chooser, or an expanded version
    public void pageAttributes(Page page)
    {
        // If the page has notes, set the notes GameObject to active
        if (page.hasNotes)
        {
            notes.gameObject.SetActive(true);
        }
        else
        {
            // Otherwise, set the notes GameObject to inactive
            notes.gameObject.SetActive(false);
        }

        // If the page has a logo, set the logo GameObject to active
        if (page.hasLogo)
        {
            logo.gameObject.SetActive(true);
        }
        else
        {
            // Otherwise, set the logo GameObject to inactive
            logo.gameObject.SetActive(false);
        }

        // If the page has a chooser, set both chooser GameObjects to active
        if (page.hasChoose)
        {
            chooserBlue.gameObject.SetActive(true);
            chooserRed.gameObject.SetActive(true);
        }
        else
        {
            // Otherwise, set both chooser GameObjects to inactive
            chooserBlue.gameObject.SetActive(false);
            chooserRed.gameObject.SetActive(false);
        }

        // the wide if red or is blue or isnt??? Huwooga.
        if (page.hasExpanded) {
            // Enable the blue or red expanded object based on the value of trueIsBlue
            expandedBlue.gameObject.SetActive(trueIsBlue);
            expandedRed.gameObject.SetActive(!trueIsBlue);
        }
        else {
            // Disable both expanded objects
            expandedBlue.gameObject.SetActive(false);
            expandedRed.gameObject.SetActive(false);
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