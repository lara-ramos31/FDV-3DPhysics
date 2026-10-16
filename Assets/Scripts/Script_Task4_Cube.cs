using UnityEngine;

public class Script_Task4_Cube : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody rb;
    private Renderer render;
    private Vector3 moveVector;
    private bool shouldMove = false;

    void Start()
    {
        moveVector = speed * Vector3.forward;
        rb = GetComponent<Rigidbody>();
        if (rb == null) {
            Debug.LogError("Error: GameObject has no Rigidbody!");
        }
        render = GetComponent<Renderer>();
        if (render == null) {
            Debug.LogError("Error: GameObject has no Renderer!");
        }
    }

    void FixedUpdate()
    {
        if (rb == null) { return; }
        if (shouldMove) {
            rb.MovePosition(transform.position + Time.fixedDeltaTime * moveVector);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        shouldMove = true;
        render.material.color = Random.ColorHSV();
        Debug.Log("Cube: I've been hit!");
    }
}
