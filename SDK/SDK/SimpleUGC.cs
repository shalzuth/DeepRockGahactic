using UnrealSharp;
using Object = UnrealSharp.UEObject;
using SDK.Script.EngineSDK;
namespace SDK.Script.SimpleUGCSDK
{
    public class MakeReplaceableActorComponent : ActorComponent
    {
        public MakeReplaceableActorComponent(ulong addr) : base(addr) { }
        public Object CompatibleReplacement { get { return this[nameof(CompatibleReplacement)]; } set { this[nameof(CompatibleReplacement)] = value; } }
    }
    public class ReplacementActorComponent : ActorComponent
    {
        public ReplacementActorComponent(ulong addr) : base(addr) { }
        public Array<Object> ActorClassesToReplace { get { return new Array<Object>(this[nameof(ActorClassesToReplace)].Address); } }
    }
    public class UGCBaseGameInstance : GameInstance
    {
        public UGCBaseGameInstance(ulong addr) : base(addr) { }
        public UGCRegistry UGCRegistry { get { return this[nameof(UGCRegistry)].As<UGCRegistry>(); } set { this["UGCRegistry"] = value; } }
    }
    public class UGCBlueprintLibrary : BlueprintFunctionLibrary
    {
        public UGCBlueprintLibrary(ulong addr) : base(addr) { }
        public UGCRegistry GetUGCRegistry(Object WorldContextObject) { return Invoke<UGCRegistry>(nameof(GetUGCRegistry), WorldContextObject); }
    }
    public class UGCRegistry : Object
    {
        public UGCRegistry(ulong addr) : base(addr) { }
        public Array<UGCPackage> UGCPackages { get { return new Array<UGCPackage>(this[nameof(UGCPackages)].Address); } }
        public Object RegisteredOverrides { get { return this[nameof(RegisteredOverrides)]; } set { this[nameof(RegisteredOverrides)] = value; } }
        public void UnmountUGCPackagesWithWrongMetadata() { Invoke(nameof(UnmountUGCPackagesWithWrongMetadata)); }
        public bool UnmountUGCPackage(UGCPackage Package) { return Invoke<bool>(nameof(UnmountUGCPackage), Package); }
        public bool UGCPackagesInstalledInDeprecatedLocation(Array<Object> OutNameOfPackages) { return Invoke<bool>(nameof(UGCPackagesInstalledInDeprecatedLocation), OutNameOfPackages); }
        public void RegisterOverrideForClass(Object ClassToOverride, Object OverrideClass) { Invoke(nameof(RegisterOverrideForClass), ClassToOverride, OverrideClass); }
        public Mods PackRequiredByAllModsInStructForSession() { return Invoke<Mods>(nameof(PackRequiredByAllModsInStructForSession)); }
        public bool MountUGCPackage(UGCPackage Package) { return Invoke<bool>(nameof(MountUGCPackage), Package); }
        public Object GetOverrideForActorClass(Object ActorClass) { return Invoke<Object>(nameof(GetOverrideForActorClass), ActorClass); }
        public bool GetMapsInPackage(UGCPackage Package, Array<Object> Maps) { return Invoke<bool>(nameof(GetMapsInPackage), Package, Maps); }
        public bool GetAllClassesInPackage(UGCPackage Package, Array<Object> Classes) { return Invoke<bool>(nameof(GetAllClassesInPackage), Package, Classes); }
        public bool GetActorClassesWithReplacementActorComponentsInPackage(UGCPackage Package, Array<Object> ActorClasses) { return Invoke<bool>(nameof(GetActorClassesWithReplacementActorComponentsInPackage), Package, ActorClasses); }
        public bool FindUGCPackages() { return Invoke<bool>(nameof(FindUGCPackages)); }
        public void ClearOverrideForClass(Object ActorClass) { Invoke(nameof(ClearOverrideForClass), ActorClass); }
        public bool AreAnyModsInstalled(bool IncludeDeprecatedLocation) { return Invoke<bool>(nameof(AreAnyModsInstalled), IncludeDeprecatedLocation); }
        public bool ApplyOverridesForActorClass(Object ActorClass) { return Invoke<bool>(nameof(ApplyOverridesForActorClass), ActorClass); }
        public bool ApplyAllOverridesInPackage(UGCPackage Package) { return Invoke<bool>(nameof(ApplyAllOverridesInPackage), Package); }
    }
    public enum EUGCCategory : int
    {
        Cosmetic = 0,
        ServerOnly = 1,
        RequiredByAll = 2,
        EUGCCategory_MAX = 3,
    }
    public class UGCPackage : Object
    {
        public UGCPackage(ulong addr) : base(addr) { }
        public Object PackageName { get { return this[nameof(PackageName)]; } set { this[nameof(PackageName)] = value; } }
        public Object PackageVersion { get { return this[nameof(PackageVersion)]; } set { this[nameof(PackageVersion)] = value; } }
        public EUGCCategory Category { get { return (EUGCCategory)this[nameof(Category)].GetValue<int>(); } set { this[nameof(Category)].SetValue<int>((int)value); } }
        public Object PakFilePath { get { return this[nameof(PakFilePath)]; } set { this[nameof(PakFilePath)] = value; } }
        public Object PackagePath { get { return this[nameof(PackagePath)]; } set { this[nameof(PackagePath)] = value; } }
        public Object Author { get { return this[nameof(Author)]; } set { this[nameof(Author)] = value; } }
        public Object AuthorURL { get { return this[nameof(AuthorURL)]; } set { this[nameof(AuthorURL)] = value; } }
        public Object Description { get { return this[nameof(Description)]; } set { this[nameof(Description)] = value; } }
        public bool IsMounted { get { return this[nameof(IsMounted)].Flag; } set { this[nameof(IsMounted)].Flag = value; } }
    }
    public class Mods : Object
    {
        public Mods(ulong addr) : base(addr) { }
        public Array<ModDefinition> Mods_value { get { return new Array<ModDefinition>(this[nameof(Mods)].Address); } }
    }
    public class ModDefinition : Object
    {
        public ModDefinition(ulong addr) : base(addr) { }
        public Object Name { get { return this[nameof(Name)]; } set { this[nameof(Name)] = value; } }
    }
}
