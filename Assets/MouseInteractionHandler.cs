using UnityEngine;
using System.Collections;
using System.Linq;

public class MouseInteractionHandler : MonoBehaviour
{
    public Transform tower;

    HitHelper hitHelper;

    // Use this for initialization
    void Start ()
    {
        hitHelper = new HitHelper();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))  // left mouse button
        {
            var hitInfo = hitHelper.GetHitInfo();
            if (hitInfo != null)
            {
                var towerToPlace = Instantiate(tower);
                towerToPlace.transform.position = hitInfo.Value.point;
				// Parent it to the stage transform so it does move with it !
				towerToPlace.transform.parent = this.transform;
            }
        }

        if (Input.GetMouseButtonDown(1))  // right mouse button
        {
            var hitInfo = hitHelper.GetHitInfo();
            if (hitInfo != null)
            {
                if (hitInfo.Value.transform.tag == "Tower")
                {
                    var exploders = hitInfo.Value.transform.gameObject.GetComponentsInChildren<MeshExploder>();
                    if (exploders != null && exploders.Any())
                    {
                        foreach (var meshExploder in exploders)
                        {
                            meshExploder.Explode();
                        }
                    }
                    Destroy(hitInfo.Value.transform.gameObject);
                    var exploder = hitInfo.Value.transform.gameObject.GetComponent<MeshExploder>();
                    if (exploder != null)
                        exploder.Explode();
                }
            }
        }
	}
}
