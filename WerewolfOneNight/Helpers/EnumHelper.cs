using System;
using WerewolfOneNight.Enums;
using Windows.UI.Xaml.Controls;

namespace WerewolfOneNight.Helpers
{
    public static class EnumHelper
    {
        public static RoleEnum GetRole(this Image image)
        {
            return (RoleEnum)Enum.Parse(typeof(RoleEnum), image.Tag.ToString());
        }

        public static RoleEnum GetRole(this string value)
        {
            return (RoleEnum)Enum.Parse(typeof(RoleEnum), value);
        }
    }
}
