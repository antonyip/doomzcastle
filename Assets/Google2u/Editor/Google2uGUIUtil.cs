//----------------------------------------------
//    Google2u: Google Doc Unity integration
//         Copyright © 2015 Litteratus
//----------------------------------------------

using System;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor;
using UnityEngine;

namespace Google2u
{
    [Serializable]
    public class Google2uGUIUtil : ISerializable
    {
        private static Google2uGUIUtil _instance;
        public static Google2uGUIUtil Instance
        {
            get { return _instance ?? (_instance = new Google2uGUIUtil()); }
        }

        private string _PrefsPath;
        public string PrefsPath { get { return string.IsNullOrEmpty(_PrefsPath) ? _PrefsPath = Path.Combine(Application.dataPath, "Google2u/Editor/g2uPrefs.bin") : _PrefsPath; } set { _PrefsPath = value; } }
        private Dictionary<string, string> _StringsDictionary = new Dictionary<string, string>();
        public Dictionary<string, string> StringsDictionary { get { return _StringsDictionary; } set { _StringsDictionary = value; }}

        private Dictionary<string, bool> _BoolsDictionary = new Dictionary<string, bool>();
        public Dictionary<string, bool> BoolsDictionary { get { return _BoolsDictionary; } set { _BoolsDictionary = value; } }

        private Dictionary<string, int> _IntsDictionary = new Dictionary<string, int>();
        public Dictionary<string, int> IntsDictionary { get { return _IntsDictionary; } set { _IntsDictionary = value; } }

        private Dictionary<string, float> _FloatsDictionary = new Dictionary<string, float>();
        public Dictionary<string, float> FloatsDictionary { get { return _FloatsDictionary; } set { _FloatsDictionary = value; } }

        private Google2uGUIUtil()
        {
            DoDeserialize();
        }

        public void DoSerialize()
        {
            var stream = File.Open(PrefsPath, FileMode.OpenOrCreate, FileAccess.Write);
            var bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, this);
            stream.Flush();
            stream.Close();
        }

        private void DoDeserialize()
        {
            if (File.Exists(PrefsPath))
            {

                var stream = File.Open(PrefsPath, FileMode.Open, FileAccess.Read);
                var bFormatter = new BinaryFormatter();
                var tmpPrefs = (Google2uGUIUtil) bFormatter.Deserialize(stream);
                stream.Close();

                _StringsDictionary = tmpPrefs.StringsDictionary;
                _BoolsDictionary = tmpPrefs.BoolsDictionary;
                _IntsDictionary = tmpPrefs.IntsDictionary;
                _FloatsDictionary = tmpPrefs.FloatsDictionary;
            }
                
        }

        public static void Save()
        {
            Instance.DoSerialize();
        }

        public static bool Load(string in_path)
        {
            if (File.Exists(in_path))
            {
                try
                {
                    var stream = File.Open(in_path, FileMode.Open, FileAccess.Read);
                    var bFormatter = new BinaryFormatter();
                    var tmpPrefs = (Google2uGUIUtil)bFormatter.Deserialize(stream);
                    stream.Close();

                    Instance.StringsDictionary = tmpPrefs.StringsDictionary;
                    Instance.BoolsDictionary = tmpPrefs.BoolsDictionary;
                    Instance.IntsDictionary = tmpPrefs.IntsDictionary;
                    Instance.FloatsDictionary = tmpPrefs.FloatsDictionary;

                    Instance.DoSerialize();

                    return true;
                }
                catch (Exception ex)
                {
                    Debug.LogError("Unable to load preferences: " + ex.Message);
                }
            }

            return false;
        }

        protected Google2uGUIUtil(SerializationInfo in_info, StreamingContext in_context)
        {
            _StringsDictionary = (Dictionary<string, string>)in_info.GetValue("StringsDictionary", typeof(Dictionary<string, string>));
            _BoolsDictionary = (Dictionary<string, bool>)in_info.GetValue("BoolsDictionary", typeof(Dictionary<string, bool>));
            _IntsDictionary = (Dictionary<string, int>)in_info.GetValue("IntsDictionary", typeof(Dictionary<string, int>));
            _FloatsDictionary = (Dictionary<string, float>)in_info.GetValue("FloatsDictionary", typeof(Dictionary<string, float>));
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo in_info, StreamingContext in_context)
        {
            in_info.AddValue("StringsDictionary", StringsDictionary);
            in_info.AddValue("BoolsDictionary", BoolsDictionary);
            in_info.AddValue("IntsDictionary", IntsDictionary);
            in_info.AddValue("FloatsDictionary", FloatsDictionary);
        }

        public static string SetString(string in_id, string in_input)
        {
            var id = Path.Combine(Application.dataPath, CleanString(in_id));
            if (!Instance.StringsDictionary.ContainsKey(id))
            {
                Instance.StringsDictionary.Add(id, in_input);
                if (Google2u.Instance != null)
                    Google2u.Instance.IsDirty = true;
            }
            else
            {
                if (Google2u.Instance && !string.Equals(Instance.StringsDictionary[id], in_input))
                    Google2u.Instance.IsDirty = true;
                Instance.StringsDictionary[id] = in_input;
            }
            return in_input;
        }

