﻿using System;
using System.ComponentModel;

namespace CIPSA_CSharp_Module11Console.Extensions
{
    public static class ExerciseTypeExtension
    {
        /// <summary>
        /// Returns a custom description, declared through DescriptionAttribute in Enum
        /// </summary>
        /// <returns>Returns a string that is equivalent to a custom description that was declared in Enum</returns>
        public static string GetDescription(this ExerciseTypeEnum enumerationValue)
        {
            var type = enumerationValue.GetType();
            if (!type.IsEnum)
            {
                throw new ArgumentException($"{nameof(enumerationValue)} must be of Enum type", nameof(enumerationValue));
            }
            var memberInfo = type.GetMember(enumerationValue.ToString());
            if (memberInfo.Length <= 0) return enumerationValue.ToString();
            var attrs = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attrs.Length > 0 ? ((DescriptionAttribute)attrs[0]).Description : enumerationValue.ToString();
        }
    }
}