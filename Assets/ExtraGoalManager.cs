using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraGoalManager : MonoBehaviour
{
    public int challangeProgress;
    [SerializeField] DataCollector john;

    public void setProgress(int value) {
        challangeProgress = value;
        john.teleop.extra_goal_progress = value;
    }
}
