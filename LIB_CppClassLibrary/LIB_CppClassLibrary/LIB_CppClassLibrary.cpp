// LIB_CppClassLibrary.cpp : DLL アプリケーション用にエクスポートされる関数を定義します。
//

#include "stdafx.h"
#include "LIB_CppClassLibrary.h"

// ウィンドウの各部の色を得る。
extern "C" __declspec(dllexport) int TestMethod()
{
	return 1;
}
