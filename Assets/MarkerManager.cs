using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MarkerManager : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    [SerializeField] Color startPosColor;
    [SerializeField] Color SucceedColor;
    [SerializeField] Color FailColor;
    [SerializeField] DataCollector john;
    public bool isTeleop;
    public DifficultyManager difficultyManager;
    public PositivityManager positivityManager;
    int markers = 0;

    void Update()
    {
        // Check if the left mouse button was clicked
        if (Input.GetMouseButtonDown(0))
        {
            if (markers != 0 && (difficultyManager.difficulty == -1 || positivityManager.unset))
            {
                return;
            }
            // Get the mouse position in 2D space
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);


            // Instantiate the prefab at the mouse position
            GameObject newObject = Instantiate(prefabToInstantiate, mousePos, Quaternion.identity);

            // Parent the new object to this transform
            newObject.transform.SetParent(transform);
            Rect rect = GetComponent<RectTransform>().rect;

            if (Mathf.Abs(newObject.transform.localPosition.y) > rect.height / 2)
            {
                Destroy(newObject);
                return;
            }
            if (Mathf.Abs(newObject.transform.localPosition.x) > rect.width / 2)
            {
                Destroy(newObject);
                return;
            }

            newObject.transform.localScale = new Vector3(1, 1, 1);

            Color color = startPosColor;
            Marker marker = newObject.GetComponent<Marker>();
            if (markers > 0)
            {
                marker.type = Marker.MarkerType.shotmarker;
                marker.difficulty = difficultyManager.difficulty;
                marker.positive = positivityManager.Positive;
                color = marker.positive ? SucceedColor : FailColor;
                newObject.transform.localScale = new Vector3(marker.difficulty, marker.difficulty);
            }
            newObject.GetComponent<Image>().color = color;

            List<Marker> list;

            if (isTeleop) {
                list = john.teleop.Markers;
            } else {
                list = john.auton.Markers;
            }
            list.Add(marker);

            markers++;
        }
    }

    public void RemoveLatestMarker()
    {
        if(markers <= 0) return;
        markers--;
        Destroy(transform.GetChild(transform.childCount - 1).gameObject);
    }

    public void RemoveAllMarkers()
    {
        markers = 0;
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
