using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekkenLibrary
{
	public class MultiLocaleString
	{
		#region Public Property
		public string English { get; set; }
		public string Japanese { get; set; }
		#endregion

		#region Constructor
		public MultiLocaleString()
		{
		}
		public MultiLocaleString(string English, string Japanese)
		{
			this.English = English;
			this.Japanese = Japanese;
		}
		#endregion

		#region Public Methods
		public void Set(string English, string Japanese)
		{
			this.English = English;
			this.Japanese = Japanese;
		}
		public void Set(string text)
		{
			switch (GlobalSettings.Instance.Language.Current)
			{
				case Language.Lang.Japanese:
					this.Japanese = text;
					break;
				case Language.Lang.English:
				default:
					this.English = text;
					break;
			}
		}

		public override string ToString()
		{
			switch(GlobalSettings.Instance.Language.Current)
			{
				case Language.Lang.Japanese:
					return Japanese;
				case Language.Lang.English:
				default:
					return English;
			}
		}
		#endregion
	}
}
