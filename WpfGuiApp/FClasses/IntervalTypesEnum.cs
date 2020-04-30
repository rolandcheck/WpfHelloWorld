using System.ComponentModel;
using WpfGuiApp.UiTools;

namespace WpfGuiApp.FClasses
{
    [TypeConverter(typeof(EnumDescriptionExtractor))]
    public enum IntervalTypesEnum
    {
        [Description("Every hour")]
        EveryHour,
        [Description("Every day")]
        EveryDay,
        [Description("Every month")]
        EveryMonth,
    }
}