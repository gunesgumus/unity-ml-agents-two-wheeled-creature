using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents.Actuators;
using UnityEngine;

namespace GNMS.TwoWheeledCreature
{
	public abstract class ActionReceiver : MonoBehaviour
	{
		public abstract int ContinuousActionSpaceSize { get; }
		public abstract int[] DiscreteActionBranchSizes { get; }

		public virtual void OnActionReceived(ActionBuffers actions, ref int continuousActionIndex, ref int discreteActionIndex)
		{
			float[] continuousActions = new float[this.ContinuousActionSpaceSize];
			int[] discreteActions = new int[this.DiscreteActionBranchSizes.Length];

			for (int thisContinuousIndex = 0; thisContinuousIndex < this.ContinuousActionSpaceSize; thisContinuousIndex++)
			{
				continuousActions[thisContinuousIndex] = actions.ContinuousActions[continuousActionIndex];
				continuousActionIndex++;
			}

			for (int thisDiscreteIndex = 0; thisDiscreteIndex < this.DiscreteActionBranchSizes.Length; thisDiscreteIndex++)
			{
				discreteActions[thisDiscreteIndex] = actions.DiscreteActions[discreteActionIndex];
				discreteActionIndex++;
			}

			this.Act(continuousActions, discreteActions);
		}

		public abstract void Act(float[] continuousActions, int[] discreteActions);
	}
}