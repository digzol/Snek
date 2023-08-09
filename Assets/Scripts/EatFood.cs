using UnityEngine;

public class EatFood : MonoBehaviour
{
    private SnakePartManager _partManager;

    private void Start()
    {
        _partManager = transform.parent.GetComponent<SnakePartManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var foodUnit = other.GetComponent<FoodUnit>();

        if (foodUnit == null) return;

        _partManager.Grow();
        foodUnit.Consume();
    }
}