        public static string GetString(string in_id, string in_input)
        {
            var id = Path.Combine(Application.dataPath, CleanString(in_id));
            if (!Instance.StringsDictionary.ContainsKey(id))
                Instance.StringsDictionary.Add(id, EditorPrefs.HasKey(id) ? EditorPrefs.GetString(id, in_input) : in_input);
            return Instance.StringsDictionary[id];
        }

        public static bool SetBool(string in_id, bool in_input)
        {
            var id = Path.Combine(Application.dataPath, CleanString(in_id));
            if (!Instance.BoolsDictionary.ContainsKey(id))
            {
                Instance.BoolsDictionary.Add(id, in_input);
                if (Google2u.Instance != null)
                    Google2u.Instance.IsDirty = true;
            }
            else
            {
                if (Google2u.Instance && !bool.Equals(Instance.BoolsDictionary[id], in_input))
                    Google2u.Instance.IsDirty = true;
                Instance.BoolsDictionary[id] = in_input;
            }
            return in_input;
        }

        public static bool GetBool(string in_id, bool in_input)
        {
            var id = Path.Combine(Application.dataPath, CleanString(in_id));
            if (!Instance.BoolsDictionary.ContainsKey(id))
                Instance.BoolsDictionary.Add(id, EditorPrefs.HasKey(id) ? EditorPrefs.GetBool(id, in_input) : in_input);
            return Instance.BoolsDictionary[id];
        }

        public static int SetInt(string in_id, int in_input)
        {
            var id = Path.Combine(Application.dataPath, CleanString(in_id));
            if (!Instance.IntsDictionary.ContainsKey(id))
            {
                Instance.IntsDictionary.Add(id, in_input);
                if (Google2u.Instance != null)
                    Google2u.Instance.IsDirty = true;
            }
            else
            {
                if (Google2u.Instance != null && !int.Equals(Instance.IntsDictionary[id], in_input))
                    Google2u.Instance.IsDirty = true;
                Instance.IntsDictionary[id] = in_input;
            }
            return in_input;
        }

        public static int GetInt(string in_id, int in_input)
        {
            var id = Path.Combine(Application.dataPath, CleanString(in_id));
            if (!Instance.IntsDictionary.ContainsKey(id))
                Instance.IntsDictionary.Add(id, EditorPrefs.HasKey(id) ? EditorPrefs.GetInt(id, in_input) : in_input);
            return Instance.IntsDictionary[id];
        }

        public static float SetFloat(string in_id, float in_input)
        {
            var id = Path.Combine(Application.dataPath, CleanString(in_id));
            if (!Instance.FloatsDictionary.ContainsKey(id))
            {
                Instance.FloatsDictionary.Add(id, in_input);
                if (Google2u.Instance != null)
                    Google2u.Instance.IsDirty = true;
            }
            else
            {
                if (Google2u.Instance != null && Math.Abs(Instance.FloatsDictionary[id] - in_input) > float.Epsilon)
                    Google2u.Instance.IsDirty = true;
                Instance.FloatsDictionary[id] = in_input;
            }
            return in_input;
        }

        public static float GetFloat(string in_id, float in_input)
        {
            var id = Path.Combine(Application.dataPath, CleanString(in_id));
            if (!Instance.FloatsDictionary.ContainsKey(id))
                Instance.FloatsDictionary.Add(id, EditorPrefs.HasKey(id) ? EditorPrefs.GetFloat(id, in_input) : in_input);
            return Instance.FloatsDictionary[id];
        }

        private static string CleanString(string in_string)
        {
            var sb = new StringBuilder();
            foreach (var c in in_string.Where(in_c => (in_c >= '0' && in_c <= '9') || (in_c >= 'A' && in_c <= 'Z') || (in_c >= 'a' && in_c <= 'z') || in_c == '.' || in_c == '_'))
            {
                sb.Append(c);
            }
            return sb.ToString();
        }

        public static T GetEnum<T>(string in_enumID, T in_defaultEnum)
        {
            var id = Path.Combine(Application.dataPath, CleanString(in_enumID));
            var inEnumAsString = in_defaultEnum.ToString();
            var retEnumAsString = GetString(id, inEnumAsString);
            if (string.IsNullOrEmpty(retEnumAsString))
                return in_defaultEnum;
            return (T)Enum.Parse(typeof(T), retEnumAsString);
        }

        public static T SetEnum<T>(string in_enumID, T in_input)
        {
            var id = Path.Combine(Application.dataPath, CleanString(in_enumID));
            var enumAsString = Enum.GetName(typeof(T), in_input);
            SetString(id, enumAsString);
            return in_input;
        }

