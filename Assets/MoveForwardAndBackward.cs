// COMP30019 - Graphics and Interaction
// (c) University of Melbourne, 2022

using UnityEngine;

public class MoveForwardAndBackward : MonoBehaviour
{
    [SerializeField] private float thresholdDistance;
    [SerializeField] private float speed;

    private int _dir = 1; // Either 1 or -1 depending on the movement direction

    private void Update()
    {
        transform.localPosition +=
            Vector3.forward * (Time.deltaTime * this.speed * this._dir);
        
        // Switch direction if past a particular threshold in the z-axis
        if (transform.localPosition.z > this.thresholdDistance)
            this._dir = -1;
        else if (transform.localPosition.z < 0.0f) 
            this._dir = 1;
        
        // Is there an easier way to do this if using "total" time instead?
    }
}
