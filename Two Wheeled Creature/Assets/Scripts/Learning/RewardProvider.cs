using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using UnityEngine;

namespace GNMS.TwoWheeledCreature
{
	public abstract class RewardProvider : MonoBehaviour
	{
		/// <summary>
		/// Rewards the agent.
		/// </summary>
		/// <param name="agent">Agent to reward.</param>
		/// <returns>True if the reward was additive so more reward/penalty can be given in the related step, false if the reward was set to an exact value.</returns>
		public abstract bool RewardAgent(Agent agent);
	}
}