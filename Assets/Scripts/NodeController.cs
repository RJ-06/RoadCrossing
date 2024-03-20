using UnityEngine;

public class NodeController : MonoBehaviour
{
    public int row; // Row position in the grid
    public int column; // Column position in the grid
    public ScanArea gridManager; // Reference to the ScanArea script
    public bool hit;
    private Material originalMaterial; // Original material of the sphere
    private Renderer renderer; // Reference to the renderer component

    void Awake()
    {
        hit = false;

        // Get the renderer component
        renderer = GetComponent<Renderer>();

        // Store the original material of the sphere
        originalMaterial = renderer.material;
    }

    public void OnRaycastHit()
    {
        if(hit) return;
        hit = true;
        // Mark the node as hit in the boolean array
        gridManager.hitNodes[row, column] = true;

        // Change the material color to green
        renderer.material.color = Color.green;

        Debug.Log("Hit!");
    }
}
