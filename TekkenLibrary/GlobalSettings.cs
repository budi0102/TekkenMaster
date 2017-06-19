using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekkenLibrary
{
	public class GlobalSettings
	{
		#region Singleton Instance
		public static GlobalSettings Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GlobalSettings();
				}
				return _instance;
			}
		}
		private static GlobalSettings _instance;
		#endregion

		#region Constructor
		static GlobalSettings()
		{
		}
		private GlobalSettings()
		{
			CharacterPosition = TekkenLibrary.CharacterPosition.Left;
			Language = TekkenLibrary.Language.English;
		}
		#endregion

		#region Public Property
		public CharacterPosition CharacterPosition { get; set; }
		public Language Language { get; set; }
		#endregion
	}
}
