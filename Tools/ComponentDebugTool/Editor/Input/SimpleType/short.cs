using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

namespace ZQFramwork
{
    public static partial class InputTool
    {
        public static void InputShort(string describe, ref object value, ref bool isChange)
        {
            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField(describe);

            short newValue = 0;

            if (value != null)
            {
                newValue = (short)value;
            }

            InputShort(ref newValue, ref isChange);

            if (isChange)
            {
                value = newValue;
            }

            EditorGUILayout.EndHorizontal();
        }

        public static void InputShort(ref short value, ref bool isChange)
        {
            short newValue = (short)EditorGUILayout.DelayedIntField(value);

            if (newValue != value)
            {
                value = newValue;
                isChange = true;
            }
        }
    }

}

