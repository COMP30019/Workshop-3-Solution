// COMP30019 - Graphics and Interaction
// (c) University of Melbourne, 2022

using UnityEngine;

public class CubeControllerWithAcceleration : MonoBehaviour
{
    [SerializeField] private float accelerationFactor;

    private Vector3 _velocity = Vector3.zero;

    // Update is called once per frame
    private void Update()
    {
        float dx = 0.0f, dz = 0.0f;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Debug.Log("RightArrow");
            dx += 1.0f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Debug.Log("LeftArrow");
            dx -= 1.0f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("UpArrow");
            dz += 1.0f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("DownArrow");
            dz -= 1.0f;
        }

        this._velocity += new Vector3(dx, 0.0f, dz) * 
                          (this.accelerationFactor * Time.deltaTime);

        transform.localPosition += this._velocity * Time.deltaTime;
    }
}
