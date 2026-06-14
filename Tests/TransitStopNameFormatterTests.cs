using FirstPersonCameraContinued.DataModels;
using Xunit;

namespace FirstPersonCameraContinued.Tests;

public class TransitStopNameFormatterTests
{
    [Fact]
    public void ChooseStopNameUsesCustomNameBeforeTrackAssetLabel()
    {
        string name = TransitStopNameFormatter.ChooseStopName(
            "Custom Stop",
            "Assets.NAME[Subway Track]");

        Assert.Equal("Custom Stop", name);
    }

    [Fact]
    public void ChooseStopNameIgnoresRawAssetLocalizationLabels()
    {
        string name = TransitStopNameFormatter.ChooseStopName("Assets.NAME[Subway Track]");

        Assert.Equal("Stop", name);
    }
}
