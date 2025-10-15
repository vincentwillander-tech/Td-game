using UnityEditor;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform turrentRotationPoint;
    [SerializeField] private LayerMask enemyMask;

    [Header("Attribute")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float rotationSpeed = 5f;


    private Transform target;

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }
        RotateTowardsTarget();
        if (!CheckTargetIsInRange())
        {
            target = null;
        }
    }
    void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)
        transform.position, 0f, enemyMask);
        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }
    bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }
    void RotateTowardsTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) - Mathf.PI / 2;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        //turrentRotationPoint.rotation = targetRotation;
        turrentRotationPoint.rotation = Quaternion.RotateTowards(turrentRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
    void OnDrawGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);

    }
}
