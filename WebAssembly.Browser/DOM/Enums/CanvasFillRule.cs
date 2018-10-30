using System;
namespace WebAssembly.Browser.DOM
{
    // "nonzero" | "evenodd";
    public enum CanvasFillRule
    {
        [Export(EnumValue = ConvertEnum.ToLower)]
        NonZero,
        [Export(EnumValue = ConvertEnum.ToLower)]
        EventOdd,
    }
}
