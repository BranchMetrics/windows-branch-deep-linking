#include "pch.h"
#include <iostream>
#include <thread>
#import "..\Testbed-Windows-COM\Debug\branch_debug_0.2.1.tlb" 

using namespace branch_debug_0_2_1;

bool sessionInited = false;

void __stdcall InitCallback(ICOMBranchUniversalObjectPtr comBUO,
	ICOMBranchLinkPropertiesPtr comLinkProperties,
	LPTSTR error) {
	std::cout << "init session callback :) \n\r";
	std::cout << "title link: " + comBUO->Title + "\n\r";
	std::cout << "channel link: " + comLinkProperties->Channel + "\n\r";
	std::wcout << "error: " << error << "\n\r";

	sessionInited = true;
}

void init(ICOMBranchPtr comBranch, ICOMBranchUniversalObjectPtr buo, ICOMBranchLinkPropertiesPtr link)
{
	comBranch->InitSession_3(&InitCallback, "");
	std::cout << "init session \n\r";

	while (!sessionInited) Sleep(10);

	_bstr_t linkStr = buo->GetShortURL(link);
	std::cout << "generated link: " + linkStr + " \n\r";

	Sleep(3000);
}

int main()
{
	HRESULT hr = CoInitialize(NULL);

	ICOMBranchContentMetadataPtr comMetadata(__uuidof(COMBranchContentMetadata));
	comMetadata->AddCustomMetadata("testkey", "testvalue");

	ICOMBranchUniversalObjectPtr comBUO(__uuidof(COMBranchUniversalObject));
	comBUO->CanonicalIdentifier = "item/12345";
	comBUO->CanonicalUrl = "";
	comBUO->ContentIndexMode = "PRIVATE";
	comBUO->LocalIndexMode = "PUBLIC";
	comBUO->Title = "My Content Title";
	comBUO->ContentDescription = "my_product_description1";
	comBUO->ImageUrl = "https://example.com/mycontent-12345.png";
	comBUO->AddKeyword("My_Keyword1");
	comBUO->AddKeyword("My_Keyword2");

	ICOMBranchLinkPropertiesPtr comLinkProperties(__uuidof(COMBranchLinkProperties));
	comLinkProperties->AddTag("Tag1");
	comLinkProperties->Channel = "Sharing_Channel_name";
	comLinkProperties->Feature = "my_feature_name";
	comLinkProperties->AddControlParam("$android_deeplink_path", "custom/path/*");
	comLinkProperties->AddControlParam("$ios_url", "http://example.com/ios");
	comLinkProperties->MatchDuration = 100;

	ICOMBranchPtr comBranch(__uuidof(COMBranch));
	comBranch->GetBranchInstance(false, "key_test_gcy1q6txmcqHyqPqacgBZpbiush0RSDs");
	comBranch->SetNetworkTimeout(3000);

	std::thread t1(init, comBranch, comBUO, comLinkProperties);
	t1.join();

	CoUninitialize();
}