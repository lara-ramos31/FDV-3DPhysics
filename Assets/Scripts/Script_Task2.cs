using UnityEngine;

public class Script_Task2 : MonoBehaviour
{
    public float baseForce = 6.7f;
    public float boostForce = 15f;
    private Vector3 moveVector;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null) {
            Debug.LogError("Error: GameObject has no Rigidbody!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float forward = Input.GetAxis("Vertical");
        float sideways = Input.GetAxis("Horizontal");
        float currentForce = Input.GetKey(KeyCode.Space) ? boostForce : baseForce;
        moveVector.Set(currentForce * sideways, 0, currentForce * forward);
    }

    void FixedUpdate()
    {
        if (rb == null) { return; }
        rb.AddForce(moveVector);
    }
}
