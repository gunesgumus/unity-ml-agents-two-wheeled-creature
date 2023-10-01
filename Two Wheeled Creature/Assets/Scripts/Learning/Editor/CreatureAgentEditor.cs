using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

namespace GNMS.TwoWheeledCreature
{
	[CustomEditor(typeof(CreatureAgent))]
	public class CreatureAgentEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			CreatureAgent creatureAgent = target as CreatureAgent;

			DrawDefaultInspector();

			if (GUILayout.Button("Refresh Observation Providers"))
			{
				creatureAgent.RefreshObservationProviders();
			}

			if (GUILayout.Button("Refresh Action Receivers"))
			{
				creatureAgent.RefreshActionReceivers();
			}

			if (GUILayout.Button("Refresh Reward Providers"))
			{
				creatureAgent.RefreshRewardProviders();
			}
		}
	}
}