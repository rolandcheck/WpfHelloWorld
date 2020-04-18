namespace WpfGuiApp.FClasses
{
    public class AppSettings
    {
        public string MyStringProp { get; set; }
        public MyComplexSettingSet ComplexSettingSet { get; set; }

        public class MyComplexSettingSet
        {
            public int Count { get; set; }
            public string ButtonContent { get; set; }
        }
    }
}