// Copyright Epic Games, Inc. All Rights Reserved.

#include "PyTorchBPBPLibrary.h"
#include "PyTorchBP.h"

UPyTorchBPBPLibrary::UPyTorchBPBPLibrary(const FObjectInitializer& ObjectInitializer)
: Super(ObjectInitializer)
{

}

FTensor UPyTorchBPBPLibrary::RandIntTensor(int rows,int cols)
{
	return FTensor(torch::rand({rows,cols}));
}

