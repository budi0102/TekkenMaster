using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TekkenLibrary
{
	/// <summary>
	/// Command Class
	/// Command Contains Combination of Direction and Limb Moves.
	/// </summary>
	[DataContract]
	public class Command
	{
		public enum Property
		{
			Normal,
			Quick
		}

		#region Public Properties
		[DataMember]
		public List<Direction> Directions { get; set; }
		[DataMember]
		public List<Limb> Limbs { get; set; }
		[DataMember]
		public Property CurrentProperty { get; set; }
		#endregion


		private static Language CurrentLanguage { get { return GlobalSettings.Instance.Language; } }
		private static CharacterPosition CharacterPosition { get { return GlobalSettings.Instance.CharacterPosition; } }

		#region Constructor
		public Command()
		{
			Directions = new List<Direction>();
			Limbs = new List<Limb>();
			CurrentProperty = Property.Normal;
		}
		public Command(IEnumerable<Direction> dMoves, IEnumerable<Limb> limbMoves, Property property)
		{
			Directions = new List<Direction>(dMoves);
			Limbs = new List<Limb>(limbMoves);
			CurrentProperty = property;
		}
		#endregion

		#region Public Methods
		public override string ToString()
		{
			StringBuilder result = new StringBuilder();
			if (Directions != null && Directions.Any())
			{
				if (CurrentLanguage == Language.English)
				{
					result.Append(string.Join(",", Directions));
				}
				else if (CurrentLanguage == Language.Japanese)
				{
					result.Append(string.Join("", Directions));
				}
			}
			if (Limbs != null && Limbs.Any())
			{
				switch (CurrentProperty)
				{
					case Property.Quick:
						if (CurrentLanguage == Language.English)
						{
							result.Append('+');
							result.Append(string.Join("~", Limbs));
						}
						else if (CurrentLanguage == Language.Japanese)
						{
							result.Append('【');
							result.Append(string.Join(",", Limbs));
							result.Append('】');
						}
						break;
					case Property.Normal:
						result.Append(string.Join(",", Limbs));
						break;
				}
			}
			return result.ToString();
		}
		#endregion

		#region Static Methods
		public static bool TryParse(string stringMove, out Command result)
		{
			result = null;

			if (string.IsNullOrEmpty(stringMove))
			{
				return false;
			}
			result = new Command();
			string input = new string(stringMove.ToCharArray());
			if (CurrentLanguage == Language.Japanese)
			{
				for (int i = 0; i < input.Length; i++)
				{
					if (char.IsDigit(input[i]))
					{
						Direction OneDMove;
						if (Direction.TryParse(input[i], out OneDMove))
						{
							result.Directions.Add(OneDMove);
						}
					}
					else if (i + 1 < input.Length)
					{
						// Regex!!!

						string limbMoveString = input.Substring(i, 2);
						Limb OneLimbMove;
						if (Limb.TryParse(limbMoveString, out OneLimbMove))
						{
							result.Limbs.Add(OneLimbMove);
						}
						i++;
					}
				}
			}

			return true;
		}
		#endregion
	}
}
