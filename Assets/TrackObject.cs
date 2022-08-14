// COMP30019 - Graphics and Interaction
// (c) University of Melbourne, 2022

using UnityEngine;

public class TrackObject : MonoBehaviour
{
    [SerializeField] private GameObject target;

    // Note that *late* update is used to ensure the most recent position of the
    // object being tracked is used. Otherwise the camera can lag behind the
    // tracked object by a frame.
    private void LateUpdate()
    {
        var lookVec = this.target.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(lookVec, Vector3.up);

        // An alternative, even simpler solution (which essentially does the 
        // same thing internally):
        //
        // this.transform.LookAt(objectToTrack.transform);
    }
}
