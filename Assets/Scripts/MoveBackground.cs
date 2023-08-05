using UnityEngine;

public class MoveBackground : MonoBehaviour {
    public float ErrorCorrection = 1;
    
    [SerializeField]
    private Transform _background;
    
    private void Update() {
        var bg = _background.GetComponent<SpriteRenderer>().bounds;

        var maxXOffset = bg.size.x / 2 - Camera.main.orthographicSize * Camera.main.aspect - ErrorCorrection;
        var maxYOffset = bg.size.y / 2 - Camera.main.orthographicSize - ErrorCorrection;
        
        var relativePosition = transform.position - _background.position;
        
        if (Mathf.Abs(relativePosition.x) >= maxXOffset || Mathf.Abs(relativePosition.y) >= maxYOffset) {
            _background.position = new Vector3(transform.position.x, transform.position.y, _background.position.z);
        }
    }
}