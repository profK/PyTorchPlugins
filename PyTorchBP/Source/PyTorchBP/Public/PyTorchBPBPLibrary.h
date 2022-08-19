// Copyright Epic Games, Inc. All Rights Reserved.

#pragma once

#include "PyTorchLib.h"
#include "Kismet/BlueprintFunctionLibrary.h"
#include "PyTorchBPBPLibrary.generated.h"


/* 
*	Function library class.
*	Each function in it is expected to be static and represents blueprint node that can be called in any blueprint.
*
*	When declaring function you can define metadata for the node. Key function specifiers will be BlueprintPure and BlueprintCallable.
*	BlueprintPure - means the function does not affect the owning object in any way and thus creates a node without Exec pins.
*	BlueprintCallable - makes a function which can be executed in Blueprints - Thus it has Exec pins.
*	DisplayName - full name of the node, shown when you mouse over the node and in the blueprint drop down menu.
*				Its lets you name the node using characters not allowed in C++ function names.
*	CompactNodeTitle - the word(s) that appear on the node.
*	Keywords -	the list of keywords that helps you to find node when you search for it using Blueprint drop-down menu. 
*				Good example is "Print String" node which you can find also by using keyword "log".
*	Category -	the category your node will be under in the Blueprint drop-down menu.
*
*	For more info on custom blueprint nodes visit documentation:
*	https://wiki.unrealengine.com/Custom_Blueprint_Node_Creation
*/

USTRUCT(BlueprintType)
struct FTensor
{
	GENERATED_BODY()
	
	//~ The following member variable will be not accessible by Blueprint Graphs:
	torch::Tensor tensor;

	FTensor()
	{
		tensor=torch::rand({3,3});
	}

	FTensor(torch::Tensor t)
	{
		tensor=t;
	}
};

UCLASS()
class UPyTorchBPBPLibrary : public UBlueprintFunctionLibrary
{
	GENERATED_UCLASS_BODY()

	UFUNCTION(BlueprintCallable, meta = (DisplayName = "Make Random Int Tensor", Keywords = "PyTorchBP s"), Category = "PyTorch")
	static FTensor  RandIntTensor(int rows,int cols);
	
	UFUNCTION(BlueprintCallable, meta = (DisplayName = "Tensor To String", Keywords = "PyTorchBP s"), Category = "PyTorch")
    	static FString  TensorToString(FTensor tensor);
};
