//----------------------------------------------
//    Google2u: Google Doc Unity integration
//         Copyright © 2015 Litteratus
//
//        This file has been auto-generated
//              Do not manually edit
//----------------------------------------------

using UnityEngine;

namespace Google2u
{
	[System.Serializable]
	public class LevelsRow : IGoogle2uRow
	{
		public int _idint;
		public string _name;
		public string _leveldata;
		public int _validate;
		public string _tuttext;
		public LevelsRow(string __id, string __idint, string __name, string __leveldata, string __validate, string __tuttext) 
		{
			{
			int res;
				if(int.TryParse(__idint, out res))
					_idint = res;
				else
					Debug.LogError("Failed To Convert _idint string: "+ __idint +" to int");
			}
			_name = __name.Trim();
			_leveldata = __leveldata.Trim();
			{
			int res;
				if(int.TryParse(__validate, out res))
					_validate = res;
				else
					Debug.LogError("Failed To Convert _validate string: "+ __validate +" to int");
			}
			_tuttext = __tuttext.Trim();
		}

		public int Length { get { return 5; } }

		public string this[int i]
		{
		    get
		    {
		        return GetStringDataByIndex(i);
		    }
		}

		public string GetStringDataByIndex( int index )
		{
			string ret = System.String.Empty;
			switch( index )
			{
				case 0:
					ret = _idint.ToString();
					break;
				case 1:
					ret = _name.ToString();
					break;
				case 2:
					ret = _leveldata.ToString();
					break;
				case 3:
					ret = _validate.ToString();
					break;
				case 4:
					ret = _tuttext.ToString();
					break;
			}

			return ret;
		}

		public string GetStringData( string colID )
		{
			var ret = System.String.Empty;
			switch( colID.ToLower() )
			{
				case "idint":
					ret = _idint.ToString();
					break;
				case "name":
					ret = _name.ToString();
					break;
				case "leveldata":
					ret = _leveldata.ToString();
					break;
				case "validate":
					ret = _validate.ToString();
					break;
				case "tuttext":
					ret = _tuttext.ToString();
					break;
			}

			return ret;
		}
		public override string ToString()
		{
			string ret = System.String.Empty;
			ret += "{" + "idint" + " : " + _idint.ToString() + "} ";
			ret += "{" + "name" + " : " + _name.ToString() + "} ";
			ret += "{" + "leveldata" + " : " + _leveldata.ToString() + "} ";
			ret += "{" + "validate" + " : " + _validate.ToString() + "} ";
			ret += "{" + "tuttext" + " : " + _tuttext.ToString() + "} ";
			return ret;
		}
	}
	public sealed class Levels : IGoogle2uDB
	{
		public enum rowIds {
			level1, level2, level3, level4, level5, level6, level7, level8
		};
		public string [] rowNames = {
			"level1", "level2", "level3", "level4", "level5", "level6", "level7", "level8"
		};
		public System.Collections.Generic.List<LevelsRow> Rows = new System.Collections.Generic.List<LevelsRow>();

		public static Levels Instance
		{
			get { return NestedLevels.instance; }
		}

		private class NestedLevels
		{
			static NestedLevels() { }
			internal static readonly Levels instance = new Levels();
		}

		private Levels()
		{
			Rows.Add( new LevelsRow("level1", "1", "helloworld", "4444444400000440500044000004400020440000044444444", "49", "Swipe the screen to move your character to the goal."));
			Rows.Add( new LevelsRow("level2", "2", "a", "4444444000400000040000504020000400000040004444444", "49", "It is possible to move offscreen and appear at the other end."));
			Rows.Add( new LevelsRow("level3", "3", "b", "0006000050600000040004446666000400000040200004000", "49", "Red Objects are dangerous."));
			Rows.Add( new LevelsRow("level4", "4", "c", "4444444403002440000044000104400010445001044444444", "49", "Time your movement to get past enemies."));
			Rows.Add( new LevelsRow("level5", "5", "d", "4400644403062440006044010004400300445010044400044", "49", "A little more complex now..."));
			Rows.Add( new LevelsRow("level6", "6", "e", "4444444400102440013344001004400100445010044444444", "49", "Slip past the enemies by get the timing correct."));
			Rows.Add( new LevelsRow("level7", "7", "f", "4444444400402440700044040404400070445040044444444", "49", "Red objects also have their own set of rules."));
			Rows.Add( new LevelsRow("level8", "8", "g", "0000000000000000000000000000000000000000000000000", "49", "unwritten"));
		}
		public IGoogle2uRow GetGenRow(string in_RowString)
		{
			IGoogle2uRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}
		public IGoogle2uRow GetGenRow(rowIds in_RowID)
		{
			IGoogle2uRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public LevelsRow GetRow(rowIds in_RowID)
		{
			LevelsRow ret = null;
			try
			{
				ret = Rows[(int)in_RowID];
			}
			catch( System.Collections.Generic.KeyNotFoundException ex )
			{
				Debug.LogError( in_RowID + " not found: " + ex.Message );
			}
			return ret;
		}
		public LevelsRow GetRow(string in_RowString)
		{
			LevelsRow ret = null;
			try
			{
				ret = Rows[(int)System.Enum.Parse(typeof(rowIds), in_RowString)];
			}
			catch(System.ArgumentException) {
				Debug.LogError( in_RowString + " is not a member of the rowIds enumeration.");
			}
			return ret;
		}

	}

}
