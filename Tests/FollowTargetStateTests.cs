using FirstPersonCameraContinued.DataModels;
using Xunit;

namespace FirstPersonCameraContinued.Tests;

public class FollowTargetStateTests
{
    [Fact]
    public void ResolvingAttachmentTargetDoesNotChangeSelectedSubject()
    {
        var state = new FollowTargetState<int>(0);

        state.SelectSubject(42);
        state.ResolveAttachmentTarget(9001);

        Assert.Equal(42, state.SelectedSubject);
        Assert.Equal(9001, state.AttachmentTarget);
    }

    [Fact]
    public void ClearingSubjectAlsoClearsAttachmentTarget()
    {
        var state = new FollowTargetState<int>(0);

        state.SelectSubject(42);
        state.ResolveAttachmentTarget(9001);
        state.SelectSubject(0);

        Assert.Equal(0, state.SelectedSubject);
        Assert.Equal(0, state.AttachmentTarget);
    }

    [Fact]
    public void ChangingAttachmentTargetAdvancesAttachmentRevision()
    {
        var state = new FollowTargetState<int>(0);

        state.SelectSubject(42);
        int selectedRevision = state.AttachmentRevision;

        state.ResolveAttachmentTarget(9001);
        int vehicleRevision = state.AttachmentRevision;
        state.ResolveAttachmentTarget(9001);

        Assert.Equal(42, state.SelectedSubject);
        Assert.True(vehicleRevision > selectedRevision);
        Assert.Equal(vehicleRevision, state.AttachmentRevision);
    }
}
