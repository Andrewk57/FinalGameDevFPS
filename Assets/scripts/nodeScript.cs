using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nodeScript : MonoBehaviour
{
    // The node that this one connects to
    public nodeScript next;
    // will return the next node
    public nodeScript GetNext()
    {
        return next;
    }
    // a callback function that gets called when its time to draw gizmos
    private void OnDrawGizmos()
    {
        if (next == null)
            return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, next.transform.position);
    }
}
