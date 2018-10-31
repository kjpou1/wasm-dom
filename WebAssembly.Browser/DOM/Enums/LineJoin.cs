using System;
namespace WebAssembly.Browser.DOM
{
    public enum LineJoin
    {
        [Export(EnumValue = ConvertEnum.ToLower)]
        Bevel,
        [Export(EnumValue = ConvertEnum.ToLower)]
        Round,
        [Export(EnumValue = ConvertEnum.ToLower)]
        Miter,
    }
}
