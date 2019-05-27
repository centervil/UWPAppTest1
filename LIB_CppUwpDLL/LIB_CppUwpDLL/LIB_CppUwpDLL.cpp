#include "pch.h"
#include "LIB_CppUwpDLL.h"

#include <winrt/Windows.UI.Notifications.h>
#include <winrt/Windows.Data.Xml.Dom.h>
using namespace winrt;
using namespace Windows::Foundation;
using namespace Windows::UI::Notifications;

extern "C" __declspec(dllexport) int TestMethod()
{
	auto notificationManager = ToastNotificationManager::GetDefault();
	auto toastXml = ToastNotificationManager::GetTemplateContent(ToastTemplateType::ToastText01);
	auto textNode = toastXml.GetElementsByTagName(L"text").Item(0);
	textNode.AppendChild(toastXml.CreateTextNode(L"LIB_CppUwpDLL is Called"));
	auto toast = ToastNotification(toastXml);
	toast.ExpirationTime(winrt::clock::now() + std::chrono::hours() * 2);
	notificationManager.CreateToastNotifier().Show(toast);

	return 1;
}
