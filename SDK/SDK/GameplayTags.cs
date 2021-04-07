using UnrealSharp;
using Object = UnrealSharp.UEObject;
using SDK.Script.EngineSDK;
using SDK.Script.CoreUObjectSDK;
namespace SDK.Script.GameplayTagsSDK
{
    public class BlueprintGameplayTagLibrary : BlueprintFunctionLibrary
    {
        public BlueprintGameplayTagLibrary(ulong addr) : base(addr) { }
        public bool RemoveGameplayTag(GameplayTagContainer TagContainer, GameplayTag Tag) { return Invoke<bool>(nameof(RemoveGameplayTag), TagContainer, Tag); }
        public bool NotEqual_TagTag(GameplayTag A, Object B) { return Invoke<bool>(nameof(NotEqual_TagTag), A, B); }
        public bool NotEqual_TagContainerTagContainer(GameplayTagContainer A, Object B) { return Invoke<bool>(nameof(NotEqual_TagContainerTagContainer), A, B); }
        public bool NotEqual_GameplayTagContainer(GameplayTagContainer A, GameplayTagContainer B) { return Invoke<bool>(nameof(NotEqual_GameplayTagContainer), A, B); }
        public bool NotEqual_GameplayTag(GameplayTag A, GameplayTag B) { return Invoke<bool>(nameof(NotEqual_GameplayTag), A, B); }
        public bool MatchesTag(GameplayTag TagOne, GameplayTag TagTwo, bool bExactMatch) { return Invoke<bool>(nameof(MatchesTag), TagOne, TagTwo, bExactMatch); }
        public bool MatchesAnyTags(GameplayTag TagOne, GameplayTagContainer OtherContainer, bool bExactMatch) { return Invoke<bool>(nameof(MatchesAnyTags), TagOne, OtherContainer, bExactMatch); }
        public GameplayTagContainer MakeLiteralGameplayTagContainer(GameplayTagContainer Value) { return Invoke<GameplayTagContainer>(nameof(MakeLiteralGameplayTagContainer), Value); }
        public GameplayTag MakeLiteralGameplayTag(GameplayTag Value) { return Invoke<GameplayTag>(nameof(MakeLiteralGameplayTag), Value); }
        public GameplayTagQuery MakeGameplayTagQuery(GameplayTagQuery tagQuery) { return Invoke<GameplayTagQuery>(nameof(MakeGameplayTagQuery), tagQuery); }
        public GameplayTagContainer MakeGameplayTagContainerFromTag(GameplayTag SingleTag) { return Invoke<GameplayTagContainer>(nameof(MakeGameplayTagContainerFromTag), SingleTag); }
        public GameplayTagContainer MakeGameplayTagContainerFromArray(Array<GameplayTag> GameplayTags) { return Invoke<GameplayTagContainer>(nameof(MakeGameplayTagContainerFromArray), GameplayTags); }
        public bool IsTagQueryEmpty(GameplayTagQuery tagQuery) { return Invoke<bool>(nameof(IsTagQueryEmpty), tagQuery); }
        public bool IsGameplayTagValid(GameplayTag GameplayTag) { return Invoke<bool>(nameof(IsGameplayTagValid), GameplayTag); }
        public bool HasTag(GameplayTagContainer TagContainer, GameplayTag Tag, bool bExactMatch) { return Invoke<bool>(nameof(HasTag), TagContainer, Tag, bExactMatch); }
        public bool HasAnyTags(GameplayTagContainer TagContainer, GameplayTagContainer OtherContainer, bool bExactMatch) { return Invoke<bool>(nameof(HasAnyTags), TagContainer, OtherContainer, bExactMatch); }
        public bool HasAllTags(GameplayTagContainer TagContainer, GameplayTagContainer OtherContainer, bool bExactMatch) { return Invoke<bool>(nameof(HasAllTags), TagContainer, OtherContainer, bExactMatch); }
        public bool HasAllMatchingGameplayTags(Object TagContainerInterface, GameplayTagContainer OtherContainer) { return Invoke<bool>(nameof(HasAllMatchingGameplayTags), TagContainerInterface, OtherContainer); }
        public Object GetTagName(GameplayTag GameplayTag) { return Invoke<Object>(nameof(GetTagName), GameplayTag); }
        public int GetNumGameplayTagsInContainer(GameplayTagContainer TagContainer) { return Invoke<int>(nameof(GetNumGameplayTagsInContainer), TagContainer); }
        public Object GetDebugStringFromGameplayTagContainer(GameplayTagContainer TagContainer) { return Invoke<Object>(nameof(GetDebugStringFromGameplayTagContainer), TagContainer); }
        public Object GetDebugStringFromGameplayTag(GameplayTag GameplayTag) { return Invoke<Object>(nameof(GetDebugStringFromGameplayTag), GameplayTag); }
        public void GetAllActorsOfClassMatchingTagQuery(Object WorldContextObject, Object ActorClass, GameplayTagQuery GameplayTagQuery, Array<Actor> OutActors) { Invoke(nameof(GetAllActorsOfClassMatchingTagQuery), WorldContextObject, ActorClass, GameplayTagQuery, OutActors); }
        public bool EqualEqual_GameplayTagContainer(GameplayTagContainer A, GameplayTagContainer B) { return Invoke<bool>(nameof(EqualEqual_GameplayTagContainer), A, B); }
        public bool EqualEqual_GameplayTag(GameplayTag A, GameplayTag B) { return Invoke<bool>(nameof(EqualEqual_GameplayTag), A, B); }
        public bool DoesTagAssetInterfaceHaveTag(Object TagContainerInterface, GameplayTag Tag) { return Invoke<bool>(nameof(DoesTagAssetInterfaceHaveTag), TagContainerInterface, Tag); }
        public bool DoesContainerMatchTagQuery(GameplayTagContainer TagContainer, GameplayTagQuery tagQuery) { return Invoke<bool>(nameof(DoesContainerMatchTagQuery), TagContainer, tagQuery); }
        public void BreakGameplayTagContainer(GameplayTagContainer GameplayTagContainer, Array<GameplayTag> GameplayTags) { Invoke(nameof(BreakGameplayTagContainer), GameplayTagContainer, GameplayTags); }
        public void AppendGameplayTagContainers(GameplayTagContainer InOutTagContainer, GameplayTagContainer InTagContainer) { Invoke(nameof(AppendGameplayTagContainers), InOutTagContainer, InTagContainer); }
        public void AddGameplayTag(GameplayTagContainer TagContainer, GameplayTag Tag) { Invoke(nameof(AddGameplayTag), TagContainer, Tag); }
    }
    public class GameplayTagAssetInterface : Interface
    {
        public GameplayTagAssetInterface(ulong addr) : base(addr) { }
        public bool HasMatchingGameplayTag(GameplayTag TagToCheck) { return Invoke<bool>(nameof(HasMatchingGameplayTag), TagToCheck); }
        public bool HasAnyMatchingGameplayTags(GameplayTagContainer TagContainer) { return Invoke<bool>(nameof(HasAnyMatchingGameplayTags), TagContainer); }
        public bool HasAllMatchingGameplayTags(GameplayTagContainer TagContainer) { return Invoke<bool>(nameof(HasAllMatchingGameplayTags), TagContainer); }
        public void GetOwnedGameplayTags(GameplayTagContainer TagContainer) { Invoke(nameof(GetOwnedGameplayTags), TagContainer); }
    }
    public class EditableGameplayTagQuery : Object
    {
        public EditableGameplayTagQuery(ulong addr) : base(addr) { }
        public Object UserDescription { get { return this[nameof(UserDescription)]; } set { this[nameof(UserDescription)] = value; } }
        public EditableGameplayTagQueryExpression RootExpression { get { return this[nameof(RootExpression)].As<EditableGameplayTagQueryExpression>(); } set { this["RootExpression"] = value; } }
        public GameplayTagQuery TagQueryExportText_Helper { get { return this[nameof(TagQueryExportText_Helper)].As<GameplayTagQuery>(); } set { this["TagQueryExportText_Helper"] = value; } }
    }
    public class EditableGameplayTagQueryExpression : Object
    {
        public EditableGameplayTagQueryExpression(ulong addr) : base(addr) { }
    }
    public class EditableGameplayTagQueryExpression_AnyTagsMatch : EditableGameplayTagQueryExpression
    {
        public EditableGameplayTagQueryExpression_AnyTagsMatch(ulong addr) : base(addr) { }
        public GameplayTagContainer Tags { get { return this[nameof(Tags)].As<GameplayTagContainer>(); } set { this["Tags"] = value; } }
    }
    public class EditableGameplayTagQueryExpression_AllTagsMatch : EditableGameplayTagQueryExpression
    {
        public EditableGameplayTagQueryExpression_AllTagsMatch(ulong addr) : base(addr) { }
        public GameplayTagContainer Tags { get { return this[nameof(Tags)].As<GameplayTagContainer>(); } set { this["Tags"] = value; } }
    }
    public class EditableGameplayTagQueryExpression_NoTagsMatch : EditableGameplayTagQueryExpression
    {
        public EditableGameplayTagQueryExpression_NoTagsMatch(ulong addr) : base(addr) { }
        public GameplayTagContainer Tags { get { return this[nameof(Tags)].As<GameplayTagContainer>(); } set { this["Tags"] = value; } }
    }
    public class EditableGameplayTagQueryExpression_AnyExprMatch : EditableGameplayTagQueryExpression
    {
        public EditableGameplayTagQueryExpression_AnyExprMatch(ulong addr) : base(addr) { }
        public Array<EditableGameplayTagQueryExpression> Expressions { get { return new Array<EditableGameplayTagQueryExpression>(this[nameof(Expressions)].Address); } }
    }
    public class EditableGameplayTagQueryExpression_AllExprMatch : EditableGameplayTagQueryExpression
    {
        public EditableGameplayTagQueryExpression_AllExprMatch(ulong addr) : base(addr) { }
        public Array<EditableGameplayTagQueryExpression> Expressions { get { return new Array<EditableGameplayTagQueryExpression>(this[nameof(Expressions)].Address); } }
    }
    public class EditableGameplayTagQueryExpression_NoExprMatch : EditableGameplayTagQueryExpression
    {
        public EditableGameplayTagQueryExpression_NoExprMatch(ulong addr) : base(addr) { }
        public Array<EditableGameplayTagQueryExpression> Expressions { get { return new Array<EditableGameplayTagQueryExpression>(this[nameof(Expressions)].Address); } }
    }
    public class GameplayTagsManager : Object
    {
        public GameplayTagsManager(ulong addr) : base(addr) { }
        public Array<GameplayTagSource> TagSources { get { return new Array<GameplayTagSource>(this[nameof(TagSources)].Address); } }
        public Array<DataTable> GameplayTagTables { get { return new Array<DataTable>(this[nameof(GameplayTagTables)].Address); } }
    }
    public class GameplayTagsList : Object
    {
        public GameplayTagsList(ulong addr) : base(addr) { }
        public Object ConfigFileName { get { return this[nameof(ConfigFileName)]; } set { this[nameof(ConfigFileName)] = value; } }
        public Array<GameplayTagTableRow> GameplayTagList { get { return new Array<GameplayTagTableRow>(this[nameof(GameplayTagList)].Address); } }
    }
    public class RestrictedGameplayTagsList : Object
    {
        public RestrictedGameplayTagsList(ulong addr) : base(addr) { }
        public Object ConfigFileName { get { return this[nameof(ConfigFileName)]; } set { this[nameof(ConfigFileName)] = value; } }
        public Array<RestrictedGameplayTagTableRow> RestrictedGameplayTagList { get { return new Array<RestrictedGameplayTagTableRow>(this[nameof(RestrictedGameplayTagList)].Address); } }
    }
    public class GameplayTagsSettings : GameplayTagsList
    {
        public GameplayTagsSettings(ulong addr) : base(addr) { }
        public bool ImportTagsFromConfig { get { return this[nameof(ImportTagsFromConfig)].Flag; } set { this[nameof(ImportTagsFromConfig)].Flag = value; } }
        public bool WarnOnInvalidTags { get { return this[nameof(WarnOnInvalidTags)].Flag; } set { this[nameof(WarnOnInvalidTags)].Flag = value; } }
        public bool FastReplication { get { return this[nameof(FastReplication)].Flag; } set { this[nameof(FastReplication)].Flag = value; } }
        public Object InvalidTagCharacters { get { return this[nameof(InvalidTagCharacters)]; } set { this[nameof(InvalidTagCharacters)] = value; } }
        public Array<GameplayTagCategoryRemap> CategoryRemapping { get { return new Array<GameplayTagCategoryRemap>(this[nameof(CategoryRemapping)].Address); } }
        public Array<SoftObjectPath> GameplayTagTableList { get { return new Array<SoftObjectPath>(this[nameof(GameplayTagTableList)].Address); } }
        public Array<GameplayTagRedirect> GameplayTagRedirects { get { return new Array<GameplayTagRedirect>(this[nameof(GameplayTagRedirects)].Address); } }
        public Array<Object> CommonlyReplicatedTags { get { return new Array<Object>(this[nameof(CommonlyReplicatedTags)].Address); } }
        public int NumBitsForContainerSize { get { return this[nameof(NumBitsForContainerSize)].GetValue<int>(); } set { this[nameof(NumBitsForContainerSize)].SetValue<int>(value); } }
        public int NetIndexFirstBitSegment { get { return this[nameof(NetIndexFirstBitSegment)].GetValue<int>(); } set { this[nameof(NetIndexFirstBitSegment)].SetValue<int>(value); } }
        public Array<RestrictedConfigInfo> RestrictedConfigFiles { get { return new Array<RestrictedConfigInfo>(this[nameof(RestrictedConfigFiles)].Address); } }
    }
    public class GameplayTagsDeveloperSettings : Object
    {
        public GameplayTagsDeveloperSettings(ulong addr) : base(addr) { }
        public Object DeveloperConfigName { get { return this[nameof(DeveloperConfigName)]; } set { this[nameof(DeveloperConfigName)] = value; } }
    }
    public class GameplayTagContainer : Object
    {
        public GameplayTagContainer(ulong addr) : base(addr) { }
        public Array<GameplayTag> GameplayTags { get { return new Array<GameplayTag>(this[nameof(GameplayTags)].Address); } }
        public Array<GameplayTag> ParentTags { get { return new Array<GameplayTag>(this[nameof(ParentTags)].Address); } }
    }
    public class GameplayTag : Object
    {
        public GameplayTag(ulong addr) : base(addr) { }
        public Object TagName { get { return this[nameof(TagName)]; } set { this[nameof(TagName)] = value; } }
    }
    public class GameplayTagQuery : Object
    {
        public GameplayTagQuery(ulong addr) : base(addr) { }
        public int TokenStreamVersion { get { return this[nameof(TokenStreamVersion)].GetValue<int>(); } set { this[nameof(TokenStreamVersion)].SetValue<int>(value); } }
        public Array<GameplayTag> TagDictionary { get { return new Array<GameplayTag>(this[nameof(TagDictionary)].Address); } }
        public Array<byte> QueryTokenStream { get { return new Array<byte>(this[nameof(QueryTokenStream)].Address); } }
        public Object UserDescription { get { return this[nameof(UserDescription)]; } set { this[nameof(UserDescription)] = value; } }
        public Object AutoDescription { get { return this[nameof(AutoDescription)]; } set { this[nameof(AutoDescription)] = value; } }
    }
    public enum EGameplayTagQueryExprType : int
    {
        Undefined = 0,
        AnyTagsMatch = 1,
        AllTagsMatch = 2,
        NoTagsMatch = 3,
        AnyExprMatch = 4,
        AllExprMatch = 5,
        NoExprMatch = 6,
        EGameplayTagQueryExprType_MAX = 7,
    }
    public enum EGameplayContainerMatchType : int
    {
        Any = 0,
        All = 1,
        EGameplayContainerMatchType_MAX = 2,
    }
    public enum EGameplayTagMatchType : int
    {
        Explicit = 0,
        IncludeParentTags = 1,
        EGameplayTagMatchType_MAX = 2,
    }
    public enum EGameplayTagSelectionType : int
    {
        None = 0,
        NonRestrictedOnly = 1,
        RestrictedOnly = 2,
        All = 3,
        EGameplayTagSelectionType_MAX = 4,
    }
    public enum EGameplayTagSourceType : int
    {
        Native = 0,
        DefaultTagList = 1,
        TagList = 2,
        RestrictedTagList = 3,
        DataTable = 4,
        Invalid = 5,
        EGameplayTagSourceType_MAX = 6,
    }
    public class GameplayTagCreationWidgetHelper : Object
    {
        public GameplayTagCreationWidgetHelper(ulong addr) : base(addr) { }
    }
    public class GameplayTagReferenceHelper : Object
    {
        public GameplayTagReferenceHelper(ulong addr) : base(addr) { }
    }
    public class GameplayTagNode : Object
    {
        public GameplayTagNode(ulong addr) : base(addr) { }
    }
    public class GameplayTagSource : Object
    {
        public GameplayTagSource(ulong addr) : base(addr) { }
        public Object SourceName { get { return this[nameof(SourceName)]; } set { this[nameof(SourceName)] = value; } }
        public EGameplayTagSourceType SourceType { get { return (EGameplayTagSourceType)this[nameof(SourceType)].GetValue<int>(); } set { this[nameof(SourceType)].SetValue<int>((int)value); } }
        public GameplayTagsList SourceTagList { get { return this[nameof(SourceTagList)].As<GameplayTagsList>(); } set { this["SourceTagList"] = value; } }
        public RestrictedGameplayTagsList SourceRestrictedTagList { get { return this[nameof(SourceRestrictedTagList)].As<RestrictedGameplayTagsList>(); } set { this["SourceRestrictedTagList"] = value; } }
    }
    public class GameplayTagTableRow : TableRowBase
    {
        public GameplayTagTableRow(ulong addr) : base(addr) { }
        public Object Tag { get { return this[nameof(Tag)]; } set { this[nameof(Tag)] = value; } }
        public Object DevComment { get { return this[nameof(DevComment)]; } set { this[nameof(DevComment)] = value; } }
    }
    public class RestrictedGameplayTagTableRow : GameplayTagTableRow
    {
        public RestrictedGameplayTagTableRow(ulong addr) : base(addr) { }
        public bool bAllowNonRestrictedChildren { get { return this[nameof(bAllowNonRestrictedChildren)].Flag; } set { this[nameof(bAllowNonRestrictedChildren)].Flag = value; } }
    }
    public class RestrictedConfigInfo : Object
    {
        public RestrictedConfigInfo(ulong addr) : base(addr) { }
        public Object RestrictedConfigName { get { return this[nameof(RestrictedConfigName)]; } set { this[nameof(RestrictedConfigName)] = value; } }
        public Array<Object> Owners { get { return new Array<Object>(this[nameof(Owners)].Address); } }
    }
    public class GameplayTagCategoryRemap : Object
    {
        public GameplayTagCategoryRemap(ulong addr) : base(addr) { }
        public Object BaseCategory { get { return this[nameof(BaseCategory)]; } set { this[nameof(BaseCategory)] = value; } }
        public Array<Object> RemapCategories { get { return new Array<Object>(this[nameof(RemapCategories)].Address); } }
    }
    public class GameplayTagRedirect : Object
    {
        public GameplayTagRedirect(ulong addr) : base(addr) { }
        public Object OldTagName { get { return this[nameof(OldTagName)]; } set { this[nameof(OldTagName)] = value; } }
        public Object NewTagName { get { return this[nameof(NewTagName)]; } set { this[nameof(NewTagName)] = value; } }
    }
}
