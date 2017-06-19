using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekkenLibrary
{
	public class CharacterPosition
	{
		#region Data Structure
		internal enum Position
		{
			Left,
			Right
		}
		#endregion

		#region Type Safe Enum
		public static readonly CharacterPosition Right = new CharacterPosition(Position.Right);
		public static readonly CharacterPosition Left = new CharacterPosition(Position.Left);
		#endregion

		#region Public Property
		internal Position Current{ get; set; }
		#endregion

		#region Constructor
		private CharacterPosition(Position position)
		{
			this.Current = position;
		}

		private CharacterPosition(CharacterPosition charPosition)
			: this(charPosition.Current)
		{
		}
		#endregion


	}
}
