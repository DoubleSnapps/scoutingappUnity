using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class DataCollector : MonoBehaviour
{
    [System.Serializable]
    public class Pregame
    {
        public string ScouterName;
        public string TeamNumber;
        public string TeamName;
        public float MatchNumber;
        public bool noShow;
        public bool human;
        public bool preload;
        public bool trueisblue;
    }
    // prematch serialization 
    public void setScouterName(string name) {
        pregame.ScouterName = name;
    }
    public void setTeamNumber(string teamNumba) {
        pregame.TeamNumber = teamNumba;
    }
    public void setTeamName(string teamName) {
        pregame.TeamName = teamName;
    }
    public void setMatchNumber(string matchNumber) {
        pregame.MatchNumber = float.Parse(matchNumber);
    }
    public void setNoShow(bool didTeamShow) {
        pregame.noShow = didTeamShow;
    }
    public void setPreliminaryExistance(bool skinwalker) {
        pregame.human = skinwalker;
    }
    public void setPreload(bool precum) {
        pregame.preload = precum;   
    }
    public void setBlue(bool blue = true) {
        pregame.trueisblue = blue;
    }
    public void setRed(bool red = false) {
        pregame.trueisblue = red;
    }

    [System.Serializable]
    public class Auton
    {
        public List<Marker> Markers = new List<Marker>();

        public void SetMarkers()
        {

        }
    }

    [System.Serializable]
    public class Teleop : Auton
    {
        public int ExtraGoalProgress;
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

    public Pregame pregame;
    public Auton atuon;
    public Teleop teleop;
    public PostMatch postmatch;
}