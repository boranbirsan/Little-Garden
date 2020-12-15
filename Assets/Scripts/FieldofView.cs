using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldofView : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;
    public int rayCount = 20;

    public LayerMask m_layerMask;
    private Vector2 direction = Vector2.zero;

    public Vector2 FindPath()
    {
        float angles = viewAngle / rayCount;
        RaycastHit hitInfo;

        for (int i = 0; i < rayCount; i++)
        {
            Vector3 posRayAngle = DirFromAngle(i * angles / 2, false);

            RaycastHit2D hitA = Physics2D.Raycast(transform.position, posRayAngle.normalized, viewRadius, m_layerMask);

            if (hitA.collider == null)
            {
                Debug.DrawLine(transform.position, transform.position + posRayAngle * viewRadius, Color.green);
                return (Vector2) posRayAngle.normalized;
                break;
            }
            else
            {
                Debug.DrawLine(transform.position, transform.position + posRayAngle * viewRadius, Color.red);
            }

            Vector3 negRayAngle = DirFromAngle(-i * angles / 2, false);
            RaycastHit2D hitB = Physics2D.Raycast(transform.position, negRayAngle.normalized, viewRadius, m_layerMask);

            if (hitB.collider == null)
            {
                Debug.DrawLine(transform.position, transform.position + negRayAngle * viewRadius, Color.green);
                return (Vector2) negRayAngle.normalized;
                break;
            }
            else
            {
                Debug.DrawLine(transform.position, transform.position + negRayAngle * viewRadius, Color.red);
            }
        }

        return direction;
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.z;
        }
        return new Vector3(Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0);
    }

    public void ChangeDirection(Vector2 dir)
    {
        transform.right = dir.normalized;
    }
}
