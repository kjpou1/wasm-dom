using System;
using WebAssembly;

namespace WebAssembly.Browser.DOM
{


    [Export("HTMLMediaElement", typeof(JSObject))]
    public sealed class HTMLMediaElement : DOMObject
    {
        internal HTMLMediaElement(JSObject handle) : base(handle) { }

        //public HTMLMediaElement() { }
        //[Export("HAVE_CURRENT_DATA")]
        //public double HaveCurrentData => GetProperty<double>("HAVE_CURRENT_DATA");
        //[Export("HAVE_ENOUGH_DATA")]
        //public double HaveEnoughData => GetProperty<double>("HAVE_ENOUGH_DATA");
        //[Export("HAVE_FUTURE_DATA")]
        //public double HaveFutureData => GetProperty<double>("HAVE_FUTURE_DATA");
        //[Export("HAVE_METADATA")]
        //public double HaveMetadata => GetProperty<double>("HAVE_METADATA");
        //[Export("HAVE_NOTHING")]
        //public double HaveNothing => GetProperty<double>("HAVE_NOTHING");
        //[Export("NETWORK_EMPTY")]
        //public double NetworkEmpty => GetProperty<double>("NETWORK_EMPTY");
        //[Export("NETWORK_IDLE")]
        //public double NetworkIdle => GetProperty<double>("NETWORK_IDLE");
        //[Export("NETWORK_LOADING")]
        //public double NetworkLoading => GetProperty<double>("NETWORK_LOADING");
        //[Export("NETWORK_NO_SOURCE")]
        //public double NetworkNoSource => GetProperty<double>("NETWORK_NO_SOURCE");
        //[Export("audioTracks")]
        //public AudioTrackList AudioTracks => GetProperty<AudioTrackList>("audioTracks");
        //[Export("autoplay")]
        //public bool Autoplay { get => GetProperty<bool>("autoplay"); set => SetProperty<bool>("autoplay", value); }
        //[Export("buffered")]
        //public TimeRanges Buffered => GetProperty<TimeRanges>("buffered");
        //[Export("controls")]
        //public bool Controls { get => GetProperty<bool>("controls"); set => SetProperty<bool>("controls", value); }
        //[Export("crossOrigin")]
        //public string CrossOrigin { get => GetProperty<string>("crossOrigin"); set => SetProperty<string>("crossOrigin", value); }
        //[Export("currentSrc")]
        //public string CurrentSrc => GetProperty<string>("currentSrc");
        //[Export("currentTime")]
        //public double CurrentTime { get => GetProperty<double>("currentTime"); set => SetProperty<double>("currentTime", value); }
        //[Export("defaultMuted")]
        //public bool DefaultMuted { get => GetProperty<bool>("defaultMuted"); set => SetProperty<bool>("defaultMuted", value); }
        //[Export("defaultPlaybackRate")]
        //public double DefaultPlaybackRate { get => GetProperty<double>("defaultPlaybackRate"); set => SetProperty<double>("defaultPlaybackRate", value); }
        //[Export("duration")]
        //public double Duration => GetProperty<double>("duration");
        //[Export("ended")]
        //public bool Ended => GetProperty<bool>("ended");
        //[Export("error")]
        //public MediaError Error => GetProperty<MediaError>("error");
        //[Export("loop")]
        //public bool Loop { get => GetProperty<bool>("loop"); set => SetProperty<bool>("loop", value); }
        //[Export("mediaKeys")]
        //public MediaKeys MediaKeys => GetProperty<MediaKeys>("mediaKeys");
        //[Export("msAudioCategory")]
        //public string MsAudioCategory { get => GetProperty<string>("msAudioCategory"); set => SetProperty<string>("msAudioCategory", value); }
        //[Export("msAudioDeviceType")]
        //public string MsAudioDeviceType { get => GetProperty<string>("msAudioDeviceType"); set => SetProperty<string>("msAudioDeviceType", value); }
        //[Export("msGraphicsTrustStatus")]
        //public MSGraphicsTrust MsGraphicsTrustStatus => GetProperty<MSGraphicsTrust>("msGraphicsTrustStatus");
        //[Export("msKeys")]
        //public MSMediaKeys MsKeys => GetProperty<MSMediaKeys>("msKeys");
        //[Export("msPlayToDisabled")]
        //public bool MsPlayToDisabled { get => GetProperty<bool>("msPlayToDisabled"); set => SetProperty<bool>("msPlayToDisabled", value); }
        //[Export("msPlayToPreferredSourceUri")]
        //public string MsPlayToPreferredSourceUri { get => GetProperty<string>("msPlayToPreferredSourceUri"); set => SetProperty<string>("msPlayToPreferredSourceUri", value); }
        //[Export("msPlayToPrimary")]
        //public bool MsPlayToPrimary { get => GetProperty<bool>("msPlayToPrimary"); set => SetProperty<bool>("msPlayToPrimary", value); }
        //[Export("msPlayToSource")]
        //public Object MsPlayToSource => GetProperty<Object>("msPlayToSource");
        //[Export("msRealTime")]
        //public bool MsRealTime { get => GetProperty<bool>("msRealTime"); set => SetProperty<bool>("msRealTime", value); }
        //[Export("muted")]
        //public bool Muted { get => GetProperty<bool>("muted"); set => SetProperty<bool>("muted", value); }
        //[Export("networkState")]
        //public double NetworkState => GetProperty<double>("networkState");
        //public event DOMEventHandler OnEncrypted
        //{
        //    add => AddEventListener("encrypted", value, false);
        //    remove => RemoveEventListener("encrypted", value, false);
        //}
        //public event DOMEventHandler OnMsneedkey
        //{
        //    add => AddEventListener("msneedkey", value, false);
        //    remove => RemoveEventListener("msneedkey", value, false);
        //}
        //[Export("paused")]
        //public bool Paused => GetProperty<bool>("paused");
        //[Export("playbackRate")]
        //public double PlaybackRate { get => GetProperty<double>("playbackRate"); set => SetProperty<double>("playbackRate", value); }
        //[Export("played")]
        //public TimeRanges Played => GetProperty<TimeRanges>("played");
        //[Export("preload")]
        //public string Preload { get => GetProperty<string>("preload"); set => SetProperty<string>("preload", value); }
        //[Export("readyState")]
        //public double ReadyState { get => GetProperty<double>("readyState"); set => SetProperty<double>("readyState", value); }
        //[Export("seekable")]
        //public TimeRanges Seekable => GetProperty<TimeRanges>("seekable");
        //[Export("seeking")]
        //public bool Seeking => GetProperty<bool>("seeking");
        //[Export("src")]
        //public string Src { get => GetProperty<string>("src"); set => SetProperty<string>("src", value); }
        //[Export("srcObject")]
        //public MediaStream SrcObject { get => GetProperty<MediaStream>("srcObject"); set => SetProperty<MediaStream>("srcObject", value); }
        //[Export("textTracks")]
        //public TextTrackList TextTracks => GetProperty<TextTrackList>("textTracks");
        //[Export("videoTracks")]
        //public VideoTrackList VideoTracks => GetProperty<VideoTrackList>("videoTracks");
        //[Export("volume")]
        //public double Volume { get => GetProperty<double>("volume"); set => SetProperty<double>("volume", value); }
        //[Export("addTextTrack")]
        //public TextTrack AddTextTrack(string kind, string label, string language)
        //{
        //    return InvokeMethod<TextTrack>("addTextTrack", kind, label, language);
        //}
        //[Export("canPlayType")]
        //public string CanPlayType(string type)
        //{
        //    return InvokeMethod<string>("canPlayType", type);
        //}
        //[Export("load")]
        //public void Load()
        //{
        //    InvokeMethod<object>("load");
        //}
        //[Export("msClearEffects")]
        //public void MsClearEffects()
        //{
        //    InvokeMethod<object>("msClearEffects");
        //}
        //[Export("msGetAsCastingSource")]
        //public Object MsGetAsCastingSource()
        //{
        //    return InvokeMethod<Object>("msGetAsCastingSource");
        //}
        //[Export("msInsertAudioEffect")]
        //public void MsInsertAudioEffect(string activatableClassId, bool effectRequired, Object config)
        //{
        //    InvokeMethod<object>("msInsertAudioEffect", activatableClassId, effectRequired, config);
        //}
        //[Export("msSetMediaKeys")]
        //public void MsSetMediaKeys(MSMediaKeys mediaKeys)
        //{
        //    InvokeMethod<object>("msSetMediaKeys", mediaKeys);
        //}
        //[Export("msSetMediaProtectionManager")]
        //public void MsSetMediaProtectionManager(Object mediaProtectionManager)
        //{
        //    InvokeMethod<object>("msSetMediaProtectionManager", mediaProtectionManager);
        //}
        //[Export("pause")]
        //public void Pause()
        //{
        //    InvokeMethod<object>("pause");
        //}
        //[Export("play")]
        //public Promise<void> Play()
        //{
        //    return InvokeMethod<Promise<void>>("play");
        //}
        //[Export("setMediaKeys")]
        //public Promise<void> SetMediaKeys(MediaKeys mediaKeys)
        //{
        //    return InvokeMethod<Promise<void>>("setMediaKeys", mediaKeys);
        //}
    }
}