using UnityEngine;

namespace Moroshka.Protect.Samples
{
	public class BaseSample : MonoBehaviour
	{
		private void Start()
		{
			Debug.Log("=== Parameter validation examples ===");
			TestValidCalls();
			TestInvalidCalls();
		}

		private void TestValidCalls()
		{
			Debug.Log("--- Valid calls ---");
			CreatePlayer("Player", 5, 100f);
			Attack(50f, gameObject);
			AddItem("Sword");
			Debug.Log("✓ All valid calls completed successfully");
		}

		private void TestInvalidCalls()
		{
			Debug.Log("--- Invalid calls ---");

			try
			{
				CreatePlayer(string.Empty, 5, 100f);
			}
			catch (RequireException ex)
			{
				Debug.LogError(ex.ToString());
			}

			try
			{
				CreatePlayer("Player", -1, 100f);
			}
			catch (RequireException ex)
			{
				Debug.LogError(ex.ToString());
			}

			try
			{
				Attack(50f, null);
			}
			catch (RequireException ex)
			{
				Debug.LogError(ex.ToString());
			}

			try
			{
				AddItem(string.Empty);
			}
			catch (RequireException ex)
			{
				Debug.LogError(ex.ToString());
			}
		}

		private void CreatePlayer(string id, int level, float health)
		{
			this.Require(id, nameof(id), Is.Not.NullOrEmpty);
			this.Require(level, nameof(level), Is.InRange(1, 100));
			this.Require(health, nameof(health), Is.InRange(0f, 1000f));
			Debug.Log($"Player created: {id}, Level: {level}, Health: {health}");
		}

		private void Attack(float damage, GameObject target)
		{
			this.Require(damage, nameof(damage), Is.InRange(0f, 1000f));
			this.Require(target, nameof(target), Is.Not.Null);
			Debug.Log($"Attack! Damage: {damage}, Target: {target.name}");
		}

		private void AddItem(string item)
		{
			this.Require(item, nameof(item), Is.Not.NullOrEmpty);
			Debug.Log($"Item added: {item}");
		}
	}
}
