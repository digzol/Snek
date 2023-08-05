using UnityEngine;

public abstract class MovementAnimator : MonoBehaviour
{
    [SerializeField]
    private Vector2 targetPos;

    public bool lockedTarget;

    public Vector2 TargetPos
    {
        get => targetPos;
        set
        {
            if (!lockedTarget) targetPos = value;
        }
    }
}