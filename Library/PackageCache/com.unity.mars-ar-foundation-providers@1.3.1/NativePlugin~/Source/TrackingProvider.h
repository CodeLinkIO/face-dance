#pragma once

#include "ProviderContext.h"
#include "XR/IUnityXRInput.h"

class MARSTrackingProvider : public ProviderImpl
{
public:
    MARSTrackingProvider(ProviderContext& ctx, UnitySubsystemHandle handle)
    : ProviderImpl(ctx, handle)
    {}
    virtual ~MARSTrackingProvider() {}

    UnitySubsystemErrorCode Initialize() override;
    UnitySubsystemErrorCode Start() override;

    void OnNewInputFrame();
    void FillDeviceDefinition(UnityXRInternalInputDeviceId deviceId, UnityXRInputDeviceDefinition* definition);
    UnitySubsystemErrorCode UpdateDeviceState(UnityXRInternalInputDeviceId deviceId, UnityXRInputUpdateType updateType, UnityXRInputDeviceState* state);
    UnitySubsystemErrorCode HandleEvent(UnityXRInputEventType eventType, UnityXRInternalInputDeviceId deviceId, void* buffer, unsigned int size);
    UnitySubsystemErrorCode TryGetDeviceStateAtTime(UnityXRTimeStamp time, UnityXRInternalInputDeviceId deviceId, UnityXRInputDeviceState* state);

    void Stop() override;
    void Shutdown() override;

private:
    static const int kInputDeviceHMD = 0;
};
