using UnityEngine;
using UnityEngine.AI;

namespace Agents
{
    public class SimpleAgentMover : MonoBehaviour
    {
        public Vector3 AreaCenter;

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
            result = _nMA.SetDestination(RandomPointOnNavMeshGetter.FindPointWithUnitSphere(AreaCenter));
            Debug.Log(result ? "OK" : "Setting point failed");
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Agent"))
            {
                Debug.Log("DUPA!");
            }
        }
    } 
}
