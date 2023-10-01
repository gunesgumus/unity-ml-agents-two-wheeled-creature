using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents.Sensors;
using UnityEngine;

namespace GNMS.TwoWheeledCreature
{
	[RequireComponent(typeof(Rigidbody)), DisallowMultipleComponent]
	public class ObservedRigidbody : ObservationProvider
	{
		[SerializeField]
		bool trackPosition = true;
		[SerializeField]
		bool trackRotation = true;
		[SerializeField]
		bool trackLocalPosition = true;
		[SerializeField]
		bool trackLocalRotation = true;
		[SerializeField]
		bool trackVelocity = true;
		[SerializeField]
		bool trackAngularVelocity = true;

		Rigidbody body;

		public override int ObservationSpaceSize
		{
			get
			{
				int spaceSize = 0;
				if (this.trackPosition)
				{
					spaceSize += 3;
				}
				if (this.trackRotation)
				{
					spaceSize += 4;
				}
				if (this.trackLocalPosition)
				{
					spaceSize += 3;
				}
				if (this.trackLocalRotation)
				{
					spaceSize += 4;
				}
				if (this.trackVelocity)
				{
					spaceSize += 3;
				}
				if (this.trackAngularVelocity)
				{
					spaceSize += 3;
				}
				return spaceSize;
			}
		}

		private void Awake()
		{
			this.body = this.GetComponent<Rigidbody>();
		}

		public override void AddObservations(VectorSensor sensor)
		{
			if (this.trackPosition)
			{
				sensor.AddObservation(this.body.position);
			}
			if (this.trackRotation)
			{
				sensor.AddObservation(this.body.rotation);
			}
			if (this.trackLocalPosition)
			{
				sensor.AddObservation(this.transform.localPosition);
			}
			if (this.trackLocalRotation)
			{
				sensor.AddObservation(this.transform.localRotation);
			}
			if (this.trackVelocity)
			{
				sensor.AddObservation(this.body.velocity);
			}
			if (this.trackAngularVelocity)
			{
				sensor.AddObservation(this.body.angularVelocity);
			}
		}
	}
}