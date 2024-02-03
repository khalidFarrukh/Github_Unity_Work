using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bezier_follow : MonoBehaviour
{
    [SerializeField]
    private Transform[] segments;
    private int segmentToGo;
    private float tParam;
    private Vector3 GoalPosition;
    private float speedModifier;
    private bool corountineAllowed;
    [SerializeField]
    private Transform Host;
    public float stopF = 1f;
    // Start is called before the first frame update
    void Start()
    {
        segmentToGo = 0;
        tParam = 0f;
        speedModifier = 0.5f;
        corountineAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (corountineAllowed)
        {
            StartCoroutine(GoByTheSegment(segmentToGo));
        }
    }
    private IEnumerator GoByTheSegment(int segmentNumber)
    {
        corountineAllowed = false;

        Vector3 p0=Vector3.zero, p1, p2, p3;
        if(segmentNumber > 0)
        {
            p0 = segments[segmentNumber-1].GetChild(2).position;
           
        }
        else if(segmentNumber == 0 && segments.Length > 1)
        {
            p0 = segments[segments.Length - 1].GetChild(2).position;
        }
        p1 = segments[segmentNumber].GetChild(0).position;
        p2 = segments[segmentNumber].GetChild(1).position;
        p3 = segments[segmentNumber].GetChild(2).position;
        while (tParam < 1)
        {
            if (Vector3.Distance(transform.position, Host.position) > 6f)
            {
                stopF = 0f;
            }
            else
            {
                stopF = 1f;
            }
            tParam += Time.deltaTime * speedModifier * stopF; 

            GoalPosition = Mathf.Pow(1 - tParam, 3) * p0 +
                3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                Mathf.Pow(tParam, 3) * p3;
            transform.position = GoalPosition;
            yield return new WaitForEndOfFrame();
        }
        tParam = 0f;
        segmentToGo += 1;
        if (segmentToGo > segments.Length - 1)
        {
            segmentToGo = 0;
        }
        corountineAllowed = true;
    }
}
