using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class FoodParticleAnim : MonoBehaviour
{
    public float moveRange = 2.0f;

    public float moveSpeed = 1.0f;

    private void Start()
    {
        StartCoroutine(nameof(Animate));
    }

    private IEnumerator Animate()
    {
        for (;;)
        {
            var prevPos = transform.localPosition;
            var targetPos = GetRandomTargetPos();
            var t = 0.0f;
            var rate = 1.0f / moveSpeed;

            while (t < 1.0f)
            {
                t += Time.deltaTime * rate;
                var step = Mathf.SmoothStep(0, 1.0f, t);
                transform.localPosition = Vector2.Lerp(prevPos, targetPos, step);
                yield return null;
            }
        }
    }

    private Vector2 GetRandomTargetPos()
    {
        return new Vector2(Random.Range(-moveRange, moveRange), Random.Range(-moveRange, moveRange));
    }
}
