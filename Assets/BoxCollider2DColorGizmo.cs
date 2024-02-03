using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class BoxCollider2DSizeGizmo : MonoBehaviour
{
    private BoxCollider2D boxCollider;

    private void OnDrawGizmos()
    {
        if (boxCollider == null)
        {
            boxCollider = GetComponent<BoxCollider2D>();
        }

        Vector3 center = transform.position + (Vector3)boxCollider.offset;
        Vector3 size = new Vector3(boxCollider.size.x * transform.localScale.x, boxCollider.size.y * transform.localScale.y, 0.1f);

        Gizmos.color = new Color(0, 1, 0, 0.1f);
        Gizmos.DrawCube(center, size);

        Gizmos.color = new Color(0, 1, 0, 0.1f);
        Gizmos.DrawCube(center, Vector3.one);

        Gizmos.color = new Color(0, 1, 0, 0.1f); ;
        Gizmos.DrawCube(center, Vector3.one * 0.1f);

        Gizmos.color = new Color(0,1,0,0.1f);
        Gizmos.DrawCube(center, new Vector3(boxCollider.size.x * transform.localScale.x, boxCollider.size.y * transform.localScale.y, 0.1f));
    }
}