#include "MonteCarlosProc.h"
#include <Windows.h>
using namespace System;
using namespace MonteKursa;
using namespace System::Windows::Forms;
[STAThreadAttribute]
int WINAPI WinMain(HINSTANCE, HINSTANCE, LPSTR, int)
{
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false);
	Application::Run(gcnew MonteKursa::MonteCarlosProc());
	return 0;
}
