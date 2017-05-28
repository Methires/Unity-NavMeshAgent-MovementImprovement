using UnityEngine;
using UnityEngine.AI;

public static class RandomPointOnNavMeshGetter
{
    public static Vector3 FindPoint()
    {
        Vector3 point = Vector3.zero;
        NavMeshHit hit;
        bool result;
        do
        {
            point = Vector3.zero + Random.insideUnitSphere * GlobalVariables.AREA_RANGE;
            result = NavMesh.SamplePosition(point, out hit, 0.5f, NavMesh.AllAreas);
            if (result)
            {
                point = hit.position;
            }
        }
        while (!result);

        return point;
    }
}
