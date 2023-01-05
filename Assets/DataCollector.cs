using System.Collections;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class DataCollector : MonoBehaviour
{
    const bool RED = false;
    const bool BLUE = true;

    private void Start()
    {
        baseDir = Application.persistentDataPath;
    }

    [System.Serializable]
    public class Pregame
    {
        public string author;
        public string teamid;
        public string name;
        public float match;
        public bool noshow;
        public bool human;
        public bool preload;
        public bool alliance;
    }
    // prematch serialization 
    public void setScouterName(string name) {
        prematch.author = name;
    }
    public void setTeamNumber(string teamNumba) {
        prematch.teamid = teamNumba;
    }
    public void setTeamName(string teamName) {
        prematch.name = teamName;
    }
    public void setMatchNumber(string matchNumber) {
        prematch.match = float.Parse(matchNumber);
    }
    public void setNoShow(bool didTeamShow) {
        prematch.noshow = didTeamShow;
    }
    public void setPreliminaryExistance(bool skinwalker) {
        prematch.human = skinwalker;
    }
    public void setPreload(bool preload) {
        prematch.preload = preload;
    }
    public void setBlue() {
        prematch.alliance = BLUE;
    }
    public void setRed() {
        prematch.alliance = RED;
    }

    [System.Serializable]
    public class Auton
    {
        public List<Marker.S_Marker> markers = new List<Marker.S_Marker>();

        public void SetMarkers()
        {

        }
    }

    [System.Serializable]
    public class Teleop : Auton
    {
        public int extra_goal_progress;
    }

    [System.Serializable]
    public class PostMatch
    {
        public string Notes;
        [Range(0, 5)]
        public float GeneralRating;
        [Range(0, 5)]
        public float Teamwork;
        [Range(0, 5)]
        public float Defense;
        [Range(0, 5)]
        public float Offense;
    }
  
    public void getNotes(string theNotes) {
        postmatch.Notes = theNotes;
    }

    public void getGenRating(float genRate) {
        postmatch.GeneralRating = genRate;
    }
    
    public void getTeamRating(float teamRate) {
        postmatch.Teamwork = teamRate;
    }

    public void getDefenseRating(float defRating) {
        postmatch.Defense = defRating;
    }

    public void getOffeneseRating(float offenseRating) {
        postmatch.Offense = offenseRating;
    }

    public Pregame prematch;
    public Auton auton;
    public Teleop teleop;
    public PostMatch postmatch;

    string baseDir;

    public void SaveToFile(bool post = false) {
        string path = Path.Combine(Path.Combine(baseDir, DateTime.Now.Year.ToString()), DateTime.Now.Month + "_" + DateTime.Now.Day);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        path = Path.Combine(path, Directory.GetFiles(path).Length.ToString() + ".json");
        File.Create(path).Close();

        string json = JsonUtility.ToJson(this, true);

        File.WriteAllText(path, json);

        if (post) {
            PostFileToServer(path, (status, request) => {
                File.Move(Path.GetFullPath(request.callbackData), request.callbackData + ".sent");
            });
        }
    }

    public void PostToServer(DataCollector data) {
        var request = new TitanNetworkHandler.TitanNetworkRequest("form");
        TitanNetworkHandler.instance.requests.Add(request);
        request.callback = (result, request) => {
            Debug.Log(result);
        };
        StartCoroutine(request.post(JsonUtility.ToJson(data, false)));
    }

    public void PostFileToServer(string path, Action<string, TitanNetworkHandler.TitanNetworkRequest> callback) {
        var request = new TitanNetworkHandler.TitanNetworkRequest("form");
        TitanNetworkHandler.instance.requests.Add(request);
        request.callback = callback;
        request.callbackData = path;
        StartCoroutine(request.post(File.ReadAllText(path)));
    }

    public void PostAllFilesToServer() {
        string path = Path.Combine(baseDir, DateTime.Now.Year.ToString());
        //get all files recursively
        string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
        
        foreach (string file in files) {
            //check for sent_ prefix
            if (file.EndsWith(".sent")) {
                continue;
            }
            PostFileToServer(file, (status, request) => {
                File.Move(request.callbackData, request.callbackData + ".sent");
            });
        }
    }
}