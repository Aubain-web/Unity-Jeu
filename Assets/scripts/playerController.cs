using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
	[SerializeField]
	private Vector3 deplacement = Vector3.zero;

	private float speed = 5f, rot = 80f, rotSensitivity = 2f, curSpeed;

	void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.LeftControl))
		{
			curSpeed = speed * 2;
		}
		else
		{
			curSpeed = speed;
		}

		transform.Rotate(Vector3.up * rot * rotSensitivity * Time.fixedDeltaTime * Input.GetAxis("Horizontal"));
		transform.Translate(Vector3.forward * curSpeed * Time.fixedDeltaTime * Input.GetAxis("Vertical"));
	}
}