        public static bool GfuStrCmp(string in_1, string in_2)
        {
            // There is a special case for in_2 being "void"
            if (!in_2.Equals("void", StringComparison.InvariantCultureIgnoreCase))
                return (in_1.Equals(in_2, StringComparison.InvariantCultureIgnoreCase));

            if (!GfuStartsWith(in_1, "VOID_"))
                return (in_1.Equals(in_2, StringComparison.InvariantCultureIgnoreCase));

            var splitColName = in_1.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
            if (splitColName.Length != 2)
                return (in_1.Equals(in_2, StringComparison.InvariantCultureIgnoreCase));

            int resInt;
            return int.TryParse(splitColName[1], out resInt);
        }

        public static bool GfuStartsWith(string in_1, string in_2)
        {
            return (in_1.StartsWith(in_2, StringComparison.InvariantCultureIgnoreCase));
        }

        public class ComboBox
        {
            private static bool _forceToUnShow;
            private static int _useControlID = -1;
            private bool _IsClickedComboButton;
            private int _SelectedItemIndex;

            private Rect _Rect;
            private GUIContent _ButtonContent;
            private readonly GUIContent[] _ListContent;
            private readonly GUIStyle _ButtonStyle;
            private readonly GUIStyle _BoxStyle;
            private readonly GUIStyle _ListStyle;
            private Vector2 _MyScrollPos = Vector2.zero;

            public bool IsShown
            {
                get { return _IsClickedComboButton; }
            }

            public float x
            {
                get { return _Rect.x; }
                set { _Rect.x = value; }
            }

            public float y
            {
                get { return _Rect.y; }
                set { _Rect.y = value; }
            }
            public float width
            {
                get { return _Rect.width; }
                set { _Rect.width = value; }
            }

            public float height
            {
                get { return _Rect.height; }
                set { _Rect.height = value; }
            }

            public ComboBox(Rect in_rect, GUIContent in_buttonContent, GUIContent[] in_listContent, GUIStyle in_listStyle)
            {
                _Rect = in_rect;
                _ButtonContent = in_buttonContent;
                _ListContent = in_listContent;
                _ButtonStyle = "button";
                _BoxStyle = "box";
                _ListStyle = in_listStyle;

                _SelectedItemIndex = 0;
                foreach (var c in in_listContent)
                {
                    if (c == in_buttonContent)
                        break;
                    _SelectedItemIndex++;
                }
                if (_SelectedItemIndex >= in_listContent.Length)
                    _SelectedItemIndex = 0;
            }

            public ComboBox(Rect in_rect, GUIContent in_buttonContent, GUIContent[] in_listContent, GUIStyle in_buttonStyle, GUIStyle in_boxStyle, GUIStyle in_listStyle)
            {
               _Rect = in_rect;
               _ButtonContent = in_buttonContent;
               _ListContent = in_listContent;
               _ButtonStyle = in_buttonStyle;
               _BoxStyle = in_boxStyle;
               _ListStyle = in_listStyle;

                _SelectedItemIndex = 0;
                foreach (var c in in_listContent)
                {
                    if (c == in_buttonContent)
                        break;
                    _SelectedItemIndex++;
                }
                if (_SelectedItemIndex >= in_listContent.Length)
                    _SelectedItemIndex = 0;
            }

            public int Show()
            {
                if (_forceToUnShow)
                {
                    _forceToUnShow = false;
                    _IsClickedComboButton = false;
                }

                var done = false;
                var controlID = GUIUtility.GetControlID(FocusType.Passive);

                if (Event.current.GetTypeForControl(controlID) == EventType.mouseUp && _IsClickedComboButton)
                    done = true;

                if (GUI.Button(_Rect, _ButtonContent, _ButtonStyle))
                {
                    if (_useControlID == -1)
                    {
                        _useControlID = controlID;
                        _IsClickedComboButton = false;
                    }

                    if (_useControlID != controlID)
                    {
                        _forceToUnShow = true;
                        _useControlID = controlID;
                    }
                    _IsClickedComboButton = true;
                }

                if (_IsClickedComboButton)
                {
                    var boxRect = new Rect(_Rect.x, _Rect.y + _ListStyle.CalcHeight(_ListContent[0], 1.0f),
                        _Rect.width, 100.0f);

                    var listRect = new Rect(0f, 0f,
                        _Rect.width, _ListStyle.CalcHeight(_ListContent[0], 1.0f) * _ListContent.Length);

                    GUI.Box(boxRect, "", _BoxStyle);

                    _MyScrollPos = GUI.BeginScrollView(boxRect, _MyScrollPos, listRect, false, true);

                    var newSelectedItemIndex = GUI.SelectionGrid(listRect, _SelectedItemIndex, _ListContent, 1, _ListStyle);
                    if (newSelectedItemIndex != _SelectedItemIndex)
                    {
                        _SelectedItemIndex = newSelectedItemIndex;
                        _ButtonContent = _ListContent[_SelectedItemIndex];
                    }

                    GUI.EndScrollView();

                }

                if (done)
                    _IsClickedComboButton = false;

                return _SelectedItemIndex;
            }

            public int SelectedItemIndex
            {
                get
                {
                    return _SelectedItemIndex;
                }
                set
                {
                    _SelectedItemIndex = value;
                }
            }
        }
    }
}