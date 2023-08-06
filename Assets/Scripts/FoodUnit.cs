using UnityEngine;
using UnityEngine.Serialization;

public class FoodUnit : MonoBehaviour
{
    public float animOutSpeed = 5.0f;

    private bool _isConsumed;

    private void Update()
    {
        if (_isConsumed)
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, animOutSpeed * Time.deltaTime);

        if (transform.localScale == Vector3.zero) Destroy(transform.parent.gameObject);
    }

    public void ConsumeFood()
    {
        if (_isConsumed) return;
        _isConsumed = true;
    }
}
