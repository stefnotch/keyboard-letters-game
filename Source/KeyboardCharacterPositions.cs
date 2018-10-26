using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlaxEngine;

namespace KeyboardLettersGame
{
	public class KeyboardCharacterPositions
	{
		private const int Rows = 4;

		// TODO: Different keyboard layouts...or some other solution
		private string[] _lowerCaseCharacters = new string[Rows]
		{
			"`1234567890-=",
			"qwertyuiop[]#",
			"asdfghjkl;'",
			"zxcvbnm,./"
		};

		private string[] _upperCaseCharacters = new string[Rows]
		{
			"¬!\"£$%^&*()_+",
			"QWERTYUIOP{}~",
			"ASDFGHJKL:@",
			"ZXCVBNM<>?"
		};

		private float[] _firstLetterOffset = new float[Rows]
		{
			0,
			1.25f,
			1.5f,
			2
		};

		public Vector2 KeyboardSize;

		public KeyboardCharacterPositions()
		{
			float width = _lowerCaseCharacters
			   .Select((row, index) => row.Length + _firstLetterOffset[index])
			   .Max();

			float height = Rows;

			KeyboardSize = new Vector2(width, height);
		}

		public Vector2 GetCharPosition(char c)
		{
			Int2 index = IndexOfInStringArray(_lowerCaseCharacters, c);
			if (index.X == -1)
			{
				index = IndexOfInStringArray(_upperCaseCharacters, c);
			}
			if (index.X == -1)
			{
				// Or something
				return Vector2.Zero;
			}

			Vector2 position = new Vector2(index.X, index.Y);
			position.X += _firstLetterOffset[index.Y];
			return position;
		}

		private Int2 IndexOfInStringArray(string[] stringArray, char c)
		{
			for (int i = 0; i < stringArray.Length; i++)
			{
				int index = stringArray[i].IndexOf(c);
				if (index != -1) return new Int2(index, i);
			}
			return new Int2(-1, -1);
		}
	}
}