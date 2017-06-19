using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekkenLibrary
{
	public class Language
	{
		internal enum Lang
		{
			English,
			Japanese
		}

		public static readonly Language Japanese = new Language(Lang.Japanese);
		public static readonly Language English = new Language(Lang.English);

		internal Lang Current { get; set; }

		private Language(Lang language)
		{
			this.Current = language;
		}
		private Language(Language language)
			: this(language.Current)
		{
		}

		public static Language Parse(string language)
		{
			Lang result;
			if(Enum.TryParse<Lang>(language, out result))
			{
				return new Language(result);
			}
			return null;
		}
	}
}
