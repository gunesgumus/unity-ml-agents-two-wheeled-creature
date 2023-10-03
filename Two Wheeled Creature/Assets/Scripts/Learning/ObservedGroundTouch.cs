using GNMS.TwoWheeledCreature.Physics;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents.Sensors;
using UnityEngine;

namespace GNMS.TwoWheeledCreature.Learning
{
	public class ObservedGroundTouch : ObservationProvider
	{
		Ground groundInTouch = null;

		bool IsGrounded => this.groundInTouch != null;

		public override int ObservationSpaceSize => 1;

		public override void AddObservations(VectorSensor sensor)
		{
			sensor.AddObservation(this.IsGrounded);
		}

		private void OnCollisionEnter(Collision collision)
		{
			Ground ground = collision.collider.GetComponent<Ground>();
			if (ground != null)
			{
				this.groundInTouch = ground;
			}
		}

		private void OnCollisionExit(Collision collision)
		{
			Ground ground = collision.collider.GetComponent<Ground>();
			if (ground == this.groundInTouch)
			{
				this.groundInTouch = null;
			}
		}


	}
}