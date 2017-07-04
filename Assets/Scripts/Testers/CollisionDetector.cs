using UnityEngine;
using UnityEngine.AI;

namespace Testers
{
    public class CollisionDetector : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Agent"))
            {
                NavMeshAgent nMA = other.GetComponent<NavMeshAgent>();
                if (nMA != null)
                {
                    if (nMA.obstacleAvoidanceType.Equals(ObstacleAvoidanceType.NoObstacleAvoidance))
                    {
                        CollisionCounter.Counter++;
                    }
                }
            }
        }
    } 
}
