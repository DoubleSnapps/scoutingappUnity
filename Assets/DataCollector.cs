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
        List<Marker> Markers = new List<Marker>();

        public void SetMarkers()
        {

        }
    }

    [System.Serializable]
    public class Teleop : Auton
    {
        int ExtraGoalProgress;
    }

    [System.Serializable]
    public class PostMatch
    {
        string Notes;
        float GeneralRating;
        float Teamwork;
    }

}
