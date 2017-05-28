using UnityEngine;
using UnityEngine.AI;

namespace Agent
{
    public class SimpleAgentMover : MonoBehaviour
    {
        private NavMeshAgent _nMA;

        private void Awake()
        {
            _nMA = GetComponent<NavMeshAgent>();
            _nMA.updateRotation = GlobalVariables.UPDATE_ROTATION;
            _nMA.stoppingDistance = GlobalVariables.STOPPING_DISTANCE;
        }

        private void Start()
        {
            SetNewDestination();
        }

        private void Update()
        {
            if (_nMA.remainingDistance <= GlobalVariables.STOPPING_DISTANCE && _nMA.pathStatus.Equals(NavMeshPathStatus.PathComplete))
            {
                Debug.Log("Reached goal");
                Debug.Log("Setting new destination");
                SetNewDestination();
            }
        }

        private void SetNewDestination()
        {
            bool result;
            result = _nMA.SetDestination(RandomPointOnNavMeshGetter.FindPoint());
            Debug.Log(result ? "OK" : "Setting point failed");
        }
    } 
}
