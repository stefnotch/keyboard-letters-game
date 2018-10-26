using System;
using System.Collections.Generic;
using System.Linq;
using FlaxEngine;

namespace KeyboardLettersGame
{
	public class Keyboard
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

		public Keyboard()
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

		private Dictionary<Keys, string[]> _keysToChars = new Dictionary<Keys, string[]>()
		{
			//{ Keys.None, new string[]{"", ""}},
			//{ Keys.Backspace, new string[]{"", ""}},
			//{ Keys.Tab, new string[]{"", ""}},
			//{ Keys.Clear, new string[]{"", ""}},
			//{ Keys.Return, new string[]{"", ""}},
			//{ Keys.Shift, new string[]{"", ""}},
			//{ Keys.Control, new string[]{"", ""}},
			//{ Keys.Alt, new string[]{"", ""}},
			//{ Keys.Pause, new string[]{"", ""}},
			//{ Keys.Capital, new string[]{"", ""}},
			//{ Keys.Kana, new string[]{"", ""}},
			//{ Keys.Hangul, new string[]{"", ""}},
			//{ Keys.Junja, new string[]{"", ""}},
			//{ Keys.Final, new string[]{"", ""}},
			//{ Keys.Hanja, new string[]{"", ""}},
			//{ Keys.Kanji, new string[]{"", ""}},
			//{ Keys.Escape, new string[]{"", ""}},
			//{ Keys.Convert, new string[]{"", ""}},
			//{ Keys.Nonconvert, new string[]{"", ""}},
			//{ Keys.Accept, new string[]{"", ""}},
			//{ Keys.Modechange, new string[]{"", ""}},
			//{ Keys.Spacebar, new string[]{"", ""}},
			//{ Keys.PageUp, new string[]{"", ""}},
			//{ Keys.PageDown, new string[]{"", ""}},
			//{ Keys.End, new string[]{"", ""}},
			//{ Keys.Home, new string[]{"", ""}},
			//{ Keys.ArrowLeft, new string[]{"", ""}},
			//{ Keys.ArrowUp, new string[]{"", ""}},
			//{ Keys.ArrowRight, new string[]{"", ""}},
			//{ Keys.ArrowDown, new string[]{"", ""}},
			//{ Keys.Select, new string[]{"", ""}},
			//{ Keys.Print, new string[]{"", ""}},
			//{ Keys.Execute, new string[]{"", ""}},
			//{ Keys.PrintScreen, new string[]{"", ""}},
			//{ Keys.Insert, new string[]{"", ""}},
			//{ Keys.Delete, new string[]{"", ""}},
			//{ Keys.Help, new string[]{"", ""}},
			{ Keys.Alpha0, new string[]{"0", ")"}},
			{ Keys.Alpha1, new string[]{"1", "!"}},
			{ Keys.Alpha2, new string[]{"2", "@"}},
			{ Keys.Alpha3, new string[]{"3", "#"}},
			{ Keys.Alpha4, new string[]{"4", "$"}},
			{ Keys.Alpha5, new string[]{"5", "%"}},
			{ Keys.Alpha6, new string[]{"6", "^"}},
			{ Keys.Alpha7, new string[]{"7", "&"}},
			{ Keys.Alpha8, new string[]{"8", "*"}},
			{ Keys.Alpha9, new string[]{"9", "("}},
			{ Keys.A, new string[]{"a", "A"}},
			{ Keys.B, new string[]{"b", "B"}},
			{ Keys.C, new string[]{"c", "C"}},
			{ Keys.D, new string[]{"d", "D"}},
			{ Keys.E, new string[]{"e", "E"}},
			{ Keys.F, new string[]{"f", "F"}},
			{ Keys.G, new string[]{"g", "G"}},
			{ Keys.H, new string[]{"h", "H"}},
			{ Keys.I, new string[]{"i", "I"}},
			{ Keys.J, new string[]{"j", "J"}},
			{ Keys.K, new string[]{"k", "K"}},
			{ Keys.L, new string[]{"l", "L"}},
			{ Keys.M, new string[]{"m", "M"}},
			{ Keys.N, new string[]{"n", "N"}},
			{ Keys.O, new string[]{"o", "O"}},
			{ Keys.P, new string[]{"p", "P"}},
			{ Keys.Q, new string[]{"q", "Q"}},
			{ Keys.R, new string[]{"r", "R"}},
			{ Keys.S, new string[]{"s", "S"}},
			{ Keys.T, new string[]{"t", "T"}},
			{ Keys.U, new string[]{"u", "U"}},
			{ Keys.V, new string[]{"v", "V"}},
			{ Keys.W, new string[]{"w", "W"}},
			{ Keys.X, new string[]{"x", "X"}},
			{ Keys.Y, new string[]{"y", "Y"}},
			{ Keys.Z, new string[]{"z", "Z"}},
			//{ Keys.LeftWindows, new string[]{"", ""}},
			//{ Keys.RightWindows, new string[]{"", ""}},
			//{ Keys.Applications, new string[]{"", ""}},
			//{ Keys.Sleep, new string[]{"", ""}},
			{ Keys.Numpad0, new string[]{"0", ""}},
			{ Keys.Numpad1, new string[]{"1", ""}},
			{ Keys.Numpad2, new string[]{"2", ""}},
			{ Keys.Numpad3, new string[]{"3", ""}},
			{ Keys.Numpad4, new string[]{"4", ""}},
			{ Keys.Numpad5, new string[]{"5", ""}},
			{ Keys.Numpad6, new string[]{"6", ""}},
			{ Keys.Numpad7, new string[]{"7", ""}},
			{ Keys.Numpad8, new string[]{"8", ""}},
			{ Keys.Numpad9, new string[]{"9", ""}},
			{ Keys.NumpadMultiply, new string[]{"*", ""}},
			{ Keys.NumpadAdd, new string[]{"+", ""}},
			{ Keys.NumpadSeparator, new string[]{".", ""}}, // TODO: Is this correct?
			{ Keys.NumpadSubtract, new string[]{"-", ""}},
			{ Keys.NumpadDecimal, new string[]{",", ""}},
			{ Keys.NumpadDivide, new string[]{"/", ""}},
			{ Keys.F1, new string[]{"F1", ""}},
			{ Keys.F2, new string[]{"F2", ""}},
			{ Keys.F3, new string[]{"F3", ""}},
			{ Keys.F4, new string[]{"F4", ""}},
			{ Keys.F5, new string[]{"F5", ""}},
			{ Keys.F6, new string[]{"F6", ""}},
			{ Keys.F7, new string[]{"F7", ""}},
			{ Keys.F8, new string[]{"F8", ""}},
			{ Keys.F9, new string[]{"F9", ""}},
			{ Keys.F10, new string[]{"F10", ""}},
			{ Keys.F11, new string[]{"F11", ""}},
			{ Keys.F12, new string[]{"F12", ""}},
			{ Keys.F13, new string[]{"F13", ""}},
			{ Keys.F14, new string[]{"F14", ""}},
			{ Keys.F15, new string[]{"F15", ""}},
			{ Keys.F16, new string[]{"F16", ""}},
			{ Keys.F17, new string[]{"F17", ""}},
			{ Keys.F18, new string[]{"F18", ""}},
			{ Keys.F19, new string[]{"F19", ""}},
			{ Keys.F20, new string[]{"F20", ""}},
			{ Keys.F21, new string[]{"F21", ""}},
			{ Keys.F22, new string[]{"F22", ""}},
			{ Keys.F23, new string[]{"F23", ""}},
			{ Keys.F24, new string[]{"F24", ""}},
			//{ Keys.Numlock, new string[]{"", ""}},
			//{ Keys.Scroll, new string[]{"", ""}},
			//{ Keys.LeftShift, new string[]{"", ""}},
			//{ Keys.RightShift, new string[]{"", ""}},
			//{ Keys.LeftControl, new string[]{"", ""}},
			//{ Keys.RightControl, new string[]{"", ""}},
			//{ Keys.LeftMenu, new string[]{"", ""}},
			//{ Keys.RightMenu, new string[]{"", ""}},
			//{ Keys.BrowserBack, new string[]{"", ""}},
			//{ Keys.BrowserForward, new string[]{"", ""}},
			//{ Keys.BrowserRefresh, new string[]{"", ""}},
			//{ Keys.BrowserStop, new string[]{"", ""}},
			//{ Keys.BrowserSearch, new string[]{"", ""}},
			//{ Keys.BrowserFavorites, new string[]{"", ""}},
			//{ Keys.BrowserHome, new string[]{"", ""}},
			//{ Keys.VolumeMute, new string[]{"", ""}},
			//{ Keys.VolumeDown, new string[]{"", ""}},
			//{ Keys.VolumeUp, new string[]{"", ""}},
			//{ Keys.MediaNextTrack, new string[]{"", ""}},
			//{ Keys.MediaPrevTrack, new string[]{"", ""}},
			//{ Keys.MediaStop, new string[]{"", ""}},
			//{ Keys.MediaPlayPause, new string[]{"", ""}},
			//{ Keys.LaunchMail, new string[]{"", ""}},
			//{ Keys.LaunchMediaSelect, new string[]{"", ""}},
			//{ Keys.LaunchApp1, new string[]{"", ""}},
			//{ Keys.LaunchApp2, new string[]{"", ""}},
			{ Keys.Colon, new string[]{";", ":"}},
			{ Keys.Plus, new string[]{"=", "+"}},
			{ Keys.Comma, new string[]{",", "<"}},
			{ Keys.Minus, new string[]{"-", ""}},
			{ Keys.Period, new string[]{".", ">"}},
			{ Keys.Slash, new string[]{"/", "?"}},
			{ Keys.BackQuote, new string[]{"`", "~"}},
			{ Keys.LeftBracket, new string[]{"[", "{"}},
			{ Keys.Backslash, new string[]{"\\", "|"}},
			{ Keys.RightBracket, new string[]{"]", "}"}},
			{ Keys.Quote, new string[]{"'", "\""}},
			//{ Keys.Oem8, new string[]{"", ""}},
			//{ Keys.Oem102, new string[]{"", ""}},
			//{ Keys.Processkey, new string[]{"", ""}},
			//{ Keys.Packet, new string[]{"", ""}},
			//{ Keys.Attn, new string[]{"", ""}},
			//{ Keys.Crsel, new string[]{"", ""}},
			//{ Keys.Exsel, new string[]{"", ""}},
			//{ Keys.Ereof, new string[]{"", ""}},
			//{ Keys.Play, new string[]{"", ""}},
			//{ Keys.Zoom, new string[]{"", ""}},
			//{ Keys.Pa1, new string[]{"", ""}},
			//{ Keys.OemClear, new string[]{"", ""}},
		};

		public string KeysToString(IEnumerable<Keys> keys)
		{
			string text = "";
			bool shiftPressed = keys.Any(key => key == Keys.Shift || key == Keys.RightShift || key == Keys.Shift);
			foreach (var key in keys)
			{
				if (_keysToChars.TryGetValue(key, out string[] toChars))
				{
					if (shiftPressed && toChars.Length > 1 && !string.IsNullOrEmpty(toChars[1]))
					{
						text += toChars[1];
					}
					else
					{
						text += toChars[0];
					}
				}
			}
			return text;
		}
	}
}