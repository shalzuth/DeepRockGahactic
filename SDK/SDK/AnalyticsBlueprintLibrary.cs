using UnrealSharp;
using Object = UnrealSharp.UEObject;
using SDK.Script.EngineSDK;
namespace SDK.Script.AnalyticsBlueprintLibrarySDK
{
    public class AnalyticsBlueprintLibrary : BlueprintFunctionLibrary
    {
        public AnalyticsBlueprintLibrary(ulong addr) : base(addr) { }
        public bool StartSessionWithAttributes(Array<AnalyticsEventAttr> Attributes) { return Invoke<bool>(nameof(StartSessionWithAttributes), Attributes); }
        public bool StartSession() { return Invoke<bool>(nameof(StartSession)); }
        public void SetUserId(Object userId) { Invoke(nameof(SetUserId), userId); }
        public void SetSessionId(Object sessionId) { Invoke(nameof(SetSessionId), sessionId); }
        public void SetLocation(Object Location) { Invoke(nameof(SetLocation), Location); }
        public void SetGender(Object Gender) { Invoke(nameof(SetGender), Gender); }
        public void SetBuildInfo(Object BuildInfo) { Invoke(nameof(SetBuildInfo), BuildInfo); }
        public void SetAge(int Age) { Invoke(nameof(SetAge), Age); }
        public void RecordSimpleItemPurchaseWithAttributes(Object ItemID, int ItemQuantity, Array<AnalyticsEventAttr> Attributes) { Invoke(nameof(RecordSimpleItemPurchaseWithAttributes), ItemID, ItemQuantity, Attributes); }
        public void RecordSimpleItemPurchase(Object ItemID, int ItemQuantity) { Invoke(nameof(RecordSimpleItemPurchase), ItemID, ItemQuantity); }
        public void RecordSimpleCurrencyPurchaseWithAttributes(Object GameCurrencyType, int GameCurrencyAmount, Array<AnalyticsEventAttr> Attributes) { Invoke(nameof(RecordSimpleCurrencyPurchaseWithAttributes), GameCurrencyType, GameCurrencyAmount, Attributes); }
        public void RecordSimpleCurrencyPurchase(Object GameCurrencyType, int GameCurrencyAmount) { Invoke(nameof(RecordSimpleCurrencyPurchase), GameCurrencyType, GameCurrencyAmount); }
        public void RecordProgressWithFullHierarchyAndAttributes(Object ProgressType, Array<Object> ProgressNames, Array<AnalyticsEventAttr> Attributes) { Invoke(nameof(RecordProgressWithFullHierarchyAndAttributes), ProgressType, ProgressNames, Attributes); }
        public void RecordProgressWithAttributes(Object ProgressType, Object ProgressName, Array<AnalyticsEventAttr> Attributes) { Invoke(nameof(RecordProgressWithAttributes), ProgressType, ProgressName, Attributes); }
        public void RecordProgress(Object ProgressType, Object ProgressName) { Invoke(nameof(RecordProgress), ProgressType, ProgressName); }
        public void RecordItemPurchase(Object ItemID, Object Currency, int PerItemCost, int ItemQuantity) { Invoke(nameof(RecordItemPurchase), ItemID, Currency, PerItemCost, ItemQuantity); }
        public void RecordEventWithAttributes(Object EventName, Array<AnalyticsEventAttr> Attributes) { Invoke(nameof(RecordEventWithAttributes), EventName, Attributes); }
        public void RecordEventWithAttribute(Object EventName, Object AttributeName, Object AttributeValue) { Invoke(nameof(RecordEventWithAttribute), EventName, AttributeName, AttributeValue); }
        public void RecordEvent(Object EventName) { Invoke(nameof(RecordEvent), EventName); }
        public void RecordErrorWithAttributes(Object Error, Array<AnalyticsEventAttr> Attributes) { Invoke(nameof(RecordErrorWithAttributes), Error, Attributes); }
        public void RecordError(Object Error) { Invoke(nameof(RecordError), Error); }
        public void RecordCurrencyPurchase(Object GameCurrencyType, int GameCurrencyAmount, Object RealCurrencyType, float RealMoneyCost, Object PaymentProvider) { Invoke(nameof(RecordCurrencyPurchase), GameCurrencyType, GameCurrencyAmount, RealCurrencyType, RealMoneyCost, PaymentProvider); }
        public void RecordCurrencyGivenWithAttributes(Object GameCurrencyType, int GameCurrencyAmount, Array<AnalyticsEventAttr> Attributes) { Invoke(nameof(RecordCurrencyGivenWithAttributes), GameCurrencyType, GameCurrencyAmount, Attributes); }
        public void RecordCurrencyGiven(Object GameCurrencyType, int GameCurrencyAmount) { Invoke(nameof(RecordCurrencyGiven), GameCurrencyType, GameCurrencyAmount); }
        public AnalyticsEventAttr MakeEventAttribute(Object AttributeName, Object AttributeValue) { return Invoke<AnalyticsEventAttr>(nameof(MakeEventAttribute), AttributeName, AttributeValue); }
        public Object GetUserId() { return Invoke<Object>(nameof(GetUserId)); }
        public Object GetSessionId() { return Invoke<Object>(nameof(GetSessionId)); }
        public void FlushEvents() { Invoke(nameof(FlushEvents)); }
        public void EndSession() { Invoke(nameof(EndSession)); }
    }
    public class AnalyticsEventAttr : Object
    {
        public AnalyticsEventAttr(ulong addr) : base(addr) { }
        public Object Name { get { return this[nameof(Name)]; } set { this[nameof(Name)] = value; } }
        public Object Value { get { return this[nameof(Value)]; } set { this[nameof(Value)] = value; } }
    }
}
