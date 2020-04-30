using System;
using WpfGuiApp.FClasses;

namespace WpfGuiApp.UiTools
{
    public static class EnumItemsProvider
    {
        public static Array IntervalValues => Enum.GetValues(typeof(IntervalTypesEnum));
    }
}