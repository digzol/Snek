using UnityEngine;
using UnityEngine.Serialization;

public class MoveBackground : MonoBehaviour
{
    public float errorCorrection = 1;

    [SerializeField]
    private Transform background;

    private void Update()
    {
        var bg = background.GetComponent<SpriteRenderer>().bounds;

        var maxXOffset = bg.size.x / 2 - Camera.main.orthographicSize * Camera.main.aspect - errorCorrection;
        var maxYOffset = bg.size.y / 2 - Camera.main.orthographicSize - errorCorrection;

        var relativePosition = transform.position - background.position;

        if (Mathf.Abs(relativePosition.x) >= maxXOffset || Mathf.Abs(relativePosition.y) >= maxYOffset)
            background.position = new Vector3(transform.position.x, transform.position.y, background.position.z);
    }
}
