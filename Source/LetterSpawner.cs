using System;
using System.Collections.Generic;
using System.Linq;
using FlaxEngine;
using FlaxEngine.Utilities;

namespace KeyboardLettersGame
{
	public class LetterSpawner : Script
	{
		public Prefab LetterPrefab { get; set; }

		public float LetterSpawnScale = 1f;

		public float KeyboardCenterOffset = 0;

		private Keyboard _keyboard;

		private const float FlaxProbability = 0.01f;
		private int _flaxCounter = 3;
		private static Random _rng = new Random();

		private bool firstUpdate = true;
		private readonly HashSet<Keys> _pressedKeys = new HashSet<Keys>();

		private void Start()
		{
			_keyboard = new Keyboard();
		}

		private void Update()
		{
			if (firstUpdate)
			{
				var window = FlaxEngine.GUI.RootControl.GameRoot.RootWindow.Window;
				//window.OnCharInput += Window_OnCharInput;
				window.OnKeyDown += Window_OnKeyDown;
				window.OnKeyUp += Window_OnKeyUp;
				firstUpdate = false;
			}

			if (Input.GetKeyUp(Keys.Spacebar))
			{
				foreach (var rigidBodyChild in Actor.GetChildren<RigidBody>())
				{
					if (rigidBodyChild.LinearVelocity.Length < 5000f)
					{
						Vector3 velocity = (_rng.NextVector3() * 2f - Vector3.One) * 1000f;
						velocity.Y = Mathf.Abs(velocity.Y);
						rigidBodyChild.LinearVelocity += velocity;
					}
				}
			}

			if (Input.GetKeyUp(Keys.Escape))
			{
				Application.Exit();
			}

			if (_pressedKeys.Count > 0)
			{
				SpawnLetter(_pressedKeys);
			}
			/*
			string text = Input.InputText.TrimEnd('\0');
			if (!string.IsNullOrWhiteSpace(text))
			{
				SpawnLetter(text);
			}*/
		}

		private void Window_OnKeyDown(Keys key)
		{
			_pressedKeys.Add(key);
		}

		private void Window_OnKeyUp(Keys key)
		{
			_pressedKeys.Remove(key);
		}

		private void SpawnLetter(IEnumerable<Keys> keys)
		{
			string text = _keyboard.KeysToString(keys);
			if (text.Length > 0)
			{
				SpawnLetter(text);
			}
		}

		private void SpawnLetter(string text)
		{
			if (_flaxCounter >= 0 && _rng.NextDouble() < FlaxProbability)
			{
				text = "FlaxEngine";
				_flaxCounter--;
			}

			Actor spawned = PrefabManager.SpawnPrefab(LetterPrefab, Actor);
			spawned.HideFlags = HideFlags.DontSave;
			Letter letter = spawned.GetScript<Letter>();
			letter.Text = text;

			Vector2 averagePosition = text
				.ToCharArray()
				.Select(c => _keyboard.GetCharPosition(c))
				.Where(c => c.X >= 0)
				.Aggregate((posA, posB) => (posA + posB) / 2f);

			averagePosition.X -= _keyboard.KeyboardSize.X * 0.5f; // Center
			averagePosition.X += KeyboardCenterOffset;
			averagePosition.Y = _keyboard.KeyboardSize.Y - averagePosition.Y; //Flip

			averagePosition *= 100f * LetterSpawnScale; // Scale

			spawned.LocalPosition += new Vector3(averagePosition.X, 0, 0);
			letter.RigidBody.LinearVelocity = new Vector3(averagePosition.X * 0.5f, averagePosition.Y + 800, 0);
		}

		private void OnDisable()
		{
			Actor.DestroyChildren();
			var window = FlaxEngine.GUI.RootControl.GameRoot.RootWindow.Window;
			window.OnKeyDown -= Window_OnKeyDown;
			window.OnKeyUp -= Window_OnKeyUp;
		}

		/*
		 * TODO: Better blur (brightness..)
		 * Walls at the sides
		 */
	}
}