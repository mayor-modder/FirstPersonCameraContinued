using FirstPersonCameraContinued.DataModels;
using Xunit;

namespace FirstPersonCameraContinued.Tests;

public class TransitStopNameFormatterTests
{
    [Fact]
    public void ChooseStopNameUsesCustomNameBeforeTrackAssetLabel()
    {
        string name = TransitStopNameFormatter.ChooseStopName(
            "Jacob Circle",
            "Assets.NAME[Subway Track]");

        Assert.Equal("Jacob Circle", name);
    }

    [Fact]
    public void ChooseStopNameIgnoresRawAssetLocalizationLabels()
    {
        string name = TransitStopNameFormatter.ChooseStopName("Assets.NAME[Subway Track]");

        Assert.Equal("Stop", name);
    }
}
