using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Hit_Mouse : MonoBehaviour
{
    public List<Transform> Good;
    public List<Transform> Bad;
    public List<Transform> Mouses;

    public List<Transform> MouseDoor;

    public Camera Now_Camera;
    public float scores = 0;
    public float win_score = 100;

    public float ComeTime = 3;
    public float Timer = 0;

    public GameObject WonUI;
    public GameObject LostUI;
    // Start is called before the first frame update
    void Start()
    {
        Mouses = new List<Transform>();
        Mouses.AddRange(Good);
        Mouses.AddRange(Bad);
    }
    public void scores_add(float scores)
    {
        scores += scores;
        if (scores >= win_score)
        {
            WonUI.SetActive(true);
        }
        else if (scores <= -win_score)
        {
            LostUI.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit ray;
        if (Physics.Raycast(Now_Camera.ScreenPointToRay(Input.mousePosition), out ray))
        {
            if (Good.Contains(ray.transform))
            {
                scores_add(-5);
            }
            if (Bad.Contains(ray.transform))
            {
                scores_add(5);
            }
        }
    }
}
