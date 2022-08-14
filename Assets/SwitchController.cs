// COMP30019 - Graphics and Interaction
// (c) University of Melbourne, 2022

using UnityEngine;

[RequireComponent(typeof(CubeController))]
[RequireComponent(typeof(CubeControllerWithAcceleration))]
public class SwitchController : MonoBehaviour
{
    [SerializeField] private Material movementMaterial;
    [SerializeField] private Material accelerationMaterial;
    
    private CubeController _controller;
    private CubeControllerWithAcceleration _controllerAcc;

    private MeshRenderer _meshRenderer;

    private void Start()
    {
        // It's more efficient to store the results of GetComponent() within the
        // Start() method, rather than repeatedly calling it in Update() on
        // every frame.
        
        this._controller = gameObject.GetComponent<CubeController>();
        this._controller.enabled = true;
        
        this._controllerAcc = 
            gameObject.GetComponent<CubeControllerWithAcceleration>();
        this._controllerAcc.enabled = false;
        
        this._meshRenderer = gameObject.GetComponent<MeshRenderer>();
        this._meshRenderer.material = this.movementMaterial;
    }

    private void Update()
    {
        // We use the "down" variant of GetKey so that this only executes *once*
        // at the start of the key press (e.g. not switching every frame!)
        if (Input.GetKeyDown(KeyCode.S))
        {
            // Swap the script
            this._controller.enabled = !this._controller.enabled;
            this._controllerAcc.enabled = !this._controllerAcc.enabled;
            Debug.Log(this._controller.enabled
                ? "Step Enabled"
                : "Accelerate Enabled");
            
            // Change the material
            this._meshRenderer.material = this._controller.enabled
                ? this.movementMaterial
                : this.accelerationMaterial;
        }
    }
}
