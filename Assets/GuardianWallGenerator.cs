using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using static OVRBoundary;
using static OVRManager;

public class GuardianWallGenerator : MonoBehaviour
{
    private Vector3[] boundaryPoints;
    private bool createdWall = false;

    private int boardDistance = 8;
    public GameObject wallBoard;


    private bool configured = true;

    public TextMeshProUGUI text;



    void Start()
    {
        
    }

    void Update()
    {
        if (createdWall == false)
        {
            CreateWall();
        }
    }


    private void CreateWall()
    {
        //configured = OVRManager.boundary.GetConfigured();

        Debug.Log("CONFIGURATION : " + configured);

        if (configured == true)
        {
            Debug.Log("Configured");

            boundaryPoints = OVRManager.boundary.GetGeometry(OVRBoundary.BoundaryType.OuterBoundary);

            text.text = "value : " + boundaryPoints.Length.ToString();

            /*for (int i = 0; i < boundaryPoints.Length; i++)
            {
                Debug.Log("Boudary points : " + boundaryPoints[i]);
            }*/

           

            for (int i = 0; i < boundaryPoints.Length; i++)
            {
                if (i % boardDistance == 0)
                {
                    var newBoard = Instantiate(wallBoard, boundaryPoints[i], Quaternion.identity);

                    Vector3 forward = Vector3.zero;

                    if (i < boundaryPoints.Length - 1)
                        forward = boundaryPoints[i] - boundaryPoints[i + 1];

                    newBoard.transform.forward = forward;
                }
            }
            createdWall = true;
        }
    }

}
