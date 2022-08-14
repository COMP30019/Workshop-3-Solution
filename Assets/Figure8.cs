// COMP30019 - Graphics and Interaction
// (c) University of Melbourne, 2022

using UnityEngine;

public class Figure8 : MonoBehaviour
{
    [SerializeField] private float spinSpeed;
    [SerializeField] private GameObject pivotA;
    [SerializeField] private GameObject pivotB;

    private void Update()
    {
        // A figure 8 is really just two 360 degree orbits which alternate.
        // In some senses the full motion can be thought of as "720" degrees.

        // Note: Using "total" time to compute the angle on a given frame.
        var angle = this.spinSpeed * Time.time;
        var axis = new Vector3(0.0f, 1.0f, 0.0f);
        var rotation = Quaternion.AngleAxis(angle, axis);

        // Each pivot rotates at the same rate, but in opposite directions.
        this.pivotA.transform.localRotation = rotation;
        this.pivotB.transform.localRotation = Quaternion.Inverse(rotation);

        // Pivot should switch every 360 degrees (use simple modulo arithmetic).
        var currentPivot = Mathf.FloorToInt(angle / 360.0f) % 2 == 0
            ? this.pivotA
            : this.pivotB;

        // Set correct parent, corresponding to current pivot.
        // Important: worldPositionStays is set to false (see reasoning below).
        transform.SetParent(currentPivot.transform, false);

        // We ensure local position is offset since we set worldPositionStays
        // to false above. Manually controlling this avoids framerate related
        // instability that could occur (the cube won't necessarily be *exactly*
        // at the "meeting point" when the phase switch occurs). 
        transform.localPosition = -currentPivot.transform.localPosition;
    }
}
