using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GNMS.TwoWheeledCreature.Learning
{
	public class EpisodeBeginHandlerRigidbody : EpisodeBeginHandler
	{
		Rigidbody body;

		Vector3 initialLocalPosition;
		Quaternion initialLocalRotation;

		private void Awake()
		{
			this.body = this.GetComponent<Rigidbody>();
			this.initialLocalPosition = this.transform.localPosition;
			this.initialLocalRotation = this.transform.localRotation;
		}

		public override void HandleEpisodeBegin()
		{
			this.transform.localPosition = this.initialLocalPosition;
			this.transform.localRotation = this.initialLocalRotation;
			this.body.velocity = Vector3.zero;
			this.body.angularVelocity = Vector3.zero;
		}
	}
}