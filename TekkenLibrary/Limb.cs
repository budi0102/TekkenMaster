using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace TekkenLibrary
{
	/// <summary>
	/// Limb Move class
	/// Contains Right Controller's Limb: Left Punch, Right Punch, Left Kick, and Right Kick with Property
	/// </summary>
	[DataContract]
	public class Limb
	{
		[Flags]
		internal enum limb
		{
			Nothing = 0,
			LeftPunch = 1,
			RightPunch = 1 << 1,
			LeftKick = 1 << 2,
			RightKick = 1 << 3
		}
		public enum Property
		{
			Normal,
			Hold
		}

		#region Public Type Safe Enum
		public static readonly Limb Nothing = new Limb(limb.Nothing);
		public static readonly Limb LeftPunch = new Limb(limb.LeftPunch);
		public static readonly Limb RightPunch = new Limb(limb.RightPunch);
		public static readonly Limb AllPunches = new Limb(limb.LeftPunch | limb.RightPunch);
		public static readonly Limb LeftKick = new Limb(limb.LeftKick);
		public static readonly Limb RightKick = new Limb(limb.RightKick);
		public static readonly Limb AllKicks = new Limb(limb.LeftKick | limb.RightKick);
		public static readonly Limb AllLeft = new Limb(limb.LeftPunch | limb.LeftKick);
		public static readonly Limb AllRight = new Limb(limb.RightPunch | limb.RightKick);
		public static readonly Limb LeftPunchRightKick = new Limb(limb.LeftPunch | limb.RightKick);
		public static readonly Limb RightPuchLeftKick = new Limb(limb.RightPunch | limb.LeftKick);
		public static readonly Limb All = new Limb(limb.LeftPunch | limb.RightPunch | limb.LeftKick | limb.RightKick);
		#endregion

		#region Public Property
		/// <summary>
		/// Current Limb
		/// </summary>
		[DataMember]
		internal limb Current { get; set; }
		/// <summary>
		/// Current Limb Move Property
		/// </summary>
		[DataMember]
		public Property CurrentProperty { get; set; }
		/// <summary>
		/// Note Memo
		/// </summary>
		[DataMember]
		public string Note { get; set; }
		#endregion

		#region Static Property
		/// <summary>
		/// Current Language
		/// </summary>
		private static Language CurrentLanguage { get { return GlobalSettings.Instance.Language; } }
		/// <summary>
		/// Current Character Position
		/// </summary>
		private static CharacterPosition CurrentCharacterPosition { get { return GlobalSettings.Instance.CharacterPosition; } }
		#endregion

		#region  Constructor
		/// <summary>
		/// Constructing Neutral Limb Move
		/// </summary>
		public Limb()
		{
			Current = limb.Nothing;
			CurrentProperty = Property.Normal;
			Note = null;
		}
		/// <summary>
		/// Constructing Limb Move
		/// </summary>
		/// <param name="limb"></param>
		/// <param name="property"></param>
		/// <param name="note"></param>
		internal Limb(limb limb, Property property = Property.Normal, string note = null)
		{
			Current = limb;
			CurrentProperty = property;
			Note = note;
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// Convert to string based on GlobalSettings language
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			List<string> limbs = new List<string>();
			if (Current != limb.Nothing)
			{
				if (CurrentLanguage == Language.Japanese)
				{
					if ((Current & limb.LeftPunch) > 0)
					{
						limbs.Add("LP");
					}
					if ((Current & limb.RightPunch) > 0)
					{
						limbs.Add("RP");
					}
					if ((Current & limb.LeftKick) > 0)
					{
						limbs.Add("LK");
					}
					if ((Current & limb.RightKick) > 0)
					{
						limbs.Add("RK");
					}

				}
				else if (CurrentLanguage == Language.English)
				{
					if (Current == limb.LeftPunch)
					{
						limbs.Add("1");
					}
					if (Current == limb.RightPunch)
					{
						limbs.Add("2");
					}
					if (Current == limb.LeftKick)
					{
						limbs.Add("3");
					}
					if (Current == limb.RightKick)
					{
						limbs.Add("4");
					}
				}
				else
				{
					if (Current == limb.LeftPunch)
					{
						limbs.Add("□");
					}
					if (Current == limb.RightPunch)
					{
						limbs.Add("△");
					}
					if (Current == limb.LeftKick)
					{
						limbs.Add("✕");
					}
					if (Current == limb.RightKick)
					{
						limbs.Add("〇");
					}
				}
			}
			return string.Join("+", limbs);
		}
		public bool TryParse(string limbMove)
		{
			Limb result;
			if(TryParse(limbMove, out result))
			{
				Current = result.Current;
				CurrentProperty = result.CurrentProperty;
				return true;
			}
			return false;
		}
		#endregion

		#region Static Methods
		public static bool TryParse(string limbMove, out Limb result)
		{
			result = null;
			if(string.IsNullOrEmpty(limbMove))
			{
				return false;
			}
			result = new Limb(limb.Nothing);
			string input = new string(limbMove.ToCharArray());
			if(CurrentLanguage == Language.English)
			{
				result = new Limb(limb.Nothing);
				input = input.Replace("+", string.Empty);
				foreach(char c in input)
				{
					switch(c)
					{
						case '1':
							result.Current |= limb.LeftPunch;
							break;
						case '2':
							result.Current |= limb.RightPunch;
							break;
						case '3':
							result.Current |= limb.LeftKick;
							break;
						case '4':
							result.Current |= limb.RightKick;
							break;
						case 'h':
							result.CurrentProperty = Property.Hold;
							break;
					}
				}
			}
			else if(CurrentLanguage == Language.Japanese)
			{
				input = input.ToLower();
				if(input.Contains("lp"))
				{
					result.Current |= limb.LeftPunch;
				}
				else if (input.Contains("rp"))
				{
					result.Current |= limb.RightPunch;
				}
				else if(input.Contains("wp"))
				{
					result.Current |= limb.LeftPunch | limb.RightPunch;
				}
				else if (input.Contains("lk"))
				{
					result.Current |= limb.LeftKick;
				}
				else if(input.Contains("rk"))
				{
					result.Current |= limb.RightKick;
				}
				else if (input.Contains("wk"))
				{
					result.Current |= limb.LeftKick | limb.RightKick;
				}
				else if(input.Contains("h"))
				{
					result.CurrentProperty = Property.Hold;
				}
			}

			return true;
		}
		#endregion
	}
}
