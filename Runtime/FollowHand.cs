using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHand : MonoBehaviour
{
	public Transform _handTransform;

	private void Update()
	{
		gameObject.transform.position = _handTransform.position;
	}

}
