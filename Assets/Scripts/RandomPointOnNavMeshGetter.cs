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

    public static Vector3 FindPointWithNumeralRange(Vector3 areaCenter, float areaSize)
    {
        Vector3 point = areaCenter;
        NavMeshHit hit;
        bool result;
        float halfAreaSize = areaSize / 2.0f;
        do
        {
            point  = areaCenter + new Vector3(Random.Range(-halfAreaSize, halfAreaSize), GlobalVariables.AGENT_Y_SPAWN_POS_OFFSET, Random.Range(-halfAreaSize, halfAreaSize));
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
