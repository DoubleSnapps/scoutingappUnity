using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class OnDemandFileLoader : MonoBehaviour
{
    [SerializeField] string FileLocation;
    FileSystemWatcher watcher;
    bool refresh = false;
    [SerializeField] bool makeInvisibleIfFileNotFound = false;
    Vector2 originalSize;

    private void Start()
    {
        originalSize = GetComponent<RectTransform>().sizeDelta;
        if(FileLocation == null)
        {
            return;
        }
        if (File.Exists(FileLocation))
            ResetWatcher();
        RefreshTexture();
        print(FileLocation);
    }

    // Update is called once per frame
    void Update()
    {
        if(File.Exists(FileLocation) == false)
        {
            if(makeInvisibleIfFileNotFound)
            {
                GetComponent<Image>().enabled = false;
            }
            return;
        }
        else
        {
            GetComponent<Image>().enabled = true;
        }

        
        if (watcher == null || watcher.Path != Path.GetDirectoryName(FileLocation)) {
            ResetWatcher();
        }
        if (refresh) {
            // Load the texture from the file location
            var tex = LoadPNG(FileLocation);
            // Check if the config file exists
            var potentialConfigPath = Path.GetDirectoryName(FileLocation) + "/" + Path.GetFileNameWithoutExtension(FileLocation) + ".json";
            if (File.Exists(potentialConfigPath))
            {
                // Load the settings from the config file
                var settings = JsonUtility.FromJson<FileSettings>(File.ReadAllText(potentialConfigPath));
                // Set the filter mode based on the pixel art setting
                tex.filterMode = settings.PixelArt ? FilterMode.Point : FilterMode.Bilinear;
                // Set the size of the image based on the augmented size setting
                GetComponent<RectTransform>().sizeDelta = originalSize * settings.AugmentedSize;
            }
            // Set the sprite of the image component to the texture
            GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            refresh = false;
        }
    }

    void ResetWatcher()
    {
        Debug.Log("Watcher Reset");
        Debug.Log(Path.GetFullPath(FileLocation));
        watcher = new FileSystemWatcher(Path.GetDirectoryName(FileLocation));
        watcher.NotifyFilter = NotifyFilters.Attributes |
            NotifyFilters.CreationTime |
            NotifyFilters.FileName |
            NotifyFilters.LastAccess |
            NotifyFilters.LastWrite |
            NotifyFilters.Size |
            NotifyFilters.Security;
        watcher.IncludeSubdirectories = true;
        watcher.EnableRaisingEvents = true;
        watcher.Changed += (object sender, FileSystemEventArgs e) => {
            RefreshTexture();
        };
        watcher.Filter = Path.GetFileNameWithoutExtension(FileLocation) + ".*";


    }

    public void RefreshTexture()
    {
        Debug.Log("Texture Refreshed");
        refresh = true;
    }

    public static Texture2D LoadPNG(string filePath)
    {

        Texture2D tex = null;
        byte[] fileData;

        if (File.Exists(filePath))
        {
            fileData = File.ReadAllBytes(filePath);
            tex = new Texture2D(2, 2);
            tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.
        }
        return tex;
    }

    public class FileSettings
    {
        public bool PixelArt = false;
        public Vector2 AugmentedSize = Vector2.one;
    }
}
