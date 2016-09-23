using UnityEngine;
using UnityEngine.VR;

public class WorldCursor : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    public Material HitMaterial;

    public Material NotHitMaterial;

    private HitHelper hitHelper;

    // Use this for initialization
    void Start()
    {
        // Grab the mesh renderer that's on the same object as this script.
        meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
        hitHelper = new HitHelper();
    }

    // Update is called once per frame
    void Update()
    {
        var hitInfo = hitHelper.GetHitInfo();
        if (hitInfo != null)
        {
            ShowHitCursor(hitInfo.Value);
        }
        else
        {
            HideCursor();
        }
    }

    private void ShowHitCursor(RaycastHit hitInfo)
    {
        // If the raycast hit a hologram...display the cursor mesh.
        meshRenderer.enabled = true;
        meshRenderer.material = HitMaterial;

        // Move thecursor to the point where the raycast hit.
        this.transform.position = hitInfo.point;

        // Rotate the cursor to hug the surface of the hologram.
        this.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
    }

    private void HideCursor()
    {
        // If the raycast did not hit a hologram, hide the cursor mesh.
        meshRenderer.enabled = false;

        // or show i a different color
        //this.transform.position = headPosition + gazeDirection * 5;
        //meshRenderer.material = NotHitMaterial;
        //this.transform.rotation = Quaternion.identity;
    }
}
 