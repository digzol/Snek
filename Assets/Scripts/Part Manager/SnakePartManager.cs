using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakePartManager : PartManager
{
    [Header("Snake Parts")]
    public GameObject oddSegmentPrefab;
    public GameObject evenSegmentPrefab;
    public int oddSegmentFrequency = 4;
    public int oddSegmentOffset = 2;
    public float growSpeed = 0.5f;

    public void Grow()
    {
        var tailJoint = Tail.GetComponent<SegmentJoint>();
        var isOddSegment = (parts.Count + oddSegmentOffset) % oddSegmentFrequency == 0;
        var newSegPrefab = isOddSegment ? evenSegmentPrefab : oddSegmentPrefab;
        var prevJoint = tailJoint.ConnectedSegment;
        var newSeg = Instantiate(newSegPrefab, prevJoint.position, Quaternion.identity, gameObject.transform);
        var newJoint = newSeg.transform.Find("Joint");

        newSeg.GetComponent<SegmentJoint>().ConnectedSegment = prevJoint;
        tailJoint.ConnectedSegment = newJoint;

        StartCoroutine(nameof(AnimGrow), newSeg);

        parts.Insert(parts.Count - 1, newSeg);
    }

    private IEnumerator AnimGrow(GameObject segment)
    {
        var from = new Vector2(0, 0);
        var to = new Vector2(1, 1);
        var t = 0.0f;
        while (t < 1.0f)
        {
            t += Time.deltaTime * growSpeed;
            var step = Mathf.SmoothStep(0, 1.0f, t);
            segment.transform.localScale = Vector2.Lerp(from, to, step);
            yield return null;
        }
    }
}