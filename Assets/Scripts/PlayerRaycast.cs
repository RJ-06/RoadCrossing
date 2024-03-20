using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    public Transform orientation; // Reference to the orientation of the player

    void Update()
    {
        ShootRaycast();
    }

    void ShootRaycast()
    {
        // Check if the orientation is set
        if (orientation == null)
        {
            Debug.LogWarning("Orientation not found!");
            return;
        }

        // Get the direction based on the orientation of the player
        Vector3 raycastDirection = orientation.forward;
        Debug.Log(orientation.forward);
        // Perform the raycast
        RaycastHit hit;
        if (Physics.Raycast(orientation.position, raycastDirection, out hit, Mathf.Infinity, LayerMask.GetMask("RaycastNode")))
        {
            // Check if the hit object has the ScanAreaNode script attached
            NodeController scanAreaNode = hit.transform.GetComponent<NodeController>();
            if (scanAreaNode != null)
            {
                // Call the OnRaycastHit function of the ScanAreaNode
                scanAreaNode.OnRaycastHit();
            }
        }
    }
}
