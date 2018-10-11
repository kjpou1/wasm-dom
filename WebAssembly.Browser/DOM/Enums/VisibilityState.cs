using System;

using WebAssembly;

namespace WebAssembly.Browser.DOM
{
    public enum VisibilityState
    {
        [Export(EnumValue = ConvertEnum.ToLower)]
        Visible,
        [Export(EnumValue = ConvertEnum.ToLower)]
        Hidden,
        [Export(EnumValue = ConvertEnum.ToLower)]
        PreRender,
        [Export(EnumValue = ConvertEnum.ToLower)]
        UnLoaded,

    }
}
