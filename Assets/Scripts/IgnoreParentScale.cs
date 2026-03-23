using UnityEngine;

public class IgnoreParentScale : MonoBehaviour
{
    void LateUpdate()
    {
        Vector3 parentScale = transform.parent.lossyScale;

        transform.localScale = new Vector3(
            1f / parentScale.x,
            1f / parentScale.y,
            1f / parentScale.z
        );
    }
}
