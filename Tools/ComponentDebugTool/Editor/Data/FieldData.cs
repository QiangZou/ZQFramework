using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace ZQFramwork
{
    public class FieldData
    {
        public object instance;
        public FieldInfo fieldInfo;
        public int level;
        public ObjectData objectinfo;
        public AccessModifier accessModifier = AccessModifier.None;
        public InstanceType instanceType = InstanceType.None;

        public FieldData(object instance, FieldInfo fieldInfo, int index)
        {
            this.instance = instance;
            this.fieldInfo = fieldInfo;
            level = index;

            if (this.fieldInfo.IsPublic)
            {
                accessModifier = AccessModifier.Public;
            }
            else if (this.fieldInfo.IsPrivate)
            {
                accessModifier = AccessModifier.Private;
            }

            if (this.fieldInfo.IsStatic)
            {
                instanceType = InstanceType.Static;
            }
            else
            {
                instanceType = InstanceType.Instance;
            }

            object value = GetValue();
            objectinfo = new ObjectData(value, fieldInfo.FieldType, fieldInfo.Name, GetValue, SetValue, false, level);
        }

        public object GetValue()
        {
            if (instance == null)
            {
                return null;
            }
            return fieldInfo.GetValue(instance);
        }

        public void SetValue(object obj)
        {
            fieldInfo.SetValue(instance, obj);
        }
    }
}