using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataCollector : MonoBehaviour
{
    [System.Serializable]
    public class Pregame
    {
        public string ScouterName;
        public int TeamNumber;
        public string TeamName;
        public int MatchNumber;
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

    public Pregame pregame;
    public Auton atuon;
    public Teleop teleop;
    public PostMatch postmatch;
}
