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
	public class Levels2Row : IGoogle2uRow
	{
		public int _idint;
		public string _name;
		public string _leveldata;
		public int _validate;
		public string _tuttext;
		public Levels2Row(string __id, string __idint, string __name, string __leveldata, string __validate, string __tuttext) 
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
	public sealed class Levels2 : IGoogle2uDB
	{
		public enum rowIds {
			level9, level10, level11, level12, level13, level14, level15, level16
		};
		public string [] rowNames = {
			"level9", "level10", "level11", "level12", "level13", "level14", "level15", "level16"
		};
		public System.Collections.Generic.List<Levels2Row> Rows = new System.Collections.Generic.List<Levels2Row>();

		public static Levels2 Instance
		{
			get { return NestedLevels2.instance; }
		}

		private class NestedLevels2
		{
			static NestedLevels2() { }
			internal static readonly Levels2 instance = new Levels2();
		}

		private Levels2()
		{
			Rows.Add( new Levels2Row("level9", "9", "helloworld", "0000000020004000000000060000000010000000000000003", "49", "unwritten"));
			Rows.Add( new Levels2Row("level10", "10", "a", "0006000002000400000000000000000010000000300000000", "49", "unwritten"));
			Rows.Add( new Levels2Row("level11", "11", "b", "0006001002000400000010000000000010000000300000100", "49", "unwritten"));
			Rows.Add( new Levels2Row("level12", "12", "c", "0000000020004000000000060000000010000000000000003", "49", "unwritten"));
			Rows.Add( new Levels2Row("level13", "13", "d", "0000000020004000000000060000000010000000000000003", "49", "unwritten"));
			Rows.Add( new Levels2Row("level14", "14", "e", "0000000020004000000000060000000010000000000000003", "49", "unwritten"));
			Rows.Add( new Levels2Row("level15", "15", "f", "0000000020004000000000060000000010000000000000003", "49", "unwritten"));
			Rows.Add( new Levels2Row("level16", "16", "g", "0000000020004000000000060000000010000000000000003", "49", "unwritten"));
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
		public Levels2Row GetRow(rowIds in_RowID)
		{
			Levels2Row ret = null;
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
		public Levels2Row GetRow(string in_RowString)
		{
			Levels2Row ret = null;
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
