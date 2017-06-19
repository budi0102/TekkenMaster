using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace TekkenLibrary
{
	/// <summary>
	/// Direction class
	/// Contains Left Controller's directions: Down, Forward, Up, Back with Property
	/// </summary>
	[DataContract]
	public class Direction
	{
		[Flags]
		internal enum direction
		{
			Neutral = 0,
			Up = 1 << 0,
			Down = 1 << 1,
			Back = 1 << 2,
			Forward = 1 << 3
		}
		public enum Property
		{
			Normal,
			QuickRelease,
			Hold
		}

		#region Public Type Safe Enum
		public static readonly Direction FullCrouch = new Direction(direction.Down, Property.Hold);
		public static readonly Direction SideStepUp = new Direction(direction.Up, Property.QuickRelease);
		public static readonly Direction SideStepDown = new Direction(direction.Down, Property.QuickRelease);

		public static readonly Direction Up = new Direction(direction.Up);
		public static readonly Direction Down = new Direction(direction.Down);
		public static readonly Direction Forward = new Direction(direction.Forward);
		public static readonly Direction Back = new Direction(direction.Back);

		public static readonly Direction DownBack = new Direction(direction.Down | direction.Back);
		public static readonly Direction DownForward = new Direction(direction.Down | direction.Forward);
		public static readonly Direction UpBack = new Direction(direction.Up | direction.Back);
		public static readonly Direction UpForward = new Direction(direction.Up | direction.Forward);
		#endregion

		#region Public Property
		/// <summary>
		/// Current Direction
		/// </summary>
		[DataMember]
		internal direction CurrentDirection {
			get { return _currentDirection; }
			set { if (IsMoveCorrect(value)) _currentDirection = value; }
		}
		private direction _currentDirection;

		/// <summary>
		/// Current Direction Property
		/// </summary>
		[DataMember]
		public Property CurrentProperty { get; set; }
		#endregion

		#region Static Property
		/// <summary>
		/// Current Character Position
		/// </summary>
		private static CharacterPosition CurrentCharacterPosition { get { return GlobalSettings.Instance.CharacterPosition; } }
		/// <summary>
		/// Current Language
		/// </summary>
		private static Language CurrentLanguage { get { return GlobalSettings.Instance.Language; } }
		#endregion

		#region Constructor
		/// <summary>
		/// Constructing Neutral Direction
		/// </summary>
		private Direction()
		{
			CurrentDirection = direction.Neutral;
			CurrentProperty = Property.Normal;
		}
		/// <summary>
		/// Constructing Direction with some Property
		/// </summary>
		/// <param name="direction"></param>
		/// <param name="property"></param>
		internal Direction(direction direction, Property property = Property.Normal)
			:this()
		{
			CurrentDirection = direction;
			CurrentProperty = property;
		}
		/// <summary>
		/// Copy Constructor
		/// </summary>
		/// <param name="dmove"></param>
		public Direction(Direction dmove)
			: this(dmove.CurrentDirection, dmove.CurrentProperty)
		{
		}
		#endregion

		#region Static Methods
		/// <summary>
		/// Parsing a character to direction
		/// Usually applies to Japanese language, because it is usually 1 char.
		/// In English, there might be 2 chars or more, so this does not apply
		/// </summary>
		/// <param name="dMove"></param>
		/// <param name="result"></param>
		/// <returns></returns>
		public static bool TryParse(char dMove, out Direction result)
		{
			string dMoveString = new string(dMove, 1);
			return TryParse(dMoveString, out result);
		}
		/// <summary>
		/// Parsing a string to direction
		/// </summary>
		/// <param name="dMoveString"></param>
		/// <param name="result"></param>
		/// <returns></returns>
		public static bool TryParse(string dMoveString, out Direction result)
		{
			result = null;
			if (string.IsNullOrEmpty(dMoveString))
			{
				return false;
			}

			string input = new string(dMoveString.ToCharArray());
			bool IsJapanese = input.Any(char.IsDigit);
			result = new Direction();
			switch (IsJapanese)
			{
				case true:
					input = input.ToLower();
					if (input.Contains('h'))
					{
						result.CurrentProperty = Property.Hold;
						input = input.Replace("h", string.Empty);
					}
					switch (input)
					{
						case "1":
							result.CurrentDirection = direction.Down | direction.Back;
							break;
						case "2":
							result.CurrentDirection = direction.Down;
							break;
						case "3":
							result.CurrentDirection = direction.Down | direction.Forward;
							break;
						case "4":
							result.CurrentDirection = direction.Back;
							break;
						case "5":
							result.CurrentDirection = direction.Neutral;
							break;
						case "6":
							result.CurrentDirection = direction.Forward;
							break;
						case "7":
							result.CurrentDirection = direction.Up | direction.Back;
							break;
						case "8":
							result.CurrentDirection = direction.Up;
							break;
						case "9":
							result.CurrentDirection = direction.Up | direction.Forward;
							break;
						default:
							return false;
					}
					break;
				case false:
					input = input.Replace("\\", string.Empty).Replace("/", string.Empty).Replace("+", string.Empty);
					foreach (char c in input)
					{
						switch (c)
						{
							case 'B':
								result.CurrentDirection = direction.Back;
								result.CurrentProperty = Property.Hold;
								break;
							case 'b':
								result.CurrentDirection = direction.Back;
								break;
							case 'F':
								result.CurrentDirection = direction.Forward;
								result.CurrentProperty = Property.Hold;
								break;
							case 'f':
								result.CurrentDirection = direction.Forward;
								break;
							case 'U':
								result.CurrentDirection = direction.Up;
								result.CurrentProperty = Property.Hold;
								break;
							case 'u':
								result.CurrentDirection = direction.Up;
								break;
							case 'D':
								result.CurrentDirection = direction.Down;
								result.CurrentProperty = Property.Hold;
								break;
							case 'd':
								result.CurrentDirection = direction.Down;
								break;
							case 'N':
							case 'n':
								result.CurrentProperty = Property.QuickRelease;
								break;
							default:
								return false;
						}
					}
					break;
			}
			return true;
		}

		/// <summary>
		/// direction enum check, to make sure it is not tampered
		/// </summary>
		/// <param name="direction"></param>
		/// <returns></returns>
		internal static bool IsMoveCorrect(direction direction)
		{
			switch (direction)
			{
				case (direction.Back | direction.Forward):
					return false;
				case (direction.Up | direction.Down):
					return false;
				default:
					if (((int)direction >= (1 << 4)) ||
						((int)direction < 0))
					{
						return false;
					}
					return true;
			}
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Parse direction string
		/// </summary>
		/// <param name="dmove"></param>
		/// <returns></returns>
		public bool TryParse(string dmove)
		{
			Direction result;
			if (TryParse(dmove, out result))
			{
				CurrentDirection = result.CurrentDirection;
				CurrentProperty = result.CurrentProperty;
				return true;
			}
			return false;
		}
		/// <summary>
		/// Convert to string based on GlobalSettings language
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			StringBuilder str = new StringBuilder();

			if (CurrentLanguage == Language.English)
			{
				if (CurrentDirection == direction.Neutral)
				{

				}
				else
				{
					if ((CurrentDirection & direction.Down) > 0)
					{
						str.Append('d');
					}
					else if ((CurrentDirection & direction.Up) > 0)
					{
						str.Append('u');
					}
					if ((CurrentDirection & direction.Back) > 0)
					{
						str.Append('b');
					}
					else if ((CurrentDirection & direction.Forward) > 0)
					{
						str.Append('f');
					}
				}
				switch (CurrentProperty)
				{
					case Property.Hold:
						return str.ToString().ToUpper();
					case Property.QuickRelease:
						str.Append('N');
						break;
				}
			}
			else if (CurrentLanguage == Language.Japanese)
			{
				switch (CurrentCharacterPosition.Current)
				{
					case CharacterPosition.Position.Left:
						switch (CurrentDirection)
						{
							case direction.Down | direction.Back:
								str.Append('1');
								break;
							case direction.Down:
								str.Append('2');
								break;
							case direction.Down | direction.Forward:
								str.Append('3');
								break;
							case direction.Back:
								str.Append('4');
								break;
							case direction.Neutral:
								str.Append('5');
								break;
							case direction.Forward:
								str.Append('6');
								break;
							case direction.Up | direction.Back:
								str.Append('7');
								break;
							case direction.Up:
								str.Append('8');
								break;
							case direction.Up | direction.Forward:
								str.Append('9');
								break;
						}
						break;
					case CharacterPosition.Position.Right:
						switch (CurrentDirection)
						{
							case direction.Down | direction.Back:
								str.Append('3');
								break;
							case direction.Down:
								str.Append('2');
								break;
							case direction.Down | direction.Forward:
								str.Append('1');
								break;
							case direction.Back:
								str.Append('6');
								break;
							case direction.Neutral:
								str.Append('5');
								break;
							case direction.Forward:
								str.Append('4');
								break;
							case direction.Up | direction.Back:
								str.Append('9');
								break;
							case direction.Up:
								str.Append('8');
								break;
							case direction.Up | direction.Forward:
								str.Append('7');
								break;
						}
						break;
				}
				//str.Append(CurrentDirection.ToString());
				switch (CurrentProperty)
				{
					case Property.Hold:
						str.Append("H");
						break;
					case Property.QuickRelease:
						str.Append("☆");
						break;
				}
			}
			return str.ToString();
		}
		#endregion

		#region private helper methods
		/// <summary>
		/// To check if assigned direction is correct
		/// </summary>
		/// <returns></returns>
		private bool IsMoveCorrect()
		{
			return IsMoveCorrect(CurrentDirection);
		}
		#endregion
	}
}
