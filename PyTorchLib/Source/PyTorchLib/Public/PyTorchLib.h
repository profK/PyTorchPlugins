// Copyright Epic Games, Inc. All Rights Reserved.

#pragma once

#include "Modules/ModuleManager.h"
THIRD_PARTY_INCLUDES_START
#pragma warning(disable: 4067 4805 4624)
#include "Include/torch/csrc/api/include/torch/torch.h"
THIRD_PARTY_INCLUDES_END

class FPyTorchLibModule : public IModuleInterface
{
public:

	/** IModuleInterface implementation */
	virtual void StartupModule() override;
	virtual void ShutdownModule() override;

private:
	/** Handle to the test dll we will load */
	void*	ExampleLibraryHandle;
};
