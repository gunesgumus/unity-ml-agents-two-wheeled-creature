using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody)), DisallowMultipleComponent]
public class TrackedRigidbody : MonoBehaviour
{
	[SerializeField]
	bool trackLocalPosition = true;
	[SerializeField]
	bool trackVelocity = true;
	[SerializeField]
	bool trackLocalRotation = true;
	[SerializeField]
	bool trackAngularVelocity = true;

	Rigidbody body;

	private void Awake()
	{
		this.body = this.GetComponent<Rigidbody>();
	}

	public List<float> GetTrackedValues()
	{
		List<float> result = new List<float>();

		if (this.trackLocalPosition)
		{
			result.Add(this.transform.localPosition.x);
			result.Add(this.transform.localPosition.y);
			result.Add(this.transform.localPosition.z);
		}

		if (this.trackVelocity)
		{
			result.Add(this.body.velocity.x);
			result.Add(this.body.velocity.y);
			result.Add(this.body.velocity.z);
		}

		if (this.trackLocalRotation)
		{
			result.Add(this.transform.localRotation.x);
			result.Add(this.transform.localRotation.y);
			result.Add(this.transform.localRotation.z);
			result.Add(this.transform.localRotation.w);
		}

		if (this.trackAngularVelocity)
		{
			result.Add(this.body.angularVelocity.x);
			result.Add(this.body.angularVelocity.y);
			result.Add(this.body.angularVelocity.z);
		}

		return result;
	}
}
