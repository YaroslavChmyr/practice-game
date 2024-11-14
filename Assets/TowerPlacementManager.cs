using UnityEngine;

public class TowerPlacementManager : MonoBehaviour
{
    public GameObject towerPrefab; // The tower prefab to be placed
    public LayerMask placementMask; // Layer mask for valid placement areas
    public LayerMask obstructionMask; // Layer mask for areas where placement is blocked

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detect left mouse button click
        {
            Debug.Log("Test");
            PlaceTower();
        }
    }

    void PlaceTower()
    {
        // Get the mouse position in the world
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // Ensure the Z-coordinate is 0 for a 2D game
        // Instantiate(towerPrefab, mousePos, Quaternion.identity);

        // Check if the clicked position is valid for placing the tower
        if (IsPlacementValid(mousePos))
        {
            // Instantiate the tower at the clicked position
            Instantiate(towerPrefab, mousePos, Quaternion.identity);
        }
    }

    // Check if the placement position is valid
    bool IsPlacementValid(Vector3 position)
    {
        // Use Physics2D.OverlapCircle to check for valid placement (adjust the radius if needed)
        Collider2D hitCollider = Physics2D.OverlapCircle(position, 0.5f, placementMask);
        Collider2D obstructed = Physics2D.OverlapCircle(position, 0.5f, obstructionMask);
        Debug.Log(hitCollider);
        Debug.Log(obstructed);

        // Placement is valid if it's within the placement area and not obstructed
        return hitCollider != null && obstructed == null;
    }

    // Optional: Visualize the mouse position in the Scene view
    private void OnDrawGizmos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(mousePos, 0.5f);
    }
}

