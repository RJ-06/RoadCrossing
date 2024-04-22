using UnityEngine;

public class NodeController : MonoBehaviour
{
    public int row; // Row position in the grid
    public int column; // Column position in the grid
    public ScanArea gridManager; // Reference to the ScanArea script
    public bool hit;
    private Material originalMaterial; // Original material of the sphere
    private Renderer renderer; // Reference to the renderer component
    Material nodeMatDeactive;
    Material nodeMatActive;

    public void Init(Material ActiveMat, Material DeactiveMat, ScanArea gm, int row, int col)
    {
        gridManager = gm;
        nodeMatDeactive = DeactiveMat;
        nodeMatActive = ActiveMat;

        this.row = row;
        this.column = col;

        hit = false;

        // Get the renderer component
        renderer = GetComponent<Renderer>();

        // Store the original material of the sphere
        renderer.material = nodeMatDeactive;
        renderer.receiveShadows = false;
        renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
    }

    private void Update()
    {
        if (!gridManager.hitNodes[row, column])
        {
            renderer.material = nodeMatDeactive;
            hit = false;
        }
        if(gridManager.enoughGridFilled)
        {
            renderer.enabled = false;
        }
    }

    public void OnRaycastHit()
    {
        if(hit) return;
        hit = true;
        // Mark the node as hit in the boolean array
        gridManager.hitNodes[row, column] = true;

        // Change the material color to green
        renderer.material = nodeMatActive;
    }
}
