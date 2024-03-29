//----------------------------------------------
//    Google2u: Google Doc Unity integration
//         Copyright © 2015 Litteratus
//----------------------------------------------

/* Language Enumeration
 * 
 * The following Language Codes are all ISO 639-1
 * The Headers of the Google Spreadsheet that you
 * use to designate Languages must match these enumerations
 * 
 * If Google Translate supports other language codes, they
 * may be added to this enumeration. Be sure to add to the
 * GetCode function below as well.
 */

namespace Google2u
{
	public static class Language
	{
		public enum Code
		{
			/* Commonly supported languages
			 * When translating from English, these languages
			 * flow left to right, and contain mostly the same
			 * character set, requiring the least amount of
			 * effort for the biggest gain
			 */
			EN,		//	English
			FR,		//	French
			IT,		//	Italian
			DE,		//	German
			ES,		//	Spanish
			
			/* Uncommonly supported languages
			 * These languages are very popular, but require more
			 * effort to translate. They have unique character sets
			 * and flow, or the native speakers commonly also speak
			 * a more popular language.
			 */
			AR,		//	Arabic
			ZHCN,	//	Chinese (Simplified)
			JA,		//	Japanese
			KO,		//	Korean
			VI,		//	Vietnamese
			RU,		//	Russian
			NL,		//	Dutch
			PT,		//	Portuguese

			INVALID
		}
		
		public static string GetLanguageCodeAsString( Language.Code languageCode )
		{
			switch(languageCode)
			{
			case Language.Code.EN:		return "EN";
			case Language.Code.FR:		return "FR";
			case Language.Code.IT:		return "IT";
			case Language.Code.DE:		return "DE";
			case Language.Code.ES:		return "ES";
			case Language.Code.AR:		return "AR";
			case Language.Code.ZHCN:	return "ZH-CN";
			case Language.Code.JA:		return "JA";
			case Language.Code.KO:		return "KO";
			case Language.Code.VI:		return "VI";
			case Language.Code.RU:		return "RU";
			case Language.Code.NL:		return "NL";
			case Language.Code.PT:		return "PT";

			}
			
			return "Invalid Language";
		}
		
		public static string GetLanguageString( Language.Code languageCode )
		{
			switch(languageCode)
			{
			case Language.Code.EN:		return "ENGLISH";
			case Language.Code.FR:		return "FRENCH";
			case Language.Code.IT:		return "ITALIAN";
			case Language.Code.DE:		return "GERMAN";
			case Language.Code.ES:		return "SPANISH";
			case Language.Code.AR:		return "ARABIC";
			case Language.Code.ZHCN:	return "CHINESE (SIMPLIFIED)";
			case Language.Code.JA:		return "JAPANESE";
			case Language.Code.KO:		return "KOREAN";
			case Language.Code.VI:		return "VIETNAMESE";
			case Language.Code.RU:		return "RUSSIAN";
			case Language.Code.NL:		return "DUTCH";
			case Language.Code.PT:		return "PORTUGUESE";
			}
			
			return "Invalid Language";
		}
		
		public static Language.Code GetLanguageCode( string languageString )
		{
			switch(languageString.ToUpper())
			{
				case "EN":	case "ENGLISH":		return Language.Code.EN;
				case "FR":	case "FRENCH":		return Language.Code.FR;
				case "IT":	case "ITALIAN":		return Language.Code.IT;
				case "DE":	case "GERMAN":		return Language.Code.DE;
				case "ES":	case "SPANISH":		return Language.Code.ES;
				case "AR":	case "ARABIC":		return Language.Code.AR;
				case "ZHCN":	case "ZH-CN":	case "CHINESE":	case "CHINESE SIMPLIFIED":	case "CHINESE (SIMPLIFIED)":	return Language.Code.ZHCN;
				case "JA":	case "JAPANESE":	return Language.Code.JA;
				case "KO":	case "KOREAN":		return Language.Code.KO;
				case "VI":	case "VIETNAMESE":	return Language.Code.VI;
				case "RU":	case "RUSSIAN":		return Language.Code.DE;
				case "NL":	case "DUTCH":		return Language.Code.NL;
				case "PT":	case "PORTUGUESE":	return Language.Code.PT;
			}
			
			return Language.Code.INVALID;
		}
		
		// Selection Box String - Language Code - Language Name
		public static string [,] languageStrings = {
            {"(EN) 	English",		"EN",		"English"},
            {"(FR) 	French",		"FR",		"French"},
            {"(IT) 	Italian",		"IT",		"Italian"},
            {"(DE) 	German",		"DE",		"German"},
            {"(ES) 	Spanish",		"ES",		"Spanish"},
            {"(AR)	Arabic", 		"AR",		"Arabic"},
            {"(ZHCN)	Chinese (Simplified)",	"ZH-CN",	"Chinese (Simplified)"},
            {"(JA) 	Japanese",		"JA",		"Japanese"},
            {"(KO) 	Korean",		"KO",		"Korean"},
            {"(VI) 	Vietnamese",	"VI",		"Vietnamese"},
            {"(RU) 	Russian",		"RU",		"Russian"},
            {"(NL) 	Dutch",			"NL",		"Dutch"},
            {"(PT) 	Portuguese",	"PT",		"Portuguese"}
		};
	}
}               