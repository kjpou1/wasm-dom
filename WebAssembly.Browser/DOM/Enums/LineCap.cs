using System;
namespace WebAssembly.Browser.DOM
{
    public enum LineCap
    {
        [Export(EnumValue = ConvertEnum.ToLower)]
        Butt,
        [Export(EnumValue = ConvertEnum.ToLower)]
        Round,
        [Export(EnumValue = ConvertEnum.ToLower)]
        Square,
    }
}
