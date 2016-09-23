using UnityEngine;
using UnityEngine.VR;

public class HitHelper
{
    public RaycastHit? GetHitInfo()
    {
        if (VRDevice.isPresent)
        {
            RaycastHit hitInfo;

            var headPosition = Camera.main.transform.position;
            var gazeDirection = Camera.main.transform.forward;

            if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
                return hitInfo;
        }
        else
        {
            RaycastHit hitInfo;
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo))
                return hitInfo;
            
        }
        return null;
    }
}
