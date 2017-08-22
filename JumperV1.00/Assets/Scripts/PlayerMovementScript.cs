using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerMovementScript : MonoBehaviour {

    Rigidbody rb;
    public Boundary b;

    public float speed = 10.0f;
    public float jumpheight = 5.0f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    private void Update()
    {

    }
    void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement * speed;

        rb.position = new Vector3(Mathf.Clamp(rb.position.x, b.xMin, b.xMax), 0.0f,
                                  Mathf.Clamp(rb.position.z,b.zMin,b.zMax));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(0.0f, 10 * jumpheight * Time.deltaTime, 0.0f);
        }
    }
}
