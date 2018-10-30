using System;
namespace WebAssembly.Browser.DOM
{
    public enum TextAlign
    {
        [Export(EnumValue = ConvertEnum.ToLower)]
        Start,
        [Export(EnumValue = ConvertEnum.ToLower)]
        Left,
        [Export(EnumValue = ConvertEnum.ToLower)]
        Right,
        [Export(EnumValue = ConvertEnum.ToLower)]
        Center,
        [Export(EnumValue = ConvertEnum.ToLower)]
        End,

    }
}
