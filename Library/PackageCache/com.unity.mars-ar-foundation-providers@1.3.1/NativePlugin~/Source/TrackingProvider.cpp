#include "TrackingProvider.h"
#include "ProviderContext.h"

#include "XR/UnitySubsystemTypes.h"

static UnityXRPose sPose;

UnitySubsystemErrorCode MARSTrackingProvider::Initialize()
{
    return kUnitySubsystemErrorCodeSuccess;
}

UnitySubsystemErrorCode MARSTrackingProvider::Start()
{
    m_Ctx.input->InputSubsystem_DeviceConnected(m_Handle, kInputDeviceHMD);
    return kUnitySubsystemErrorCodeSuccess;
}

static float s_Time = 0.0f;

void MARSTrackingProvider::OnNewInputFrame()
{
    // Latch poses for sim
}

void MARSTrackingProvider::FillDeviceDefinition(UnityXRInternalInputDeviceId deviceId, UnityXRInputDeviceDefinition* definition)
{
    // Fill in your connected device information here when requested.  Used to create customized device states.
    auto& input = *m_Ctx.input;
    input.DeviceDefinition_SetName(definition, "MARS XR Subsystem camera tracking");
    input.DeviceDefinition_SetRole(definition, kUnityXRInputDeviceRoleGeneric);
    input.DeviceDefinition_SetManufacturer(definition, "Unity");

    // Add basic feature usages for 1-element tracking to match Input Systems XRHMD
    input.DeviceDefinition_AddFeatureWithUsage(definition, "IsTracked", kUnityXRInputFeatureTypeBinary, kUnityXRInputFeatureUsageIsTracked);
    input.DeviceDefinition_AddFeatureWithUsage(definition, "TrackingState", kUnityXRInputFeatureTypeDiscreteStates, kUnityXRInputFeatureUsageTrackingState);
    input.DeviceDefinition_AddFeatureWithUsage(definition, "centerEyePosition", kUnityXRInputFeatureTypeAxis3D, kUnityXRInputFeatureUsageCenterEyePosition);
    input.DeviceDefinition_AddFeatureWithUsage(definition, "centerEyeRotation", kUnityXRInputFeatureTypeRotation, kUnityXRInputFeatureUsageCenterEyeRotation);
}

UnitySubsystemErrorCode MARSTrackingProvider::UpdateDeviceState(UnityXRInternalInputDeviceId deviceId, UnityXRInputUpdateType updateType, UnityXRInputDeviceState* state)
{
    /// Called by Unity when it needs a current device snapshot
    auto& input = *m_Ctx.input;
    if (deviceId == kInputDeviceHMD)
    {
        UnityXRInputFeatureIndex featureIdx = 0;
        input.DeviceState_SetBinaryValue(state, featureIdx++, true);
        input.DeviceState_SetDiscreteStateValue(state, featureIdx++, kUnityXRInputTrackingStatePosition | kUnityXRInputTrackingStateRotation);
        input.DeviceState_SetAxis3DValue(state, featureIdx++, sPose.position);
        input.DeviceState_SetRotationValue(state, featureIdx++, sPose.rotation);
    }

    return kUnitySubsystemErrorCodeSuccess;
}

UnitySubsystemErrorCode MARSTrackingProvider::HandleEvent(UnityXRInputEventType eventType, UnityXRInternalInputDeviceId deviceId, void* buffer, unsigned int size)
{
    /// Return kUnitySubsystemErrorCodeFailure on all unhandled events so the calling code knows we didn't modify the returned buffer.
    return kUnitySubsystemErrorCodeFailure;
}

void MARSTrackingProvider::Stop()
{
    m_Ctx.input->InputSubsystem_DeviceDisconnected(m_Handle, kInputDeviceHMD);
}

void MARSTrackingProvider::Shutdown()
{

}

// Binding to C-API below here

extern "C" void UNITY_INTERFACE_EXPORT UNITY_INTERFACE_API MARSXRSubsystem_SetCameraPose(
    float pos_x, float pos_y, float pos_z,
    float rot_x, float rot_y, float rot_z, float rot_w) {
    sPose.position.x = pos_x;
    sPose.position.y = pos_y;
    sPose.position.z = pos_z;
    sPose.rotation.x = rot_x;
    sPose.rotation.y = rot_y;
    sPose.rotation.z = rot_z;
    sPose.rotation.w = rot_w;
}

static UnitySubsystemErrorCode UNITY_INTERFACE_API Input_Initialize(UnitySubsystemHandle handle, void* userData)
{
    auto& ctx = GetProviderContext(userData);

    ctx.trackingProvider = new MARSTrackingProvider(ctx, handle);

    UnityXRInputProvider inputProvider{};
    inputProvider.userData = &ctx;

    inputProvider.OnNewInputFrame = [](UnitySubsystemHandle handle, void* userData) -> void
    {
        auto& ctx = GetProviderContext(userData);
        ctx.trackingProvider->OnNewInputFrame();
    };

    inputProvider.FillDeviceDefinition = [](UnitySubsystemHandle handle, void* userData, UnityXRInternalInputDeviceId deviceId, UnityXRInputDeviceDefinition* definition) -> void
    {
        auto& ctx = GetProviderContext(userData);
        ctx.trackingProvider->FillDeviceDefinition(deviceId, definition);
    };

    inputProvider.UpdateDeviceState = [](UnitySubsystemHandle handle, void* userData, UnityXRInternalInputDeviceId deviceId, UnityXRInputUpdateType updateType, UnityXRInputDeviceState* state) -> UnitySubsystemErrorCode
    {
        auto& ctx = GetProviderContext(userData);
        return ctx.trackingProvider->UpdateDeviceState(deviceId, updateType, state);
    };

    inputProvider.HandleEvent = [](UnitySubsystemHandle handle, void* userData, UnityXRInputEventType eventType, UnityXRInternalInputDeviceId deviceId, void* buffer, unsigned int size) -> UnitySubsystemErrorCode
    {
        auto& ctx = GetProviderContext(userData);
        return ctx.trackingProvider->HandleEvent(eventType, deviceId, buffer, size);
    };

    ctx.input->RegisterInputProvider(handle, &inputProvider);

    return ctx.trackingProvider->Initialize();
}

UnitySubsystemErrorCode Load_Input(ProviderContext& ctx)
{
    ctx.input = ctx.interfaces->Get<IUnityXRInputInterface>();
    if (ctx.input == nullptr) {
        return kUnitySubsystemErrorCodeFailure;
    }

    UnityLifecycleProvider inputLifecycleHandler{};
    inputLifecycleHandler.userData = &ctx;

    inputLifecycleHandler.Initialize = &Input_Initialize;

    inputLifecycleHandler.Start = [](UnitySubsystemHandle handle, void* userData) -> UnitySubsystemErrorCode
    {
        auto& ctx = GetProviderContext(userData);
        auto r = ctx.trackingProvider->Start();
        return r;
    };

    inputLifecycleHandler.Stop = [](UnitySubsystemHandle handle, void* userData) -> void
    {
        auto& ctx = GetProviderContext(userData);
        ctx.trackingProvider->Stop();
    };

    inputLifecycleHandler.Shutdown = [](UnitySubsystemHandle handle, void* userData) -> void
    {
        auto& ctx = GetProviderContext(userData);
        ctx.trackingProvider->Shutdown();

        delete ctx.trackingProvider;
    };

    return ctx.input->RegisterLifecycleProvider("MARS XR Plugin", "MARS Head Tracking", &inputLifecycleHandler);
}
