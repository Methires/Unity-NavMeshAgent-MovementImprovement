using UnityEngine;
using UnityEngine.AI;

public static class RandomPointOnNavMeshGetter
{
    public static Vector3 FindPointWithUnitSphere(Vector3 areaCenter)
    {
        Vector3 point = areaCenter;
        NavMeshHit hit;
        bool result;
        do
        {
            point = areaCenter + Random.insideUnitSphere * GlobalVariables.SPHERE_RANGE;
            result = NavMesh.SamplePosition(point, out hit, GlobalVariables.NAVMESH_SAMPLER_MAX_DISTANCE, NavMesh.AllAreas);
            if (result)
            {
                point = hit.position;
            }
        }
        while (!result);

        return point;
    }
}
