using UnityEngine;

public class Script_Task4_Sphere : MonoBehaviour
{
    public Transform objective;
    public float speed = 5.0f;
    private Vector3 moveVector;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) {
            Debug.LogError("Error: GameObject has no Rigidbody!");
        }
        if (objective == null) {
            Debug.LogError("Error: GameObject has no objective!");
        }
    }

    void Update()
    {
        if (objective == null) { return; }
    }

    void FixedUpdate()
    {
        if (rb == null) { return; }
        moveVector = speed * (objective.position - transform.position).normalized;
        rb.AddForce(moveVector);
    }
}
