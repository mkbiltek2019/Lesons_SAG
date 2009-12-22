#ifndef _C_MY_LISTOF_FILES_
#define _C_MY_LISTOF_FILES_
//-------------------------
const int len = 60;
#include <stdio.h>
#include <io.h>       
#include <string.h>
#include <vector>
#include <iostream>
using namespace std;
#include <windows.h>
///------------------------
struct inputedData{
	
	 TCHAR Name[len];
	 TCHAR Surname[len];
	 TCHAR ThirdName[len];
	//-----
	 TCHAR Phone[len];
	 TCHAR Adress[len];
	 TCHAR FamilyState[len];
	 //----
	 TCHAR Gender[len];
	 TCHAR Nationality[len];
	 TCHAR PhotoPath[len]; 
	//------
	// TCHAR FileName[len*10];	
};
typedef inputedData inStrucData;
//-------------------------
class CListOfFiles {
private:
	std::vector<std::string> listOfFiles;
	std::string searchDirectory;
public:
	//------
	CListOfFiles();
	~CListOfFiles();
	void removeFile(std::string fileName);
	std::vector<std::string>& getListOfFiles();
	void createListOfFiles(std::string dirName);
	//------
	void writedatatofile(inStrucData& datastruct);
	inputedData& readdatafromfile(std::string fileName);
	//------
};
typedef CListOfFiles* fileList;

//-------------------------
#endif