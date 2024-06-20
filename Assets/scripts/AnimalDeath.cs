using UnityEngine;
using System.Collections;

public class AnimalDeath : MonoBehaviour
{
	public float deathAnimationDuration = 2f; // Duration of the death animation

	public void Die()
	{
		// Play the death animation
		Animator animator = GetComponent<Animator>();
		if (animator != null)
		{
			animator.SetTrigger("Die");
		}

		// Start the coroutine to destroy the GameObject after the animation
		StartCoroutine(HandleDeath());
	}

	private IEnumerator HandleDeath()
	{
		// Wait for the duration of the death animation
		yield return new WaitForSeconds(deathAnimationDuration);

		// Destroy the GameObject
		Destroy(gameObject);
	}
}
