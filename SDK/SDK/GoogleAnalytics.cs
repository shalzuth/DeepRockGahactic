using UnrealSharp;
using Object = UnrealSharp.UEObject;
using SDK.Script.EngineSDK;
namespace SDK.Script.GoogleAnalyticsSDK
{
    public class GoogleAnalyticsBlueprintLibrary : BlueprintFunctionLibrary
    {
        public GoogleAnalyticsBlueprintLibrary(ulong addr) : base(addr) { }
        public void SetTrackingId(Object TrackingId) { Invoke(nameof(SetTrackingId), TrackingId); }
        public void SetAnonymizeIP(bool Anonymize) { Invoke(nameof(SetAnonymizeIP), Anonymize); }
        public void RecordGoogleUserTiming(Object TimingCategory, int TimingValue, Object TimingName, Array<CustomDimension> CustomDimensions, Array<CustomMetric> CustomMetrics) { Invoke(nameof(RecordGoogleUserTiming), TimingCategory, TimingValue, TimingName, CustomDimensions, CustomMetrics); }
        public void RecordGoogleSocialInteraction(Object SocialNetwork, Object SocialAction, Object SocialTarget, Array<CustomDimension> CustomDimensions, Array<CustomMetric> CustomMetrics) { Invoke(nameof(RecordGoogleSocialInteraction), SocialNetwork, SocialAction, SocialTarget, CustomDimensions, CustomMetrics); }
        public void RecordGoogleScreen(Object ScreenName, Array<CustomDimension> CustomDimensions, Array<CustomMetric> CustomMetrics) { Invoke(nameof(RecordGoogleScreen), ScreenName, CustomDimensions, CustomMetrics); }
        public void RecordGoogleEvent(Object EventCategory, Object EventAction, Object EventLabel, int EventValue, Array<CustomDimension> CustomDimensions, Array<CustomMetric> CustomMetrics) { Invoke(nameof(RecordGoogleEvent), EventCategory, EventAction, EventLabel, EventValue, CustomDimensions, CustomMetrics); }
        public Object GetTrackingId() { return Invoke<Object>(nameof(GetTrackingId)); }
    }
    public class GoogleAnalyticsSettings : Object
    {
        public GoogleAnalyticsSettings(ulong addr) : base(addr) { }
        public bool bEnableIDFACollection { get { return this[nameof(bEnableIDFACollection)].Flag; } set { this[nameof(bEnableIDFACollection)].Flag = value; } }
    }
    public class CustomMetric : Object
    {
        public CustomMetric(ulong addr) : base(addr) { }
        public int Index { get { return this[nameof(Index)].GetValue<int>(); } set { this[nameof(Index)].SetValue<int>(value); } }
        public float Value { get { return this[nameof(Value)].GetValue<float>(); } set { this[nameof(Value)].SetValue<float>(value); } }
    }
    public class CustomDimension : Object
    {
        public CustomDimension(ulong addr) : base(addr) { }
        public int Index { get { return this[nameof(Index)].GetValue<int>(); } set { this[nameof(Index)].SetValue<int>(value); } }
        public Object Value { get { return this[nameof(Value)]; } set { this[nameof(Value)] = value; } }
    }
}
