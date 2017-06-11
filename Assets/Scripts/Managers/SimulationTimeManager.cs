using UnityEngine;
using System.Collections;

namespace Managers
{
    public class SimulationTimeManager : MonoBehaviour
    {
        private float _time;

        public float TestTime
        {
            get
            {
                return _time;
            }
            set
            {
                _time = value;
            }
        }

        private void Update()
        {
            _time += Time.deltaTime;
        }

    } 
}
