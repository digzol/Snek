using System.Collections.Generic;
using UnityEngine;

public class PartManager : MonoBehaviour
{
    public List<GameObject> parts = new List<GameObject>();

    public GameObject Head
    {
        get => parts[0];
        set => parts[0] = value;
    }

    public GameObject Tail
    {
        get => parts[parts.Count - 1];
        set => parts[parts.Count - 1] = value;
    }

    public Vector3 HeadPos
    {
        get => parts[0].transform.position;
        set => parts[0].transform.position = value;
    }

    public Vector3 TailPos
    {
        get => parts[parts.Count - 1].transform.position;
        set => parts[parts.Count - 1].transform.position = value;
    }
}