using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

namespace GNMS.TwoWheeledCreature.Learning.ForwardMovement
{
	[RequireComponent(typeof(Rigidbody)), DisallowMultipleComponent()]
	public class ForwardMovementRewardProvider : RewardProvider
	{
		Rigidbody body;

		private void Awake()
		{
			this.body = this.GetComponent<Rigidbody>();
		}

		public override bool RewardAgent(Agent agent)
		{
			// Reward for moving forward while standing straight and looking forward
			agent.AddReward(0.01f * Vector3.Dot(this.body.velocity, Vector3.forward)
				* Vector3.Dot(this.transform.forward, Vector3.up)
				* Vector3.Dot(this.transform.up, Vector3.forward));
			return true;
		}
	}
}