using UnityEngine;

public class FollowMouseAI : MonoBehaviour
{
    public float minDistanceSmoothing = 5.0f;

    private Camera _mainCam;
    private MovementAnimator _movementAnimator;
    private PartManager _partManager;

    private void Start()
    {
        _mainCam = Camera.main;
        _partManager = gameObject.GetComponent<PartManager>();
        _movementAnimator = gameObject.GetComponent<MovementAnimator>();
    }

    private void Update()
    {
        var mousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition);
        var playerPos = _partManager.HeadPos;
        var dist = Vector2.Distance(mousePos, playerPos);

        if (dist < minDistanceSmoothing)
            //_movementAnimator.TargetPos = (mousePos + playerPos) / 2;
            _movementAnimator.TargetPos = mousePos;
        else
            _movementAnimator.TargetPos = mousePos;
    }
}