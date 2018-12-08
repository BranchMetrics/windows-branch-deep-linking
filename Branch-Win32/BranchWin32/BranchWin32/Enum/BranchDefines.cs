﻿namespace BranchSdk.Enum {
    public enum BranchJsonKey {
        IdentityID,
        Identity,
        DeviceFingerprintID,
        SessionID,
        LinkClickID,
        GoogleSearchInstallReferrer,
        GooglePlayInstallReferrer,
        ClickedReferrerTimeStamp,
        InstallBeginTimeStamp,
        FaceBookAppLinkChecked,
        BranchLinkUsed,
        ReferringBranchIdentity,
        BranchIdentity,
        BranchKey,
        BranchData,

        Bucket,
        DefaultBucket,
        Amount,
        CalculationType,
        Location,
        Type,
        CreationSource,
        Prefix,
        Expiration,
        Event,
        Metadata,
        CommerceData,
        ReferralCode,
        Total,
        Unique,
        Length,
        Direction,
        BeginAfterID,
        Link,
        ReferringData,
        ReferringLink,
        IsFullAppConv,
        Data,
        OS,
        HardwareID,
        AndroidID,
        UnidentifiedDevice,
        HardwareIDType,
        HardwareIDTypeVendor,
        HardwareIDTypeRandom,
        IsHardwareIDReal,
        AppVersion,
        OSVersion,
        Country,
        Language,
        IsReferrable,
        Update,
        OriginalInstallTime,
        FirstInstallTime,
        LastUpdateTime,
        PreviousUpdateTime,
        URIScheme,
        AppIdentifier,
        LinkIdentifier,
        GoogleAdvertisingID,
        AAID,
        LATVal,
        LimitedAdTracking,
        limitFacebookTracking,
        Debug,
        Brand,
        Model,
        ScreenDpi,
        ScreenHeight,
        ScreenWidth,
        WiFi,
        LocalIP,
        UserData,
        DeveloperIdentity,
        UserAgent,
        SDK,
        SdkVersion,
        UIMode,

        Clicked_Branch_Link,
        IsFirstSession,
        AndroidDeepLinkPath,
        DeepLinkPath,

        AndroidAppLinkURL,
        AndroidPushNotificationKey,
        AndroidPushIdentifier,
        ForceNewBranchSession,

        CanonicalIdentifier,
        ContentTitle,
        ContentDesc,
        ContentImgUrl,
        CanonicalUrl,

        ContentType,
        PublicallyIndexable,
        LocallyIndexable,
        ContentKeyWords,
        ContentExpiryTime,
        Params,
        SharedLink,
        ShareError,

        External_Intent_URI,
        External_Intent_Extra,
        Last_Round_Trip_Time,
        Branch_Round_Trip_Time,
        Branch_Instrumentation,
        Queue_Wait_Time,
        InstantDeepLinkSession,

        BranchViewData,
        BranchViewID,
        BranchViewAction,
        BranchViewNumOfUse,
        BranchViewUrl,
        BranchViewHtml,

        Path,
        ViewList,
        ContentActionView,
        ContentPath,
        ContentNavPath,
        ReferralLink,
        ContentData,
        ContentEvents,
        ContentAnalyticsMode,
        ContentDiscovery,
        Environment,
        InstantApp,
        NativeApp,

        TransactionID,
        Currency,
        Revenue,
        Shipping,
        Tax,
        Coupon,
        Affiliation,
        Description,
        SearchQuery,

        Name,
        CustomData,
        EventData,
        ContentItems,
        ContentSchema,
        Price,
        PriceCurrency,
        Quantity,
        SKU,
        ProductName,
        ProductBrand,
        ProductCategory,
        ProductVariant,
        Rating,
        RatingAverage,
        RatingCount,
        RatingMax,
        AddressStreet,
        AddressCity,
        AddressRegion,
        AddressCountry,
        AddressPostalCode,
        Latitude,
        Longitude,
        ImageCaptions,
        Condition,
        CreationTimestamp,
        TrackingDisable,

        WindowsAppWebLinkUrl,

        None
    }

    public enum RequestPath {
        RedeemRewards,
        GetURL,
        RegisterInstall,
        RegisterClose,
        RegisterOpen,
        RegisterView,
        GetCredits,
        GetCreditHistory,
        CompletedAction,
        IdentifyUser,
        Logout,
        GetReferralCode,
        ValidateReferralCode,
        ApplyReferralCode,
        DebugConnect,
        ContentEvent,
        TrackStandardEvent,
        TrackCustomEvent,
        None
    }

    public enum LinkParam {
        Tags,
        Alias,
        Type,
        Duration,
        Channel,
        Feature,
        Stage,
        Campaign,
        Data,
        URL
    }
}
