using System;
using System.Collections.Generic;
using FlaxEngine;

namespace KeyboardLettersGame
{
	public class Letter : Script
	{
		[Serialize]
		private string _text;

		[Serialize]
		public Vector3 AxisConstraints { get; set; } = Vector3.One;

		[NoSerialize]
		private Font _font;

		[NoSerialize]
		public CapsuleCollider Collider { get; private set; }

		[NoSerialize]
		public RigidBody RigidBody { get; private set; }

		[NoSerialize]
		public TextRender TextRender { get; private set; }

		[NoSerialize]
		public string Text
		{
			get => _text;
			set
			{
				_text = value;
				SetText(_text);
			}
		}

		private void SetText(string text)
		{
			if (_font)
			{
				Destroy(ref _font);
			}
			_font = TextRender.Font.CreateFont(TextRender.FontSize);
			TextRender.Text = text;
			Debug.Log(TextRender.Text);
			Vector2 size = _font.MeasureText(text) * 0.5f;
			Collider.Radius = Mathf.Max(size.X, 5);
			Collider.Height = Mathf.Max(size.Y - Collider.Radius, 0);
		}

		private void Start()
		{
			RigidBody = Actor.As<RigidBody>();
			TextRender = Actor.GetChild<TextRender>();
			Collider = Actor.GetChild<CapsuleCollider>();
			//SetText(Text);
			RigidBody.MaxDepenetrationVelocity = 1000f;
		}

		private void Update()
		{
			// Here you can add code that needs to be called every frame
			if (Actor.Position.Y < -2000)
			{
				Destroy(this.Actor);
			}
		}

		private void FixedUpdate()
		{
			RigidBody.LinearVelocity *= AxisConstraints;
			RigidBody.LocalPosition *= AxisConstraints;
		}

		private void OnDestroy()
		{
			Destroy(ref _font);
		}
	}
}