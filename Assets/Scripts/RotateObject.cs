using UnityEngine;
using System.Collections;
using Vuforia;

public class RotateObject : MonoBehaviour
{
    public GameObject[] gameObejctsArray;

    private bool m_StartRotating;
    public bool StartRotating
    {
        get { return m_StartRotating; }
        set { m_StartRotating = value; }
    }

    void Awake()
    {
        m_Instance = this;
    }

    void Update()
    {
        if (StartRotating)
        {
            foreach (GameObject go in gameObejctsArray)
            {
                go.transform.RotateAround(Vector3.up, 1 * Time.deltaTime);
            }
        }
    }

    // Singleton methods 
    private static RotateObject m_Instance = null;

    private RotateObject() { }

    public static RotateObject Instance
    {
        get { return m_Instance; }
    }

    private void OnTrackingFound()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>();

        // Enable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = true;
        }

        RotateObject.Instance.StartRotating = true;

       // Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
    }
    private void OnTrackingLost()
    {
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>();

        // Enable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = false;
        }

        RotateObject.Instance.StartRotating = false;

       // Debug.Log("Trackable " + TrackableBehaviour.TrackableName + " lost");
    }

}