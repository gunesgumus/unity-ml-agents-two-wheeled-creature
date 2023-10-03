using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine;

namespace GNMS.TwoWheeledCreature.Learning
{
	public abstract class ObservationProvider : MonoBehaviour
	{
		public abstract int ObservationSpaceSize { get; }

		public abstract void AddObservations(VectorSensor sensor);
	}
}