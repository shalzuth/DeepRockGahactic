using UnrealSharp;
using Object = UnrealSharp.UEObject;
using SDK.Script.CoreUObjectSDK;
using SDK.Script.AudioMixerSDK;
using SDK.Script.EngineSDK;
namespace SDK.Script.TimeSynthSDK
{
    public class TimeSynthVolumeGroup : Object
    {
        public TimeSynthVolumeGroup(ulong addr) : base(addr) { }
        public float DefaultVolume { get { return this[nameof(DefaultVolume)].GetValue<float>(); } set { this[nameof(DefaultVolume)].SetValue<float>(value); } }
    }
    public class TimeSynthClip : Object
    {
        public TimeSynthClip(ulong addr) : base(addr) { }
        public Array<TimeSynthClipSound> Sounds { get { return new Array<TimeSynthClipSound>(this[nameof(Sounds)].Address); } }
        public Vector2D VolumeScaleDb { get { return this[nameof(VolumeScaleDb)].As<Vector2D>(); } set { this["VolumeScaleDb"] = value; } }
        public Vector2D PitchScaleSemitones { get { return this[nameof(PitchScaleSemitones)].As<Vector2D>(); } set { this["PitchScaleSemitones"] = value; } }
        public TimeSynthTimeDef FadeInTime { get { return this[nameof(FadeInTime)].As<TimeSynthTimeDef>(); } set { this["FadeInTime"] = value; } }
        public bool bApplyFadeOut { get { return this[nameof(bApplyFadeOut)].Flag; } set { this[nameof(bApplyFadeOut)].Flag = value; } }
        public TimeSynthTimeDef FadeOutTime { get { return this[nameof(FadeOutTime)].As<TimeSynthTimeDef>(); } set { this["FadeOutTime"] = value; } }
        public TimeSynthTimeDef ClipDuration { get { return this[nameof(ClipDuration)].As<TimeSynthTimeDef>(); } set { this["ClipDuration"] = value; } }
        public ETimeSynthEventClipQuantization ClipQuantization { get { return (ETimeSynthEventClipQuantization)this[nameof(ClipQuantization)].GetValue<int>(); } set { this[nameof(ClipQuantization)].SetValue<int>((int)value); } }
    }
    public class TimeSynthComponent : SynthComponent
    {
        public TimeSynthComponent(ulong addr) : base(addr) { }
        public TimeSynthQuantizationSettings QuantizationSettings { get { return this[nameof(QuantizationSettings)].As<TimeSynthQuantizationSettings>(); } set { this["QuantizationSettings"] = value; } }
        public bool bEnableSpectralAnalysis { get { return this[nameof(bEnableSpectralAnalysis)].Flag; } set { this[nameof(bEnableSpectralAnalysis)].Flag = value; } }
        public Array<float> FrequenciesToAnalyze { get { return new Array<float>(this[nameof(FrequenciesToAnalyze)].Address); } }
        public ETimeSynthFFTSize FFTSize { get { return (ETimeSynthFFTSize)this[nameof(FFTSize)].GetValue<int>(); } set { this[nameof(FFTSize)].SetValue<int>((int)value); } }
        public Object OnPlaybackTime { get { return this[nameof(OnPlaybackTime)]; } set { this[nameof(OnPlaybackTime)] = value; } }
        public bool bIsFilterAEnabled { get { return this[nameof(bIsFilterAEnabled)].Flag; } set { this[nameof(bIsFilterAEnabled)].Flag = value; } }
        public bool bIsFilterBEnabled { get { return this[nameof(bIsFilterBEnabled)].Flag; } set { this[nameof(bIsFilterBEnabled)].Flag = value; } }
        public TimeSynthFilterSettings FilterASettings { get { return this[nameof(FilterASettings)].As<TimeSynthFilterSettings>(); } set { this["FilterASettings"] = value; } }
        public TimeSynthFilterSettings FilterBSettings { get { return this[nameof(FilterBSettings)].As<TimeSynthFilterSettings>(); } set { this["FilterBSettings"] = value; } }
        public bool bIsEnvelopeFollowerEnabled { get { return this[nameof(bIsEnvelopeFollowerEnabled)].Flag; } set { this[nameof(bIsEnvelopeFollowerEnabled)].Flag = value; } }
        public TimeSynthEnvelopeFollowerSettings EnvelopeFollowerSettings { get { return this[nameof(EnvelopeFollowerSettings)].As<TimeSynthEnvelopeFollowerSettings>(); } set { this["EnvelopeFollowerSettings"] = value; } }
        public int MaxPoolSize { get { return this[nameof(MaxPoolSize)].GetValue<int>(); } set { this[nameof(MaxPoolSize)].SetValue<int>(value); } }
        public void StopSoundsOnVolumeGroupWithFadeOverride(TimeSynthVolumeGroup InVolumeGroup, ETimeSynthEventClipQuantization EventQuantization, TimeSynthTimeDef FadeTime) { Invoke(nameof(StopSoundsOnVolumeGroupWithFadeOverride), InVolumeGroup, EventQuantization, FadeTime); }
        public void StopSoundsOnVolumeGroup(TimeSynthVolumeGroup InVolumeGroup, ETimeSynthEventClipQuantization EventQuantization) { Invoke(nameof(StopSoundsOnVolumeGroup), InVolumeGroup, EventQuantization); }
        public void StopClipWithFadeOverride(TimeSynthClipHandle InClipHandle, ETimeSynthEventClipQuantization EventQuantization, TimeSynthTimeDef FadeTime) { Invoke(nameof(StopClipWithFadeOverride), InClipHandle, EventQuantization, FadeTime); }
        public void StopClip(TimeSynthClipHandle InClipHandle, ETimeSynthEventClipQuantization EventQuantization) { Invoke(nameof(StopClip), InClipHandle, EventQuantization); }
        public void SetVolumeGroup(TimeSynthVolumeGroup InVolumeGroup, float VolumeDb, float FadeTimeSec) { Invoke(nameof(SetVolumeGroup), InVolumeGroup, VolumeDb, FadeTimeSec); }
        public void SetSeed(int InSeed) { Invoke(nameof(SetSeed), InSeed); }
        public void SetQuantizationSettings(TimeSynthQuantizationSettings InQuantizationSettings) { Invoke(nameof(SetQuantizationSettings), InQuantizationSettings); }
        public void SetFilterSettings(ETimeSynthFilter Filter, TimeSynthFilterSettings InSettings) { Invoke(nameof(SetFilterSettings), Filter, InSettings); }
        public void SetFilterEnabled(ETimeSynthFilter Filter, bool bIsEnabled) { Invoke(nameof(SetFilterEnabled), Filter, bIsEnabled); }
        public void SetFFTSize(ETimeSynthFFTSize InFFTSize) { Invoke(nameof(SetFFTSize), InFFTSize); }
        public void SetEnvelopeFollowerSettings(TimeSynthEnvelopeFollowerSettings InSettings) { Invoke(nameof(SetEnvelopeFollowerSettings), InSettings); }
        public void SetEnvelopeFollowerEnabled(bool bInIsEnabled) { Invoke(nameof(SetEnvelopeFollowerEnabled), bInIsEnabled); }
        public void SetBPM(float BeatsPerMinute) { Invoke(nameof(SetBPM), BeatsPerMinute); }
        public void ResetSeed() { Invoke(nameof(ResetSeed)); }
        public TimeSynthClipHandle PlayClip(TimeSynthClip InClip, TimeSynthVolumeGroup InVolumeGroup) { return Invoke<TimeSynthClipHandle>(nameof(PlayClip), InClip, InVolumeGroup); }
        public bool HasActiveClips() { return Invoke<bool>(nameof(HasActiveClips)); }
        public Array<TimeSynthSpectralData> GetSpectralData() { return Invoke<Array<TimeSynthSpectralData>>(nameof(GetSpectralData)); }
        public float GetEnvelopeFollowerValue() { return Invoke<float>(nameof(GetEnvelopeFollowerValue)); }
        public int GetBPM() { return Invoke<int>(nameof(GetBPM)); }
        public void AddQuantizationEventDelegate(ETimeSynthEventQuantization QuantizationType, Object OnQuantizationEvent) { Invoke(nameof(AddQuantizationEventDelegate), QuantizationType, OnQuantizationEvent); }
    }
    public enum ETimeSynthEventQuantization : int
    {
        None = 0,
        Bars8 = 1,
        Bars4 = 2,
        Bars2 = 3,
        Bar = 4,
        HalfNote = 5,
        HalfNoteTriplet = 6,
        QuarterNote = 7,
        QuarterNoteTriplet = 8,
        EighthNote = 9,
        EighthNoteTriplet = 10,
        SixteenthNote = 11,
        SixteenthNoteTriplet = 12,
        ThirtySecondNote = 13,
        Count = 14,
        ETimeSynthEventQuantization_MAX = 15,
    }
    public enum ETimeSynthEnvelopeFollowerPeakMode : int
    {
        MeanSquared = 0,
        RootMeanSquared = 1,
        Peak = 2,
        Count = 3,
        ETimeSynthEnvelopeFollowerPeakMode_MAX = 4,
    }
    public enum ETimeSynthFilterType : int
    {
        LowPass = 0,
        HighPass = 1,
        BandPass = 2,
        BandStop = 3,
        Count = 4,
        ETimeSynthFilterType_MAX = 5,
    }
    public enum ETimeSynthFilter : int
    {
        FilterA = 0,
        FilterB = 1,
        Count = 2,
        ETimeSynthFilter_MAX = 3,
    }
    public enum ETimeSynthEventClipQuantization : int
    {
        Global = 0,
        None = 1,
        Bars8 = 2,
        Bars4 = 3,
        Bars2 = 4,
        Bar = 5,
        HalfNote = 6,
        HalfNoteTriplet = 7,
        QuarterNote = 8,
        QuarterNoteTriplet = 9,
        EighthNote = 10,
        EighthNoteTriplet = 11,
        SixteenthNote = 12,
        SixteenthNoteTriplet = 13,
        ThirtySecondNote = 14,
        Count = 15,
        ETimeSynthEventClipQuantization_MAX = 16,
    }
    public enum ETimeSynthFFTSize : int
    {
        Min_65 = 0,
        Small_257 = 1,
        Medium_513 = 2,
        Large_1025 = 3,
        ETimeSynthFFTSize_MAX = 4,
    }
    public enum ETimeSynthBeatDivision : int
    {
        One = 0,
        Two = 1,
        Four = 2,
        Eight = 3,
        Sixteen = 4,
        Count = 5,
        ETimeSynthBeatDivision_MAX = 6,
    }
    public class TimeSynthEnvelopeFollowerSettings : Object
    {
        public TimeSynthEnvelopeFollowerSettings(ulong addr) : base(addr) { }
        public float AttackTime { get { return this[nameof(AttackTime)].GetValue<float>(); } set { this[nameof(AttackTime)].SetValue<float>(value); } }
        public float ReleaseTime { get { return this[nameof(ReleaseTime)].GetValue<float>(); } set { this[nameof(ReleaseTime)].SetValue<float>(value); } }
        public ETimeSynthEnvelopeFollowerPeakMode PeakMode { get { return (ETimeSynthEnvelopeFollowerPeakMode)this[nameof(PeakMode)].GetValue<int>(); } set { this[nameof(PeakMode)].SetValue<int>((int)value); } }
        public bool bIsAnalogMode { get { return this[nameof(bIsAnalogMode)].Flag; } set { this[nameof(bIsAnalogMode)].Flag = value; } }
    }
    public class TimeSynthFilterSettings : Object
    {
        public TimeSynthFilterSettings(ulong addr) : base(addr) { }
        public ETimeSynthFilterType FilterType { get { return (ETimeSynthFilterType)this[nameof(FilterType)].GetValue<int>(); } set { this[nameof(FilterType)].SetValue<int>((int)value); } }
        public float CutoffFrequency { get { return this[nameof(CutoffFrequency)].GetValue<float>(); } set { this[nameof(CutoffFrequency)].SetValue<float>(value); } }
        public float FilterQ { get { return this[nameof(FilterQ)].GetValue<float>(); } set { this[nameof(FilterQ)].SetValue<float>(value); } }
    }
    public class TimeSynthClipSound : Object
    {
        public TimeSynthClipSound(ulong addr) : base(addr) { }
        public SoundWave SoundWave { get { return this[nameof(SoundWave)].As<SoundWave>(); } set { this["SoundWave"] = value; } }
        public float RandomWeight { get { return this[nameof(RandomWeight)].GetValue<float>(); } set { this[nameof(RandomWeight)].SetValue<float>(value); } }
        public Vector2D DistanceRange { get { return this[nameof(DistanceRange)].As<Vector2D>(); } set { this["DistanceRange"] = value; } }
    }
    public class TimeSynthClipHandle : Object
    {
        public TimeSynthClipHandle(ulong addr) : base(addr) { }
        public Object ClipName { get { return this[nameof(ClipName)]; } set { this[nameof(ClipName)] = value; } }
        public int ClipId { get { return this[nameof(ClipId)].GetValue<int>(); } set { this[nameof(ClipId)].SetValue<int>(value); } }
    }
    public class TimeSynthTimeDef : Object
    {
        public TimeSynthTimeDef(ulong addr) : base(addr) { }
        public int NumBars { get { return this[nameof(NumBars)].GetValue<int>(); } set { this[nameof(NumBars)].SetValue<int>(value); } }
        public int NumBeats { get { return this[nameof(NumBeats)].GetValue<int>(); } set { this[nameof(NumBeats)].SetValue<int>(value); } }
    }
    public class TimeSynthQuantizationSettings : Object
    {
        public TimeSynthQuantizationSettings(ulong addr) : base(addr) { }
        public float BeatsPerMinute { get { return this[nameof(BeatsPerMinute)].GetValue<float>(); } set { this[nameof(BeatsPerMinute)].SetValue<float>(value); } }
        public int BeatsPerBar { get { return this[nameof(BeatsPerBar)].GetValue<int>(); } set { this[nameof(BeatsPerBar)].SetValue<int>(value); } }
        public ETimeSynthBeatDivision BeatDivision { get { return (ETimeSynthBeatDivision)this[nameof(BeatDivision)].GetValue<int>(); } set { this[nameof(BeatDivision)].SetValue<int>((int)value); } }
        public float EventDelaySeconds { get { return this[nameof(EventDelaySeconds)].GetValue<float>(); } set { this[nameof(EventDelaySeconds)].SetValue<float>(value); } }
        public ETimeSynthEventQuantization GlobalQuantization { get { return (ETimeSynthEventQuantization)this[nameof(GlobalQuantization)].GetValue<int>(); } set { this[nameof(GlobalQuantization)].SetValue<int>((int)value); } }
    }
    public class TimeSynthSpectralData : Object
    {
        public TimeSynthSpectralData(ulong addr) : base(addr) { }
        public float FrequencyHz { get { return this[nameof(FrequencyHz)].GetValue<float>(); } set { this[nameof(FrequencyHz)].SetValue<float>(value); } }
        public float Magnitude { get { return this[nameof(Magnitude)].GetValue<float>(); } set { this[nameof(Magnitude)].SetValue<float>(value); } }
    }
}
