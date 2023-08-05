using UnityEngine;

public class FoodUnit : MonoBehaviour {
    public float AnimOutSpeed = 5.0f;

    private bool _isConsumed = false;

    public void ConsumeFood() {
        if (_isConsumed) return;
        _isConsumed = true;
    }

    private void Update() {
        if (_isConsumed) {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, AnimOutSpeed * Time.deltaTime);
        }
        
        if (transform.localScale == Vector3.zero) {
            Destroy(transform.parent.gameObject);
        }
    }
}
