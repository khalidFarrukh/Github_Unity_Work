using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    [SerializeField]
    private Transform[] Controlpoints;

    private Vector3 gizmosPostion;

    private void OnDrawGizmos()
    {
        for (float t = 0; t <= 1; t += 0.05f)
        {
            gizmosPostion = Mathf.Pow(1 - t, 3) * Controlpoints[0].position +
                3 * Mathf.Pow(1 - t, 2) * t * Controlpoints[1].position +
                3 * (1 - t) * Mathf.Pow(t, 2) * Controlpoints[2].position +
                Mathf.Pow(t, 3) * Controlpoints[3].position;
            Gizmos.DrawSphere(gizmosPostion, 0.25f);
        }
        Gizmos.DrawLine(new Vector3(Controlpoints[0].position.x, Controlpoints[0].position.y,Controlpoints[0].position.z),
            new Vector3(Controlpoints[1].position.x, Controlpoints[1].position.y, Controlpoints[1].position.z));
        Gizmos.DrawLine(new Vector3(Controlpoints[2].position.x, Controlpoints[2].position.y, Controlpoints[2].position.z),
            new Vector3(Controlpoints[3].position.x, Controlpoints[3].position.y, Controlpoints[3].position.z));
    }
}
