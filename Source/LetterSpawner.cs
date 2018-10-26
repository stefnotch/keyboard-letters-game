using System;
using System.Collections.Generic;
using System.Linq;
using FlaxEngine;

namespace KeyboardLettersGame
{
	public class LetterSpawner : Script
	{
		public Prefab LetterPrefab { get; set; }

		public float LetterSpawnScale = 1f;

		public float KeyboardCenterOffset = 0;

		private KeyboardCharacterPositions _keyPositions;

		private const float FlaxProbability = 0.05f;
		private static Random _rng = new Random();

		private void Start()
		{
			_keyPositions = new KeyboardCharacterPositions();
		}

		private void Update()
		{
			string text = Input.InputText.TrimEnd('\0');
			if (!string.IsNullOrWhiteSpace(text))
			{
				SpawnLetter(text);
			}
		}

		private void SpawnLetter(string text)
		{
			if (_rng.NextDouble() < FlaxProbability)
			{
				text = "FlaxEngine";
			}

			Actor spawned = PrefabManager.SpawnPrefab(LetterPrefab, Actor);
			Letter letter = spawned.GetScript<Letter>();
			letter.Text = text;

			Vector2 averagePosition = text
				.ToCharArray()
				.Select(c => _keyPositions.GetCharPosition(c))
				.Where(c => c.X >= 0)
				.Aggregate((posA, posB) => (posA + posB) / 2f);

			averagePosition.X -= _keyPositions.KeyboardSize.X * 0.5f; // Center
			averagePosition.X += KeyboardCenterOffset;
			averagePosition.Y = _keyPositions.KeyboardSize.Y - averagePosition.Y; //Flip

			averagePosition *= 100f * LetterSpawnScale; // Scale

			spawned.LocalPosition += new Vector3(averagePosition.X, 0, 0);
			letter.RigidBody.LinearVelocity = new Vector3(averagePosition.X * 0.5f, averagePosition.Y + 1000, 0);
		}

		private void OnDisable()
		{
			Actor.DestroyChildren();
		}

		/*
		 * TODO: Better blur (brightness..)
		 * Walls at the sides
		 */
	}
}