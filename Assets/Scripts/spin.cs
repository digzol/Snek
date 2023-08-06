using UnityEngine;
using UnityEngine.Serialization;

public class Spin : MonoBehaviour
{
    public float speedMin = 5.0f;

    public float speedMax = 200.0f;

    public float multiplier = 1.0f;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, Random.Range(speedMin, speedMax) * multiplier * Time.deltaTime));
    }
}
